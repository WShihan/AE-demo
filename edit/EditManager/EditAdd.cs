using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using MapOperation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Display;

namespace edit.EditManager
{
    public class EditAdd
    {

        private IEngineEditor cEngineEditor;
        private IActiveView cActiveView;
        private IMap cMap;
        private IFeatureLayer cFeatLayer;

        private IPointCollection cPointCollection;
        private INewLineFeedback cNewlineFeedback;
        private INewMultiPointFeedback cNewMultiPtFeedback;
        private INewPolygonFeedback cNewPolygonFeedback;

        public EditAdd(IEngineEditor pEngineEditor, IEngineEditLayers pEngineEditLayer, IActiveView pActiveView, IMap pMap)
        {
            cMap = pMap;
            cEngineEditor = pEngineEditor;
            cActiveView = pActiveView;
            cFeatLayer = pEngineEditLayer.TargetLayer;
        }

        public void CaptureDblClick()
        {
            IGeometry pResultGeometry = null;
            if (cEngineEditor == null) return;
            //获取编辑目标图层
            IFeatureClass pFeatCls = cFeatLayer.FeatureClass;
            if (pFeatCls == null) return;

            switch (pFeatCls.ShapeType)
            {
                case esriGeometryType.esriGeometryMultipoint:
                    cNewMultiPtFeedback.Stop();
                    pResultGeometry = cPointCollection as IGeometry;
                    pResultGeometry = null;
                    break;
                case esriGeometryType.esriGeometryPolyline:
                    IPolyline pPolyline = null;
                    pPolyline = cNewlineFeedback.Stop();
                    pResultGeometry = pPolyline as IGeometry;
                    cNewlineFeedback = null;
                    break;
                case esriGeometryType.esriGeometryPolygon:
                    IPolygon pPolygon = null;
                    pPolygon = cNewPolygonFeedback.Stop();
                    pResultGeometry = pPolygon as IGeometry;
                    cNewPolygonFeedback = null;
                    break;
            }

            //IZAware pZAware = pResultGeometry as IZAware;
            //pZAware.ZAware = true;
            //创建新要素
            CreateFeature(pResultGeometry);
        }

        /// <summary>
        /// 添加数据操作中捕捉鼠标点击
        /// </summary>
        /// <param name="button"></param>
        /// <param name="shift"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void CaptureDown(int button, int shift, int x, int y)
        {
            try
            {
                IPoint pPt = cActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
                if (cEngineEditor == null) return;
                if (cEngineEditor.EditState != esriEngineEditState.esriEngineStateEditing) return;
                if (cFeatLayer == null) return;
                IFeatureClass pFeatCls = cFeatLayer.FeatureClass;
                if (pFeatCls == null) return;

                //解决编辑要素的Z值问题
                IZAware pZAware = pPt as IZAware;
                pZAware.ZAware = true;
                pPt.Z = 0;

                object missing = Type.Missing;

                cMap.ClearSelection();

                switch (pFeatCls.ShapeType)
                {
                    case esriGeometryType.esriGeometryPoint:
                        //当为点层时，直接创建要素
                        CreateFeature(pPt as IGeometry);
                        break;
                    case esriGeometryType.esriGeometryMultipoint:
                        //点集的处理方式
                        if (cPointCollection == null)
                        {
                            cPointCollection = new MultipointClass();
                        }
                        else
                        {
                            cPointCollection.AddPoint(pPt, ref missing, ref missing);
                        }
                        if (cNewMultiPtFeedback == null)
                        {
                            cNewMultiPtFeedback = new NewMultiPointFeedbackClass();
                            cNewMultiPtFeedback.Display = cActiveView.ScreenDisplay;
                            cNewMultiPtFeedback.Start(cPointCollection, pPt);
                        }
                        break;
                    case esriGeometryType.esriGeometryPolyline:
                        //多义线处理方式
                        if (cNewlineFeedback == null)
                        {
                            cNewlineFeedback = new NewLineFeedbackClass();
                            cNewlineFeedback.Display = cActiveView.ScreenDisplay;
                            cNewlineFeedback.Start(pPt);
                        }
                        else
                        {
                            cNewlineFeedback.AddPoint(pPt);
                        }
                        break;
                    case esriGeometryType.esriGeometryPolygon:
                        //多边形处理方式
                        if (cNewPolygonFeedback == null)
                        {
                            cNewPolygonFeedback = new NewPolygonFeedbackClass();
                            cNewPolygonFeedback.Display = cActiveView.ScreenDisplay;
                            cNewPolygonFeedback.Start(pPt);
                        }
                        else   
                        {
                            cNewPolygonFeedback.AddPoint(pPt);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        /// <summary>
        /// 添加元素操作中捕捉鼠标移动（当编辑图层几何类型为线/面情况）
        /// </summary>
        /// <param name="button"></param>
        /// <param name="shift"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void CaptureMove(int button, int shift, int x, int y)
        {
            IPoint pPt = cActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
            if (cFeatLayer == null) return;
            IFeatureClass pFeatCls = cFeatLayer.FeatureClass;
            if (pFeatCls == null) return;
            switch (pFeatCls.ShapeType)
            {
                case esriGeometryType.esriGeometryPolyline:
                    if (cNewlineFeedback != null)
                        cNewlineFeedback.MoveTo(pPt);
                    break;
                case esriGeometryType.esriGeometryPolygon:
                    if (cNewPolygonFeedback != null)
                        cNewPolygonFeedback.MoveTo(pPt);
                    break;
            }
        }

        /// <summary>
        /// 创建要素
        /// </summary>
        /// <param name="pGeometry"></param>
        public void CreateFeature(IGeometry pGeometry)
        {
            try
            {
                if (cFeatLayer == null) return;
                IFeatureClass pFeatCls = cFeatLayer.FeatureClass;
                if (pFeatCls == null) return;
                if (cEngineEditor == null) return;
                if (pGeometry == null) return;
                ITopologicalOperator pTop = pGeometry as ITopologicalOperator;
                pTop.Simplify();
                IGeoDataset pGeoDataset = pFeatCls as IGeoDataset;
                if (pGeoDataset.SpatialReference != null)
                {
                    pGeometry.Project(pGeoDataset.SpatialReference);
                }
                cEngineEditor.StartOperation();
                IFeature pFeature = null;
                pFeature = pFeatCls.CreateFeature();
                pFeature.Shape = MapManager.ModifyGeomtryZMValue(pFeatCls, pGeometry);
                pFeature.Store();
                cEngineEditor.StopOperation("添加要素");
                cMap.SelectFeature(cFeatLayer, pFeature);
                cActiveView.Refresh();
            }
            catch (Exception ex)
            {

            }
        }
    }
}

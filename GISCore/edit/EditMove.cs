using System;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using System.Windows.Forms;
using ESRI.ArcGIS.Display;
using GISService;
using GISService.Interface;

namespace Process.edit
{
    public class EditMove:IEditeTool
    {
        //变量
        private IEngineEditor m_EngineEditor;
        private IEngineEditLayers m_EngineEditLayers;
        private IActiveView m_activeView;
        private IMap m_Map;
        private IPoint fromtPoint;
        private IPoint toPoint;
        IMoveGeometryFeedback m_moveGeoFeedBack;
        string _name;
        int _ID;
        public EditMove(
            IEngineEditor pEngineEditor,
            IEngineEditLayers pEngineEditLayers,
            IActiveView pActiveView,
            IMap pMap,
            IMoveGeometryFeedback pMoveGeoFeedBack
            )
        {
            m_EngineEditor = pEngineEditor;
            m_EngineEditLayers = pEngineEditLayers;
            m_activeView = pActiveView;
            m_Map = pMap;
            m_moveGeoFeedBack = pMoveGeoFeedBack;
            _name = GetType().ToString();
        }
        public int ID
        {
            get { return _ID; }
        }
        public string Name
        {
            get { return _name; }
        }        // 按下事件
        public  void OnMouseDown(int button, int shift, int x, int y)
        {
            try
            {
                //转换鼠标点击位置起始点为地图坐标
                fromtPoint = m_activeView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
                if (m_EngineEditor == null) return;
                if (m_EngineEditor.EditState != esriEngineEditState.esriEngineStateEditing) return;
                if (m_EngineEditLayers == null) return;
                IFeatureLayer pFeatLyr = m_EngineEditLayers.TargetLayer;
                if (pFeatLyr == null) return;
                //获取要移动几何对象
                IFeatureCursor pFeatCur = MapManager.GetSelectedFeatures(pFeatLyr);
                if (pFeatCur == null)
                {
                    MessageBox.Show("请选择要移动要素！", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                IFeature pFeature = pFeatCur.NextFeature();
                //当移动的对象为空时，首先进行对象实例化
                if (m_moveGeoFeedBack == null)
                    m_moveGeoFeedBack = new MoveGeometryFeedbackClass();
                m_moveGeoFeedBack.Display = m_activeView.ScreenDisplay;
                while (pFeature != null)
                {
                    m_moveGeoFeedBack.AddGeometry(pFeature.Shape);
                    pFeature = pFeatCur.NextFeature();
                }
                //添加起始点
                m_moveGeoFeedBack.Start(fromtPoint);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pFeatCur);
            }
            catch (Exception ex)
            {
            }
        }
        public  void OnMouseMove(int button, int shift, int x, int y)
        {
            try
            {
                IPoint pMovePt = null;
                pMovePt = m_activeView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
                if (m_moveGeoFeedBack == null) return;
                m_moveGeoFeedBack.MoveTo(pMovePt);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public  void OnMouseUp(int button, int shift, int x, int y)
        {
            try
            {
                toPoint = m_activeView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
                if (m_moveGeoFeedBack == null) return;
                m_moveGeoFeedBack.MoveTo(toPoint);
                MoveOperation(toPoint, fromtPoint);
                m_moveGeoFeedBack.ClearGeometry();
                m_moveGeoFeedBack = null;
            }
            catch (Exception ex)
            {

                MessageBox.Show("出错：" + ex.ToString());
            }
        }

        private void MoveOperation(IPoint lastpoint, IPoint firstpoint)
        {
            if (m_EngineEditor == null) return;
            //开始一个编辑流程
            m_EngineEditor.StartOperation();
            if (m_EngineEditLayers == null) return;
            //获取移动的图层
            IFeatureLayer pFeatLyr = m_EngineEditLayers.TargetLayer;
            if (pFeatLyr == null) return;
            //获取选择要素指针
            IFeatureCursor pFeatCur = MapManager.GetSelectedFeatures(pFeatLyr);
            IFeature pFeature = pFeatCur.NextFeature();
            while (pFeature != null)
            {
                //实现要素的移动
                MoveFeature(pFeature, lastpoint, firstpoint);
                pFeature = pFeatCur.NextFeature();
            }
            //停止编辑流程
            m_EngineEditor.StopOperation("MoveTool");
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pFeatCur);
            m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection | esriViewDrawPhase.esriViewGeography, null, null);
        }

        private void MoveFeature(IFeature pFeature, IPoint lastpoint, IPoint firstpoint)
        {
            double deltax; double deltay;
            IGeoDataset pGeoDataSet;
            ITransform2D transform;
            IGeometry pGeometry;
            IFeatureClass pClass = pFeature.Class as IFeatureClass;
            pGeoDataSet = pClass as IGeoDataset;

            pGeometry = pFeature.Shape;
            if (pGeometry.GeometryType == esriGeometryType.esriGeometryMultiPatch
                || pGeometry.GeometryType == esriGeometryType.esriGeometryPoint
                || pGeometry.GeometryType == esriGeometryType.esriGeometryPolyline
                || pGeometry.GeometryType == esriGeometryType.esriGeometryPolygon)
            {
                pGeometry = pFeature.Shape;
                transform = pGeometry as ITransform2D;
                if (!MapManager.CalDistance(lastpoint, firstpoint, out deltax, out deltay))
                {
                    MessageBox.Show("计算距离出现错误", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //根据两点在X轴和Y轴上的距离差，对要素进行移动
                transform.Move(deltax, deltay);
                pGeometry = (IGeometry)transform;
                if (pGeoDataSet.SpatialReference != null)
                {
                    pGeometry.Project(pGeoDataSet.SpatialReference);
                }
                pFeature.Shape = pGeometry;
                // 若要素存在Z值或M值，移动之后需要修改为对应数值
                pFeature.Shape = MapManager.ModifyGeomtryZMValue(pClass, pGeometry);
                //保存移动后的对象 
                pFeature.Store();
            }
        }
        public void OnKeyDown(int x, int y) { }
        public void OnKeyUp(int x, int y) { }

    }
}

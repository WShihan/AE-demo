using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using Process.MapOperation;
using framework;
using System;
using System.Windows.Forms;
using framework.Interface;

namespace Process.edit
{
    public class EditSelect:IEditeTool
    {
        private bool _editMod = false;
        private IEngineEditor m_EngineEditor;
        private IEngineEditLayers m_EngineEditLayers;
        private IActiveView m_activeView;
        private IMap m_Map;
        int _ID;
        string _name;
        public EditSelect(bool mod, IEngineEditor pEngineEditor, IEngineEditLayers pEngineEditLayers, IActiveView pActiveView, IMap pMap)
        {
            _editMod = mod;
            m_EngineEditor = pEngineEditor;
            m_EngineEditLayers = pEngineEditLayers;
            m_activeView = pActiveView;
            m_Map = pMap;
            _name = GetType().ToString();
        }
        public int ID
        {
            get { return _ID; }
        }
        public string Name
        {
            get { return _name; }
        }
        /// <summary>
        /// 编辑状态下选择要素
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public  void OnMouseDown(int button, int shift, int x, int y)
        {
            try
            {
                if ( _editMod == false) return;
                if (m_EngineEditor.EditState != esriEngineEditState.esriEngineStateEditing) return;
                if (m_EngineEditLayers == null) return;
                //获取目标图层
                IFeatureLayer pFeatLyr = m_EngineEditLayers.TargetLayer;
                IFeatureClass pFeatCls = pFeatLyr.FeatureClass;
                //获取地图上的坐标点
                IPoint pPt = m_activeView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
                IGeometry pGeometry = pPt as IGeometry;
                double dLength = 0;
                ITopologicalOperator pTopo = pGeometry as ITopologicalOperator;
                //设置选择过滤条件
                ISpatialFilter pSpatialFilter = new SpatialFilterClass();
                //不同的图层类型设置不同的过滤条件
                switch (pFeatCls.ShapeType)
                {
                    case esriGeometryType.esriGeometryPoint:
                        //将像素距离转换为地图单位距离
                        dLength = MapManager.Pixel2MapUnits(m_activeView, 8);
                        pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                        break;
                    case esriGeometryType.esriGeometryPolygon:
                        dLength = MapManager.Pixel2MapUnits(m_activeView, 4);
                        pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                        break;
                    case esriGeometryType.esriGeometryPolyline:
                        dLength = MapManager.Pixel2MapUnits(m_activeView, 4);
                        pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelCrosses;
                        break;
                }
                //根据过滤条件进行缓冲
                IGeometry pBuffer = null;
                pBuffer = pTopo.Buffer(dLength);
                pGeometry = pBuffer.Envelope as IGeometry;
                pSpatialFilter.Geometry = pGeometry;
                pSpatialFilter.GeometryField = pFeatCls.ShapeFieldName;
                IQueryFilter pQueryFilter = pSpatialFilter as IQueryFilter;
                //根据过滤条件进行查询
                IFeatureCursor pFeatCursor = pFeatCls.Search(pQueryFilter, false);
                IFeature pFeature = pFeatCursor.NextFeature();
                while (pFeature != null)
                {
                    //获取地图选择集
                    m_Map.SelectFeature(pFeatLyr as ILayer, pFeature);
                    pFeature = pFeatCursor.NextFeature();
                }
                m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(pFeatCursor);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"shape:{ ex.ToString() }");
            }
        }
        public  void OnMouseMove(int button, int shift, int x, int y)
        {

        }
        public  void OnMouseUp(int button, int shift, int x, int y) { }
        public  void OnKeyDown(int x, int y) { }
        public  void OnKeyUp(int x, int y) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GISService.Interface;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using BasicService.Config;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;

namespace GISService
{
    public class GisCore
    {
        IFeatureWorkspace featWorkSpace;
        private GISContext _gisContext;
        private AxMapControl _mapControl;
        private XMLReader _xmlReader = XMLReader.Instance;
        public GisCore() 
        {
            _gisContext = GISContext.Instance;
            this.ConnectDb();
        }
        public AxMapControl MapControl
        {
            get { return _mapControl; }
            set { _mapControl = value; }
        }
        public IGISContext GisContext
        {
            get { return _gisContext; }
        }
        public IFeatureWorkspace Workspace
        {
            get { return featWorkSpace; }
        }
        private void ConnectDb()
        {
            try
            {
                string gdb = _xmlReader.Read("config/data/gdb").InnerText;
                //System.Type t = Type.GetTypeFromProgID("esriDataSourcesGDB.FileGDBWorkspaceFactory");
                //System.Object obj = Activator.CreateInstance(t);
                //IWorkspaceFactory workspaceFactory = obj as IWorkspaceFactory;
                IWorkspaceFactory workspaceFactory = new FileGDBWorkspaceFactoryClass();
                IWorkspace workspace = workspaceFactory.OpenFromFile(gdb, 0);
                featWorkSpace = workspace as IFeatureWorkspace;
            }
            catch { }
        }
        /// <summary>
        /// 查筛选字段
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="fieldName"></param>
        /// <param name="condition"></param>
        /// <param name="subField"></param>
        /// <returns></returns>
        public List<string> QueryField(string fName,string fieldName, string condition=null, string subField=null)
        {
            List<string> fieldList = new List<string>();
            try
            {
                IFeatureClass featClass = featWorkSpace.OpenFeatureClass(fName);
                IFields fields = featClass.Fields;
                IQueryFilter pQueryFilter = new QueryFilterClass();
                pQueryFilter.WhereClause = condition;
                pQueryFilter.SubFields = subField;
                IFeatureCursor featCur = featClass.Search(pQueryFilter, true);
                IFeature feat = featCur.NextFeature();
                int index = fields.FindField(fieldName);
                while (feat != null)
                {
                    fieldList.Add(feat.get_Value(index).ToString());
                    feat = featCur.NextFeature();
                }
                return fieldList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 查询要素集合字段
        /// </summary>
        /// <param name="fName"></param>
        /// <returns></returns>
        public List<string> QueryFeatClassFields(string fName)
        {
            List<string> fieldLst = new List<string>();
            try
            {
                IFields fields = featWorkSpace.OpenFeatureClass(fName).Fields;
                for (int i = 0; i < fields.FieldCount; i++)
                {
                    fieldLst.Add(fields.Field[i].AliasName);
                }
                return fieldLst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 选择要素
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public List<IFeature> Query(string fName, string condition)
        {
            List<IFeature> featLst = new List<IFeature>();
            try
            {
                IFeatureClass featClass = featWorkSpace.OpenFeatureClass(fName);
                IFields fields = featClass.Fields;
                IQueryFilter pQueryFilter = new QueryFilterClass();
                pQueryFilter.WhereClause = condition;
                pQueryFilter.SubFields = "*";
                IFeatureCursor featCur = featClass.Search(pQueryFilter, true);
                IFeature feat = featCur.NextFeature();
                while (feat != null)
                {
                    featLst.Add(feat);
                    feat = featCur.NextFeature();
                }
                return featLst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 缩放至要素
        /// </summary>
        /// <param name="geom"></param>
        public void ZoomTo(IGeometry geom)
        {
            IEnvelope env = geom.Envelope;
            switch(geom.GeometryType)
            {
                case esriGeometryType.esriGeometryPoint:
                    env.Expand(0.8, 0.8, false);
                    break;
                case esriGeometryType.esriGeometryPolygon:
                    env.Expand(2, 2, true);
                    break;
                default:
                    break;
            }
            MapControl.Extent = env;
            MapControl.ActiveView.Refresh();
        }

        /// <summary>
        /// 选择并高亮要素
        /// </summary>
        /// <param name="lyr"></param>
        /// <param name="feature"></param>
        public void HightlightSelectedFeat(string  lyrName, IFeature feature)
        {
            try
            {
                for (int i = 0; i < MapControl.LayerCount; i++)
                {
                    var lyrItem = MapControl.get_Layer(i);
                    if (lyrItem.Name == lyrName)
                    {
                        MapControl.Map.SelectFeature(lyrItem, feature);
                        break;
                    }
                }

            }
            finally { }
        }
        /// <summary>
        ///获取地图图层
        /// </summary>
        /// <param name="fName"></param>
        /// <returns></returns>
        public ILayer GetLayerFromMap(string fName)
        {
            ILayer lyr = null;
            try
            {
                for (int i = 0; i < MapControl.LayerCount; i++)
                {
                    var lyrItem = MapControl.get_Layer(i);
                    if (lyrItem.Name == fName)
                    {
                        lyr = lyrItem;
                        break;
                    }
                }
                return lyr;
            }
            finally { }
        }
    }
}

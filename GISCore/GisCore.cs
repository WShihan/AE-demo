using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GISService.Interface;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using BasicService.Config;
using ESRI.ArcGIS.Controls;

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
            string gdb = _xmlReader.Read("config/data/gdb").InnerText;
            System.Type t = Type.GetTypeFromProgID("esriDataSourcesGDB.FileGDBWorkspaceFactory");
            System.Object obj = Activator.CreateInstance(t);
            IWorkspaceFactory workspaceFactory = obj as IWorkspaceFactory;
            IWorkspace workspace = workspaceFactory.OpenFromFile(gdb, 0);
            featWorkSpace = workspace as IFeatureWorkspace;
        }
        public List<string> QueryField(string fName,string fieldName, string condition=null, string subField=null)
        {
            List<string> fieldList = new List<string>();
            try
            {
                IFeatureClass featClass = featWorkSpace.OpenFeatureClass("YunnanRiver");
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
    }
}

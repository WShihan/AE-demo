using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicService.configratior;
namespace BasicService.GIS
{
    public class DBProvider
    {
        XMLReader _xmlReader = XMLReader.Instance;
        IFeatureWorkspace featWorkSpace;
        public IFeatureWorkspace workspace
        {
            get { return featWorkSpace; }
        }
        public DBProvider()
        {
            ConnectDB();
        }
        private void ConnectDB()
        {
            //打开gdb
            IWorkspaceFactory workSpaceFactory = new FileGDBWorkspaceFactory();
            string gdb = _xmlReader.Read("configuration/testData/gdb").InnerText;
            IWorkspace workSpace = workSpaceFactory.OpenFromFile(gdb, 0);
            featWorkSpace = workSpace as IFeatureWorkspace;
        }
    }
}

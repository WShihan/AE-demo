using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicService.GIS
{
    public class DBProvider
    {
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
            IWorkspace workSpace = workSpaceFactory.OpenFromFile(@"C:\Users\acer\source\repos\GISDemo\asset\data\db.gdb", 0);
            featWorkSpace = workSpace as IFeatureWorkspace;
        }
    }
}

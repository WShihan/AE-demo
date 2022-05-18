using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Geodatabase;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicService.Config;
using System;

namespace framework.db
{
    public class DBProvider
    {
        /// <summary>
        /// 配置
        /// </summary>
        XMLReader _xmlReader = XMLReader.Instance;
        /// <summary>
        /// sqlite
        /// </summary>
        private SQLiteConnection sqliteConn;
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
            string startPath = Application.StartupPath;
            // sqlite connection
            sqliteConn = new SQLiteConnection(@"C:\Users\Administrator\Desktop\AE-demo\asset\data\db.db");
            SQLiteDataAdapter sqliteAdpt = new SQLiteDataAdapter("select * from test", sqliteConn);
            ////打开gdb
            //string gdb = _xmlReader.Read("config/data/gdb").InnerText;
            //System.Type t = Type.GetTypeFromProgID("esriDataSourcesGDB.FileGDBWorkspaceFactory");
            //System.Object obj = Activator.CreateInstance(t);
            //IWorkspaceFactory workspaceFactory = obj as IWorkspaceFactory;
            //IWorkspace workspace = workspaceFactory.OpenFromFile(gdb, 0);
            //featWorkSpace = workspace as IFeatureWorkspace;
        }
    }
}

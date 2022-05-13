using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Geodatabase;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicService.configratior;
namespace BasicService.db
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
            sqliteConn = new SQLiteConnection(startPath + @"/asset/data/db.db");
            SQLiteDataAdapter sqliteAdpt = new SQLiteDataAdapter("select * from test", sqliteConn);
            //打开gdb
            IWorkspaceFactory workSpaceFactory = new FileGDBWorkspaceFactory();
            string gdb = _xmlReader.Read("config/data/gdb").InnerText;
            IWorkspace workSpace = workSpaceFactory.OpenFromFile(gdb, 0);
            featWorkSpace = workSpace as IFeatureWorkspace;
        }
    }
}

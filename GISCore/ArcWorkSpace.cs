using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;
using BasicService.Config;
using ESRI.ArcGIS.DataSourcesGDB;

namespace GISService
{
    public class ArcWorkSpace
    {
        private XMLReader _xmlReader = XMLReader.Instance;
        private IFeatureWorkspace featWorkSpace;
        public  ArcWorkSpace()
        {
            ////string gdb = _xmlReader.Read("config/data/gdb").InnerText;
            ////System.Type t = Type.GetTypeFromProgID("esriDataSourcesGDB.FileGDBWorkspaceFactory");
            ////System.Object obj = Activator.CreateInstance(t);
            ////IWorkspaceFactory workspaceFactory = obj as IWorkspaceFactory;
            ////IWorkspace workspace = workspaceFactory.OpenFromFile(gdb, 0);
            ////featWorkSpace = workspace as IFeatureWorkspace;
            //string gdb = _xmlReader.Read("config/data/gdb").InnerText;
            //IWorkspaceFactory workspaceFactory = new FileGDBWorkspaceFactoryClass();
            //IWorkspace workspace = workspaceFactory.OpenFromFile(gdb, 0);
            //featWorkSpace = workspace as IFeatureWorkspace;
        }
        public void Layers()
        {
             
        }
        /// <summary>
        /// 获取要素类
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IFeatureClass GetFeatClassByName(string name)
        {
            return featWorkSpace.OpenFeatureClass("YunnanRiver");
        }

    }
}

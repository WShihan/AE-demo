using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using BasicService.Config;
using GISService.Interface;

namespace GISService
{
    public class GISContext:IGISContext
    {
        private IEngineEditor _engineEditor;
        private IEngineEditTask _engineEditTask;
        private IActiveView _activeView;
        private IMap _map;
        private bool _editable = false;
        private ArcWorkSpace _wks = new ArcWorkSpace();
        private static GISContext editContextIns;
        private XMLReader _xmlReader = XMLReader.Instance;
        public static GISContext Instance
        {
            get
            {
                if (editContextIns == null)
                {
                    editContextIns = new GISContext();
                }
                return editContextIns;
            }
        }
        public IEngineEditor Editor
        {
            get { return _engineEditor; }
            set { _engineEditor = value; }
        }
        public IEngineEditTask EditTask
        {
            get { return _engineEditTask; }
            set { _engineEditTask = value; }
        }
        public IActiveView ActiveView
        {
            get { return _activeView; }
            set { _activeView = value; }
        }
        public IMap Map
        {
            get { return _map; }
            set { _map = value; }
        }

        public bool Editable {
            get { return false; }
            set { }
        }

        public ArcWorkSpace WorkSpace
        {
            get { return _wks; }
        }
    }
}

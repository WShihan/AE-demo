using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using framework.Interface;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;

namespace framework.Implementation
{
    public class EditContext:IEditContext
    {
        IEngineEditor _engineEditor;
        IEngineEditTask _engineEditTask;
        IActiveView _activeView;
        IMap _map;
        private static EditContext editContextIns;
        private EditContext()
        {

        }
        public static EditContext Instance
        {
            get
            {
                if (editContextIns == null)
                {
                    editContextIns = new EditContext();
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
            get { return _engineEditor as IEngineEditTask; }
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
        }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using framework.Interface;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;
using Process.MapOperation;
using ESRI.ArcGIS.Geodatabase;
using System.Windows.Forms;
using ESRI.ArcGIS.Display;
namespace edit.framework
{
    public class application:IContext
    {
        private IEngineEditor _engineEditor;
        private IMap _map;
        private IActiveView _activeView;
        private bool _editable;

        public  application(AxMapControl axMapControl)
        {
            _map = axMapControl.Map;
            _activeView = axMapControl.ActiveView;
            _engineEditor = new EngineEditor();
            _editable = false;

        }
        public  bool Editable
        {
            get { return _editable; }
            set { _editable = value; }
        }
        public IEngineEditor EngineEditor
        {
            get { return _engineEditor; }
        }
        public IMap Map
        {
            get { return _map; }
            set { _map = value; }
        }
    }
}

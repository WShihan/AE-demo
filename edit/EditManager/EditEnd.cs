using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Carto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Controls;

namespace edit.EditManager
{
    public class EditEnd
    {

        private IMap cMap;
        private IEngineEditor cEngineEditor;
        private IActiveView cActiveView;
        private bool _isSave = false;
        public EditEnd(IEngineEditor pEngineEditor, IActiveView pActiveView, IMap pMap, bool isSave)
        {
            cActiveView = pActiveView;
            cMap = pMap;
            cEngineEditor = pEngineEditor;
            _isSave = isSave;
        }
        /// <summary>
        /// 清除选择元素
        /// </summary>
        public void clear()
        {
            cEngineEditor.StopEditing(_isSave);
            cMap.ClearSelection();
            cActiveView.Refresh();
        }
    }
}

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Process.edit
{
    public class EditUndo
    {
        private IEngineEditor cEngineEditor;
        private IActiveView cActiveView;
        public EditUndo(IEngineEditor pEngineEditor, IActiveView pActiveView)
        {
            cEngineEditor = pEngineEditor;
            cActiveView = pActiveView;
        }
        public void Execute()
        {
            try
            {
                //EditVertexClass.ClearResource();
                if (cEngineEditor == null) return;
                if (cEngineEditor.EditState != esriEngineEditState.esriEngineStateEditing) return;
                IWorkspaceEdit2 pWSEdit = cEngineEditor.EditWorkspace as IWorkspaceEdit2;
                if (pWSEdit == null) return;
                Boolean bHasUndo = false;
                pWSEdit.HasUndos(ref bHasUndo);
                if (bHasUndo) pWSEdit.UndoEditOperation();
                cActiveView.Refresh();

            }
            catch (Exception ex)
            {
            }
        }
    }
}

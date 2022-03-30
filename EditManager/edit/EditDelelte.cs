using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using System.Windows.Forms;
using Manager.MapOperation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace Manager.edit
{
    public class EditDelelte
    {
        private IEngineEditor cEngineEditor;
        private IActiveView cActiveView;
        private IEngineEditLayers cEngineEditLayers;

        public EditDelelte(IEngineEditor ee, IEngineEditLayers eel,IActiveView av )
        {
            cEngineEditor = ee;
            cEngineEditLayers = eel;
            cActiveView = av;
        }
        public void Execute()
        {
            try
            {;
                if (cEngineEditor == null) return;
                if (cEngineEditor.EditState != esriEngineEditState.esriEngineStateEditing) return;
                if (cEngineEditLayers == null) return;
                IFeatureLayer pFeatLyr = cEngineEditLayers.TargetLayer;
                if (pFeatLyr == null) return;
                IFeatureClass pFeatCls = pFeatLyr.FeatureClass;
                if (pFeatCls == null) return;
                IFeatureCursor pFeatCur = MapManager.GetSelectedFeatures(pFeatLyr);
                if (pFeatCur == null)
                {
                    MessageBox.Show("请选择要删除的要素！", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                cEngineEditor.StartOperation();
                IFeature pFeature = pFeatCur.NextFeature();
                if (MessageBox.Show("是否删除所选要素？", "提示", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    while (pFeature != null)
                    {
                        pFeature.Delete();
                        pFeature = pFeatCur.NextFeature();
                    }
                }
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pFeatCur);
                cEngineEditor.StopOperation("DelFeatureCommand");
                cActiveView.Refresh();
            }
            catch (Exception ex)
            {

            }
        }
    }

}

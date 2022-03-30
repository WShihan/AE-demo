//using ESRI.ArcGIS.Carto;
//using ESRI.ArcGIS.Controls;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace edit.EditManager
//{
//    public class EditMoveVex
//    {
//        // 变量
//        private IEngineEditor cEngineEditor;
//        private IActiveView cActiveView;
//        private IMap cMap;
//        private IFeatureLayer cFeatLayer;
//        public  EditMoveVex()
//        {

//        }

//        private void  onClick()
//        {
//            EditVertexClass.m_activeView = cActiveView;
//            EditVertexClass.m_Map = m_Map;
//            EditVertexClass.ClearResource();
//            if (m_EngineEditor == null) return;
//            if (m_EngineEditor.EditState != esriEngineEditState.esriEngineStateEditing) return;
//            if (m_EngineEditLayers == null) return;
//            IFeatureLayer pFeatLyr = m_EngineEditLayers.TargetLayer;
//            if (pFeatLyr == null) return;
//            IFeatureCursor pFeatCur = MapManager.GetSelectedFeatures(pFeatLyr);
//            if (pFeatCur == null)
//            {
//                MessageBox.Show("请选择要编辑节点要素！", "提示",
//                    MessageBoxButtons.OK, MessageBoxIcon.Information);
//                return;
//            }
//            EditVertexClass.ShowAllVertex(pFeatLyr);
//            ((IActiveViewEvents_Event)m_Map).AfterDraw += new IActiveViewEvents_AfterDrawEventHandler(map_AfterDraw);
//        }
//    }
//}

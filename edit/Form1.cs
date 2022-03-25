﻿using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geometry;
using MapOperation;
using edit.EditManager;
using ESRI.ArcGIS.Display;

namespace edit
{
    public partial class edit : Form

    {
        // 编辑开关变量
        private bool _editStart = false;
        private bool _editSelect = false;
        private bool _editMove = false;
        private bool _editAdd = false;
        private bool _editDelete = false;
        private bool _editEnd = false;
        private int _editProcess = 0;
        private bool _isTest = false;


        private IEngineEditLayers curEngineEditLayer;
        private IMap curMap;

        // 编辑内容相关变量
        IEngineEditor curEngineEditor;
        IEngineEditTask curEditTask;
        IActiveView curActiveView;
        IMoveGeometryFeedback curMoveGeoFeedback;
        private IPoint fromPoint;
        private IPoint toPoint;

        #region 编辑步骤变量
        // 编辑步骤变量
        private EditSelect curEditSelect;
        private EditMove curEditMove;
        private EditAdd cEditAdd;
        #endregion

        public edit()
        {
            InitializeComponent();
            curMap = MapControl.Map;
            curActiveView = MapControl.ActiveView;
        }

        private void edit_Load(object sender, EventArgs e)
        {
            this.MapControl.AddShapeFile(@"C:\Users\Administrator\Desktop\TempData", "testPoly");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            curEngineEditor = new EngineEditorClass();
            IMap curMap = MapControl.Map as IMap;
            IFeatureLayer curlayer = MapControl.get_Layer(0) as IFeatureLayer;
            IDataset curDataSet = curlayer.FeatureClass as IDataset;
            IWorkspace cws = curDataSet.Workspace;
            curEngineEditor.EditSessionMode = esriEngineEditSessionMode.esriEngineEditSessionModeNonVersioned;
            curEditTask = curEngineEditor as IEngineEditTask;
            curEditTask = curEngineEditor.GetTaskByUniqueName("ControlToolsEditingCreateNewFeatureTask");
            curEngineEditor.CurrentTask = curEditTask;
            curEngineEditor.EnableUndoRedo(true);
            curEngineEditor.StartEditing(cws, curMap);
            // 设置编辑图层
            curEngineEditLayer = curEngineEditor as IEngineEditLayers;
            curEngineEditLayer.SetTargetLayer(curlayer, 0);
            _editStart = true;
            EditProcessChange(1);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (_editStart)
            {
                _editSelect = true;
                curEditSelect = new EditSelect(true, curEngineEditor, curEngineEditLayer, curActiveView, curMap);
                EditProcessChange(2);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _editStart = false;
            MapControl.Map.FeatureSelection.CanClear();
            MapControl.ActiveView.FocusMap.ClearSelection();
            MapControl.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            
        }

        private void MapControl_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 2)
            {
                MapControl.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerHand;
                MapControl.Pan();
                // 鼠标样式复原为箭头型
                MapControl.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerArrow;
            }
           if (e.button == 1)
            {
                // 选择
                if (_editStart)
                {
                    MapControl.Map.ClearSelection();
                    MapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                    if (_editSelect)
                    {
                        curEditSelect.SelectFeat(e.x, e.y);
                    }
                }
                // 测试
                if (_isTest)
                {
                    Test(e.x, e.y);
                }
                // 移动
                if (_editMove)
                {
                    if (_editStart)
                    {
                        curEditMove.OnMouseDown(1, 0, e.x, e.y);
                    }
                }
                // 添加
                if (_editAdd)
                {
                    cEditAdd.CaptureDown(1, 0, e.x, e.y);
                }
            }
        }



        private void MapControl_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (_editMove)
            {
                curEditMove.OnMouseMove(1, 0, e.x, e.y);
            }
            if (_editAdd)
            {
                cEditAdd.CaptureMove(1, 0, e.x, e.y);
            }
        }

        private void MapControl_OnMouseUp(object sender, IMapControlEvents2_OnMouseUpEvent e)
        {
            if (_editMove)
            {
                curEditMove.OnMouseUp(1, 0, e.x, e.y);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// 改变按钮颜色
        /// </summary>
        /// <param name="i"></param>
        private void EditProcessChange(int i)
        {
            switch (i)
            {
                case 1:
                    {
                        btnStart.BackColor = System.Drawing.Color.FromArgb(255, 0, 0);
                        break;
                    }
                case 2:
                    {
                        btnSelect.BackColor = System.Drawing.Color.FromArgb(255, 0, 0);
                        break;
                    }
                case 3:
                    {
                        btnMove.BackColor = System.Drawing.Color.FromArgb(255, 0, 0);
                        break;
                    }
                case 4:
                    {
                        btnTest.BackColor = System.Drawing.Color.FromArgb(255, 0, 0);
                        break;
                    }
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            _isTest = true;
            EditProcessChange(4);
        }

        private void Test(int x, int y)
        {

        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            _editMove = true;
            curEditMove = new EditMove(curEngineEditor, curEngineEditLayer, curActiveView, curMap, curMoveGeoFeedback);
            EditProcessChange(3);
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            
            EditEnd cEditEnd = new EditEnd(curEngineEditor, curActiveView, curMap, false);
            cEditEnd.clear();
            MessageBox.Show("保存成功");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (_editStart)
            {
                _editAdd = true;
                cEditAdd = new EditAdd(curEngineEditor, curEngineEditLayer, curActiveView, curActiveView.FocusMap);
            }
        }

        private void MapControl_OnDoubleClick(object sender, IMapControlEvents2_OnDoubleClickEvent e)
        {
            cEditAdd.CaptureDblClick();
        }
    }
}

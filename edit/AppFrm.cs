using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using System;
using System.Collections.Generic;
using framework.Implementation;
using BasicService.GIS;
using ESRI.ArcGIS.Geodatabase;
using BasicService.configratior;
using System.Windows.Forms;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using framework.Interface;
using Process.edit;
using System.Data;
using edit.UI;

namespace edit
{
    public partial class AppFrm : Form

    {
        private XMLReader xmlReader;
        private DBProvider dbProvide;
        // 编辑开关变量
        private bool _editStart = false;
        private bool _editSelect = false;
        private bool _editMove = false;
        private bool _editAdd = false;
        private bool _editDelete = false;
        private bool _editEnd = false;
        private int _editProcess = 0;
        private bool _isTest = false;

        #region 编辑步骤变量
        // 编辑步骤变量
        private EditSelect curEditSelect;
        private EditMove curEditMove;
        private EditAdd cEditAdd;
        private EditUndo cEditUndo;
        private EditDelelte cEditDelete;
        #endregion

        // IOC容器
        IOContainer ioc =IOContainer.InStance;
        IApp app;

        // 编辑内容相关变量
        private IEngineEditLayers editLayer;
        IEditContext editConxt;
        IMoveGeometryFeedback curMoveGeoFeedback;
        private IPoint fromPoint;
        private IPoint toPoint;

        public AppFrm()
        {
            InitializeComponent();
            app = new App();
            editConxt = app.EditContextIns;
            editConxt.Map = MapControl.Map;
            editConxt.ActiveView = MapControl.ActiveView;
            editConxt.Map = MapControl.Map;
            editConxt.Editor = new EngineEditor();
        }

        private void AppFrm_Load(object sender, EventArgs e)
        {
            dbProvide = new DBProvider();
            xmlReader = XMLReader.Instance;

            MapControl.AddShapeFile(xmlReader.Read("/configuration/testData/Line").Attributes["path"].Value, "testLine");
            //IFeatureClass featClass = dbProvide.workspace.OpenFeatureClass("Yunnan");
            //ILayer lyr;
            //IFeatureLayer featLyr = new FeatureLayerClass();
            //featLyr.FeatureClass = featClass;
            //lyr = featLyr as ILayer;
            //lyr.Name = "云南";
            //MapControl.AddLayer(lyr);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            IFeatureLayer curlayer = MapControl.get_Layer(2) as IFeatureLayer;
            IDataset curDataSet = curlayer.FeatureClass as IDataset;
            IWorkspace cws = curDataSet.Workspace;
            editConxt.Editor.EditSessionMode = esriEngineEditSessionMode.esriEngineEditSessionModeNonVersioned;
            editConxt.EditTask = editConxt.Editor as IEngineEditTask;
            editConxt.EditTask = editConxt.Editor.GetTaskByUniqueName("ControlToolsEditingCreateNewFeatureTask");
            editConxt.Editor.CurrentTask = editConxt.EditTask;
            editConxt.Editor.EnableUndoRedo(true);
            editConxt.Editor.StartEditing(cws, editConxt.Map);
            // 设置编辑图层
            editLayer = editConxt.Editor as IEngineEditLayers;
            editLayer.SetTargetLayer(curlayer, 0);
            _editStart = true;
            EditProcessChange(1);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (_editStart)
            {
                _editMove = false;
                _editSelect = true;
                curEditSelect = new EditSelect(true, editConxt.Editor, editLayer, editConxt.ActiveView, editConxt.Map);
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
            if (e.button == 4)
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
                        curEditSelect.OnMouseDown(0, 0, e.x, e.y);
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
                    cEditAdd.OnMouseDown(1, 0, e.x, e.y);
                }
            }
        }

        private void SetMapInfo(double x, double y)
        {
            #region 获取鼠标坐标和地图尺寸单位
            // 获取比例尺数据
            string unit = "";
            double scale = 0;
            if (MapControl.Map != null)
            {
                scale = MapControl.Map.MapScale;
                unit = MapControl.MapUnits.ToString().Substring(4);
            }
            string coordinate = string.Format(
                "{0},{1}", x.ToString("#######.##"),
                y.ToString("#######.##"));
            // 设置比例尺和鼠标点坐标
            tbCoord.Text = coordinate;
            tbScale.Text = "1:" + scale.ToString("######.###");
            #endregion
        }

        private void MapControl_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            SetMapInfo(e.mapX, e.mapY);
            if (_editMove)
            {
                curEditMove.OnMouseMove(1, 0, e.x, e.y);
            }
            if (_editAdd)
            {
                cEditAdd.OnMouseMove(1, 0, e.x, e.y);
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
                        tsbStart.BackColor = System.Drawing.Color.FromArgb(255, 0, 0);
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
            IFeatureClass featClass = dbProvide.workspace.OpenFeatureClass("YunnanRiver");
            IFields fields = featClass.Fields;
            Frm frm = new Frm();
            IQueryFilter pQueryFilter = new QueryFilterClass();
            pQueryFilter.WhereClause = " name LIKE '%南%'";
            IFeatureCursor pFeatureCursor = featClass.Search(pQueryFilter, false);
            IFeature pFeatureIfExit = pFeatureCursor.NextFeature();
            List<IFeature> featList = new List<IFeature>();
            List<string> fieldList = new List<string>();

            DataTable dt = new DataTable();
            dt.Columns.Add("名称", typeof(string));
            int index = featClass.FindField("name");

            for (int i = 0; i < featClass.Fields.FieldCount; i++)
            {
                fieldList.Add(featClass.Fields.get_Field(i).Name);
            }
            while (pFeatureIfExit != null)
            {
                DataRow dr = dt.NewRow();
                featList.Add(pFeatureIfExit);
                dr["名称"] = pFeatureIfExit.get_Value(index);
                dt.Rows.Add(dr);
                pFeatureIfExit = pFeatureCursor.NextFeature();
            }
            frm.dgv.DataSource = dt;
            frm.dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            frm.dgv.CellDoubleClick += Dgv_CellDoubleClick;
            frm.Show(this);
            EditProcessChange(4);
        }

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Test(int x, int y)
        {

        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            _editSelect = true;
            _editMove = true;
            _editAdd = false;
            curEditMove = new EditMove(editConxt.Editor, editLayer, editConxt.ActiveView, editConxt.Map, curMoveGeoFeedback);
            EditProcessChange(3);
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            
            EditEnd cEditEnd = new EditEnd(editConxt.Editor, editConxt.ActiveView, editConxt.Map, true);
            cEditEnd.onClick();
            MessageBox.Show("保存成功");
        }

        private void MapControl_OnDoubleClick(object sender, IMapControlEvents2_OnDoubleClickEvent e)
        {
            if (_editMove)
            {
                cEditAdd.CaptureDblClick();
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            cEditUndo = new EditUndo(editConxt.Editor, editConxt.ActiveView);
            cEditUndo.Execute();
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            cEditDelete = new EditDelelte(editConxt.Editor, editLayer, editConxt.ActiveView);
            cEditDelete.OnMouseDown(0, 0, 0, 0);
        }

        private void tsbStart_Click(object sender, EventArgs e)
        {
            IEngineEditor curEngineEditor = editConxt.Editor;
            IFeatureLayer curlayer = MapControl.get_Layer(0) as IFeatureLayer;
            IDataset curDataSet = curlayer.FeatureClass as IDataset;
            IWorkspace cws = curDataSet.Workspace;
            curEngineEditor.EditSessionMode = esriEngineEditSessionMode.esriEngineEditSessionModeNonVersioned;
            IEngineEditTask curEditTask = curEngineEditor as IEngineEditTask;
            curEditTask = curEngineEditor.GetTaskByUniqueName("ControlToolsEditingCreateNewFeatureTask");
            curEngineEditor.CurrentTask = curEditTask;
            curEngineEditor.EnableUndoRedo(true);
            curEngineEditor.StartEditing(cws, editConxt.Map);
            // 设置编辑图层
            editLayer = curEngineEditor as IEngineEditLayers;
            editLayer.SetTargetLayer(curlayer, 0);
            _editStart = true;
            EditProcessChange(1);
            SetBtnAbility(true);
        }
        private void SetBtnAbility(bool flag)
        {
            btnDelete.Enabled = flag;
            btnMove.Enabled = flag;
            btnUndo.Enabled = flag;
            btnRedo.Enabled = flag;
            btnSelect.Enabled = flag;
            btnAdd.Enabled = flag;
            tsbEnd.Enabled = flag;
            tsbSave.Enabled = flag;
        }

        private void tsbEnd_Click(object sender, EventArgs e)
        {
            EditEnd cEditEnd = new EditEnd(editConxt.Editor, editConxt.ActiveView, editConxt.Map, true);
            cEditEnd.onClick();
            MessageBox.Show("保存成功");
            SetBtnAbility(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_editStart)
            {
                _editMove = false;
                _editSelect = false;
                _editAdd = true;
                cEditAdd = new EditAdd(editConxt.Editor, editLayer, editConxt.ActiveView, editConxt.ActiveView.FocusMap);
                MessageBox.Show(cEditAdd.Name);
            }
        }

        private void btnIOC_Click(object sender, EventArgs e)
        {
            ioc.Register<IXMLReader, XMLReader>();
            //EditSelect select = ioc.Resolve<EditSelect>();
            XMLReader xmlread = ioc.Resolve<XMLReader>();

        }
    }
}

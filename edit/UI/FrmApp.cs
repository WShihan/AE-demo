using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using System;
using System.Collections.Generic;
using framework.Implementation;
using ESRI.ArcGIS.Geodatabase;
using BasicService.Config;
using System.Windows.Forms;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using framework.Interface;
using Process.edit;
using System.Data;
using app.Test;
using framework.db;
using GISService.Interface;
using GISService;
using GISService.edit;

namespace app.UI
{
    public partial class FrmApp : Form

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
        //IOContainer ioc =IOContainer.InStance;
        IApp app;

        // 编辑内容相关变量
        private IEngineEditLayers editLayer;
        private IGISContext gisContext;
        private IMoveGeometryFeedback curMoveGeoFeedback;
        private IPoint fromPoint;
        private IPoint toPoint;

        public FrmApp()
        {
            InitializeComponent();
            app = new App();
            gisContext = app.GISCore.GisContext;
            app.GISCore.MapControl = MapControl;
            gisContext.Map = MapControl.Map;
            gisContext.ActiveView = MapControl.ActiveView;
            gisContext.Map = MapControl.Map;
            gisContext.Editor = new EngineEditor();
        }

        private void AppFrm_Load(object sender, EventArgs e)
        {
            dbProvide = new DBProvider();
            xmlReader = XMLReader.Instance;
            string mxdPath = xmlReader.Read("/config/data/mxd").InnerText;
            MapControl.LoadMxFile(mxdPath);

            //MapControl.AddShapeFile(xmlReader.Read("/config/data/path").InnerText, "testLine");
            //IFeatureClass featClass = dbProvide.workspace.OpenFeatureClass("Yunnan");
            //ILayer lyr;
            //IFeatureLayer featLyr = new FeatureLayerClass();
            //featLyr.FeatureClass = featClass;
            //lyr = featLyr as ILayer;
            //lyr.Name = "云南";
            //MapControl.AddLayer(lyr);

            // 加载完
            MapControl.OnAfterDraw += MapControl_OnAfterDraw;
        }

        private void MapControl_OnAfterDraw(object sender, IMapControlEvents2_OnAfterDrawEvent e)
        {
            MapControl.OnMouseMove += MapControl_OnMouseMove;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            IFeatureLayer curlayer = MapControl.get_Layer(2) as IFeatureLayer;
            IDataset curDataSet = curlayer.FeatureClass as IDataset;
            IWorkspace cws = curDataSet.Workspace;
            gisContext.Editor.EditSessionMode = esriEngineEditSessionMode.esriEngineEditSessionModeNonVersioned;
            gisContext.EditTask = gisContext.Editor as IEngineEditTask;
            gisContext.EditTask = gisContext.Editor.GetTaskByUniqueName("ControlToolsEditingCreateNewFeatureTask");
            gisContext.Editor.CurrentTask = gisContext.EditTask;
            gisContext.Editor.EnableUndoRedo(true);
            gisContext.Editor.StartEditing(cws, gisContext.Map);
            // 设置编辑图层
            editLayer = gisContext.Editor as IEngineEditLayers;
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
                curEditSelect = new EditSelect(true, gisContext.Editor, editLayer, gisContext.ActiveView, gisContext.Map);
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
            try
            {
                FrmQueryField frm = new FrmQueryField(app);
                frm.Show(this);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void Test(int x, int y)
        {

        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            _editSelect = true;
            _editMove = true;
            _editAdd = false;
            curEditMove = new EditMove(gisContext.Editor, editLayer, gisContext.ActiveView, gisContext.Map, curMoveGeoFeedback);
            EditProcessChange(3);
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            
            EditEnd cEditEnd = new EditEnd(gisContext.Editor, gisContext.ActiveView, gisContext.Map, true);
            cEditEnd.onClick();
            MessageBox.Show("保存成功");
        }

        private void MapControl_OnDoubleClick(object sender, IMapControlEvents2_OnDoubleClickEvent e)
        {
            if (_editAdd)
            {
                cEditAdd.CaptureDblClick();
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            cEditUndo = new EditUndo(gisContext.Editor, gisContext.ActiveView);
            cEditUndo.Execute();
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            cEditDelete = new EditDelelte(gisContext.Editor, editLayer, gisContext.ActiveView);
            cEditDelete.OnMouseDown(0, 0, 0, 0);
        }

        private void tsbStart_Click(object sender, EventArgs e)
        {
            try
            {
                IEngineEditor curEngineEditor = gisContext.Editor;
                IFeatureLayer curlayer = MapControl.get_Layer(0) as IFeatureLayer;
                IDataset curDataSet = curlayer.FeatureClass as IDataset;
                IWorkspace cws = curDataSet.Workspace;
                var fact = cws.WorkspaceFactory.WorkspaceType;
                curEngineEditor.EditSessionMode = esriEngineEditSessionMode.esriEngineEditSessionModeNonVersioned;
                IEngineEditTask curEditTask = gisContext.Editor as IEngineEditTask;
                curEditTask = curEngineEditor.GetTaskByUniqueName("ControlToolsEditingCreateNewFeatureTask");
                curEngineEditor.CurrentTask = curEditTask;
                curEngineEditor.EnableUndoRedo(true);
                curEngineEditor.StartEditing(cws, gisContext.Map);
                // 设置编辑图层
                editLayer = curEngineEditor as IEngineEditLayers;
                editLayer.SetTargetLayer(curlayer, 0);
                _editStart = true;
                EditProcessChange(1);
                SetBtnAbility(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
            EditEnd cEditEnd = new EditEnd(gisContext.Editor, gisContext.ActiveView, gisContext.Map, true);
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
                cEditAdd = new EditAdd(gisContext.Editor, editLayer, gisContext.ActiveView, gisContext.ActiveView.FocusMap);
            }
        }

        private void btnIOC_Click(object sender, EventArgs e)
        {
            //ioc.Register<IXMLReader, XMLReader>();
            ////EditSelect select = ioc.Resolve<EditSelect>();
            //XMLReader xmlread = ioc.Resolve<XMLReader>();

        }
    }
}

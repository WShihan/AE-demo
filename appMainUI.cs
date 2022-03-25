using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using System.IO;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Controls;

namespace GISDemo
{
    public partial class appMainUI : Form
    {
        // 要素选择模式
        private bool _SelectFeatMod = false;

        private bool _selectByPoint = false;
        // 右键浏览模式
        private bool _isPan = true;
        // 点选要素模式
        private bool _pointSelectMod = false;
        #region 编辑模式相关变量
        // 编辑模式
        private bool _editMod = false;
        // 编辑图层
        private IEngineEditLayers curEngineEditLayer;
        // 编辑任务
        private IEngineEditTask curEditorTask;
        IEngineEditor curEngineEditor;
        #endregion
        public appMainUI()
        {
            InitializeComponent();
        }

        private void appMainUI_Load(object sender, EventArgs e)
        {
            // 修改初始化大小
            this.Width = 960;
            this.Height = 540;
            
            LoadData();
        }
        /// <summary>
        /// 添加数据
        /// </summary>
        private void LoadData()
        {
            try
            {
                #region 加载本地mxd
                // 加载本地mxd
                string mxdPath = @"C:\Users\Administrator\Desktop\TempData\北京.mxd";
                // 检查文件是否有效
                //if (this.MapControl.CheckMxFile(mxdPath))
                //{
                //    this.MapControl.LoadMxFile(mxdPath);
                //}

                //IMapDocument curMapDocument = new MapDocument();
                //curMapDocument.Open(mxdPath, "");
                //MapControl.Map = curMapDocument.ActiveView.FocusMap;
                //MapControl.ActiveView.Refresh();


                #endregion
                //加载shapfile文件
                #region 加载shapfile数据
                // 一种通过地图控件的AddShapFile添加
                this.MapControl.AddShapeFile(@"./data", "testPoint");
                // 另一种通过IWorkSpace添加

                // 第二种通过创建工作空间，数据集，图层，要素等添加
                //IWorkspaceFactory curWorkSpaceF;
                //IFeatureWorkspace curFeatWorkSpace;
                //IFeatureLayer curfeatureLayer;
                //curWorkSpaceF = new ShapefileWorkspaceFactory();
                //curFeatWorkSpace = (IFeatureWorkspace)curWorkSpaceF.OpenFromFile(@"./data", 0);
                //IFeatureClass curFeatClass = curFeatWorkSpace.OpenFeatureClass("testData");
                //curfeatureLayer = new FeatureLayer();
                //curfeatureLayer.FeatureClass = curFeatClass;
                //curfeatureLayer.Name = curfeatureLayer.FeatureClass.AliasName;
                //MapControl.Map.AddLayer(curfeatureLayer);
                //MapControl.ActiveView.Refresh();

                #endregion

            }
            catch (Exception res)
            {
                DialogResult dialogRes = MessageBox.Show("程序异常：" + res.ToString());
            }
        }
        /// <summary>
        /// 坐标点结构
        /// </summary>
        public struct CPoint
        {
            public string name;
            public double x;
            public double y;
        }

        /// <summary>
        /// 读取csv文件并生成点列表
        /// </summary>
        /// <returns></returns>
        public List<CPoint> LoadFromCsv()
        {
            try
            {
                Dictionary<List<string>, List<CPoint>> pointDic = new Dictionary<List<string>, List<CPoint>>();
                List<CPoint> PointList = new List<CPoint>();
                double[] xLIst = new double[1];
                char[] charArray = new char[] { };
                System.IO.FileStream fs = new System.IO.FileStream(@"C:\Users\Administrator\Desktop\AE-demo-master\bin\x86\Debug\data\test.csv", FileMode.Open);
                StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("GBK"));
                string line = sr.ReadLine();

                if (line != null)
                {
                    string[] Fields = line.Split(',');

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] rowArr = line.Split(',');
                        CPoint curPoint = new CPoint();
                        curPoint.name = rowArr[1];
                        curPoint.x = Convert.ToDouble(rowArr[2]);
                        curPoint.y = Convert.ToDouble(rowArr[3]);
                        PointList.Add(curPoint);
                    }

                }
                else
                {
                    return null;
                }
                
                foreach (var p in PointList)
                {
                    Console.WriteLine($"name:{p.name} x:{p.x} y:{p.y}");
                }
                sr.Close();
                return PointList;
            }
            catch (Exception ex)
            {
                DialogResult dr = MessageBox.Show("出错：" + ex.ToString());
                return null;
            }
        }


        /// <summary>
        /// 生成点shapefile图层
        /// </summary>
        /// <param name="cPoint"></param>
        /// <returns></returns>
        private IFeatureLayer GenerateShpFromPoint(List<CPoint> cPoint)
        {
            IWorkspaceFactory wsf = new ShapefileWorkspaceFactoryClass();
            IFeatureWorkspace fws = (IFeatureWorkspace)wsf.OpenFromFile(@"C:\Users\Administrator\Desktop\TempData\", 0);
            IFields pFields = new FieldsClass();
            IField pField = new FieldClass();
            IFieldsEdit pFieldsEdit = (IFieldsEdit)pFields;
            IFieldEdit pFieldEdit = (IFieldEdit)pField;
            pFieldEdit.Name_2 = "Shape";
            pFieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;
            IGeometryDef pGeometryDef = new GeometryDefClass();
            IGeometryDefEdit pGeoMetryDefEdit = (IGeometryDefEdit)pGeometryDef;
            pGeoMetryDefEdit.GeometryType_2 = ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint;
            // 定义坐标系
            ISpatialReferenceFactory pSRF = new SpatialReferenceEnvironmentClass();
            ISpatialReference pSpatialReference = pSRF.CreateGeographicCoordinateSystem((int)esriSRGeoCSType.esriSRGeoCS_WGS1984);
            pGeoMetryDefEdit.SpatialReference_2 = pSpatialReference;
            pFieldEdit.GeometryDef_2 = pGeometryDef;
            pFieldsEdit.AddField(pField);
            IFeatureClass pFeatureClass;
            pFeatureClass = fws.CreateFeatureClass("点测试", pFields, null, null, esriFeatureType.esriFTSimple, "Shape", "");
            IPoint pPoint = new PointClass();
            for (int j = 0; j < cPoint.Count; j++)
            {
                pPoint.X = cPoint[j].x;
                pPoint.Y = cPoint[j].y;
                IFeature pFeature = pFeatureClass.CreateFeature();
                pFeature.Shape = pPoint;
                pFeature.Store();
            }
            IFeatureLayer pFeatureLayer = new FeatureLayerClass();
            pFeatureLayer.Name = "点测试";
            pFeatureLayer.FeatureClass = pFeatureClass;
            return pFeatureLayer;
        }

        /// <summary>
        /// 保存地图文档
        /// </summary>
        private void SaveMXDDoc()
        {
            // 保持地图文档
            string mxdFileName = MapControl.DocumentFilename;
            IMapDocument pMapDocument = new MapDocumentClass();
            if (mxdFileName != null && MapControl.CheckMxFile(mxdFileName))
            {
                MessageBox.Show("地图文档为：" + mxdFileName);
            }
            else
            {
                pMapDocument.New(@"C:\Users\Administrator\Desktop\TempData\Save.mxd");
                pMapDocument.ReplaceContents(MapControl.Map as IMxdContents);
                pMapDocument.Save(pMapDocument.UsesRelativePaths, true);
                pMapDocument.Close();
            }

            // 另存地图文档
            //IMapDocument pMapdocument = new MapDocumentClass();
            //pMapdocument.New(@"C:\Users\Administrator\Desktop\TempData\SaveAs.mxd");
            //pMapdocument.ReplaceContents(MapControl.Map as IMxdContents);
            //pMapdocument.Save(true, true);
            //pMapdocument.Close();
        }
        /// <summary>
        /// 放大/缩小
        /// </summary>
        /// <param name="ratioX"></param>
        /// <param name="ratioY"></param>
        private void  ZoomInOrOut(double ratioX, double ratioY)
        {
            // 固定比例放大
            //IEnvelope pEnvelope;
            //pEnvelope = MapControl.Extent;
            //pEnvelope.Expand(ratioX, ratioY, true);// 小数放大，整数缩小
            //MapControl.Extent = pEnvelope;
            //MapControl.ActiveView.Refresh();

            //  固定比例缩小， 以当前视图中心为缩放中心
            IActiveView pActiveView = MapControl.ActiveView;
            IPoint centerPoint = new PointClass();
            centerPoint.PutCoords((pActiveView.Extent.XMin + pActiveView.Extent.XMax) / 2, (pActiveView.Extent.YMin = pActiveView.Extent.YMax) / 2);
            IEnvelope pEnvelope = pActiveView.Extent;
            pEnvelope.Expand(1.5, 1.5, true);
            pActiveView.Extent = pEnvelope;
            pActiveView.Refresh();
        }
        /// <summary>
        /// 拉框放大/缩小
        /// </summary>
        private void ZoomInOrOutByRect()
        {
            IEnvelope pEnvelop;
            pEnvelop = MapControl.TrackRectangle();
            IActiveView pActiiveView = MapControl.ActiveView;
            // 拉框放大
            //if (pEnvelop == null && pEnvelop.IsEmpty || pEnvelop.Height == 0 || pEnvelop.Width == 0)
            //{
            //    return;
            //}
            //else
            //{
            //    pActiiveView.Extent = pEnvelop;
            //    pActiiveView.Refresh();
            //}

            // 缩小
            double dWidth = pActiiveView.Extent.Width * pActiiveView.Extent.Width / pEnvelop.Width;
            double dHeight = pActiiveView.Extent.Height * pActiiveView.Extent.Height / pEnvelop.Height;
            double dXmin = pActiiveView.Extent.XMin - ((pEnvelop.XMin - pActiiveView.Extent.XMin) * pActiiveView.Extent.Width / pEnvelop.Width);
            double dYmin = pActiiveView.Extent.YMin - ((pEnvelop.YMin - pActiiveView.Extent.YMin) * pActiiveView.Extent.Height / pEnvelop.Height);
            double dXmax = dXmin + dWidth;
            double dYmax = dYmin + dHeight;
            pEnvelop.PutCoords(dXmin, dYmin, dXmax, dYmax);
            pActiiveView.Extent = pEnvelop;
            pActiiveView.Refresh();
        }
        
        private void btnSelect_Click(object sender, EventArgs e)
        {
            
            if (_SelectFeatMod == false && _pointSelectMod == false)
            {
                //_pointSelectMod = true;
                _SelectFeatMod = true; // 只能开启一个
                btnSelectFeat.Text = "清除";
                _editMod = false;
            }
            else
            {
                // 矩形框选择
                btnSelectFeat.Text = "矩形框要素选择";
                IActiveView pActiveView = MapControl.ActiveView;
                pActiveView.FocusMap.ClearSelection();
                pActiveView.PartialRefresh(
                    esriViewDrawPhase.esriViewGeoSelection, null, pActiveView.Extent
                    );
                _SelectFeatMod = false;
                _editMod = false;
                _pointSelectMod = false;
            }
        }
        /// <summary>
        /// 测量
        /// </summary>
        private void Measuring()
        {
            IPoint pPoint = null;
            double dTotalLength = 0;
            double dSegmentLength = 0;
            IPointCollection pAreaPointCol = new MultipointClass();
            MapControl.CurrentTool = null;
            MapControl.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerCrosshair;
            #region 线段长度测量
            INewLineFeedback pNewlineFeedback;
            pNewlineFeedback = new NewLineFeedbackClass();
            pNewlineFeedback.Display = (MapControl.Map as IActiveView).ScreenDisplay;
            //set start point
            pNewlineFeedback.Start(pPoint);
            dTotalLength = 0;
            if (dTotalLength != 0)
            {
                dTotalLength += dSegmentLength;
            }
            #endregion
        }

        private void MapControl_OnMouseMove(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseMoveEvent e)
        {
            #region 获取鼠标坐标和地图尺寸单位
            // 获取比例尺数据
            double scale = MapControl.Map.MapScale;
            string coordinate = string.Format(
                "{0},{1}", e.mapX.ToString("#######.##"),
                e.mapY.ToString("#######.##"));
            string unite = MapControl.MapUnits.ToString().Substring(4);
            // 设置比例尺和鼠标点坐标
            tbCoord.Text = coordinate;
            tbScale.Text = "1:" + scale.ToString("######.###");
            #endregion

            #region 编辑状态

            #endregion
        }

        private void MapControl_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            #region 地图平移
            if (e.button == 2 && _isPan ==true)
            {
                MapControl.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerHand;
                MapControl.Pan();
                // 鼠标样式复原为箭头型
                MapControl.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerArrow;
            }
            #endregion
            #region 拉框选择
            if (_SelectFeatMod)
            {
                // 矩形框选择要素
                IActiveView pactiveView = MapControl.ActiveView;
                IEnvelope pEnv = MapControl.TrackRectangle();
                IGeometry pGeom = pEnv as IGeometry;
                if (pEnv.IsEmpty)
                {
                    tagRECT r;
                    r.left = e.x - 5;
                    r.top = e.y - 5;
                    r.right = e.x + 5;
                    r.bottom = e.y + 5;
                    pactiveView.ScreenDisplay.DisplayTransformation.TransformRect(pEnv, ref r, 4);
                    pEnv.SpatialReference = pactiveView.FocusMap.SpatialReference;

                }
                pGeom = pEnv as IGeometry;
                MapControl.Map.SelectByShape(pGeom, null, false);
                MapControl.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            }

            #endregion
            if (_editMod && e.button == 1)
            {
                MapControl.Map.ClearSelection();
                MapControl.ActiveView.FocusMap.ClearSelection();
                OnMouseDownnWhileEdit(1, 0, e.x, e.y);
            }
            if (_selectByPoint)
            {
                MapControl.Map.FeatureSelection.Clear();
                IPoint selectPoint = new PointClass();
                selectPoint.PutCoords(e.x, e.y);
                MapControl.Map.SelectByShape(selectPoint as IGeometry, null, false);
                MapControl.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            }
        }

        private void MapControl_OnMouseUp(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseUpEvent e)
        {
            if (e.button == 2)
            {
                MapControl.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerArrow;
            }
        }

        private void btnLoadCSV_Click(object sender, EventArgs e)
        {

        }

        private void TocControl_OnMouseDown(object sender, ESRI.ArcGIS.Controls.ITOCControlEvents_OnMouseDownEvent e)
        {
            IFeatureLayer tocFeatLayer = null;
            ILayer moveLayer;
            int toIndex;
            if (e.button == 2)
            {
                esriTOCControlItem pItem = esriTOCControlItem.esriTOCControlItemNone;
                IBasicMap pMap = null;object unk = null;
                object data = null;ILayer pLayer = null;
                TocControl.HitTest(e.x, e.y, ref pItem, ref pMap,ref pLayer, ref unk, ref data);
                tocFeatLayer = pLayer as IFeatureLayer;
                if (pItem == esriTOCControlItem.esriTOCControlItemLayer && tocFeatLayer != null)
                {
                    ContextMenuStrip.Show(Control.MousePosition);
                }
            }
        }
        /// <summary>
        /// 选择并高亮元素
        /// </summary>
        private void SelectAndHighlightFeature()
        {
            // 获取第一个图层
            ILayer curLayer = MapControl.get_Layer(0);
            IFeatureLayer curFeatureLayer;
            curFeatureLayer = curLayer as IFeatureLayer;
            IFeatureSelection featSelection = curFeatureLayer as IFeatureSelection;
            IQueryFilter queryFilter = new QueryFilterClass();
            queryFilter.WhereClause = "SELECT * FROM testPoint WHERE pop > 4;";
            IActiveView curActiveView = MapControl.Map as IActiveView;
            featSelection.SelectFeatures(queryFilter, esriSelectionResultEnum.esriSelectionResultAdd, false);
            curActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, curActiveView.Extent);

        }

        /// <summary>
        /// 获取几何类型
        /// </summary>
        /// <param name="featureLayer"></param>
        /// <returns></returns>
        private IGeometry GetFeatureLayerGeometry(IFeatureLayer featureLayer)
        {
            IGeometry geom = null;
            ITopologicalOperator topoOperator;
            IFeatureCursor featCursor = featureLayer.Search(null, false);
            // 获取IFeature接口中第一个元素
            IFeature feat = featCursor.NextFeature();
            while (feat != null)
            {
                if (geom != null)
                {
                    topoOperator = geom as ITopologicalOperator;
                    geom = topoOperator.Union(feat.Shape);

                }
                else
                {
                    geom = feat.Shape;
                }
                feat = featCursor.NextFeature();
            }
            return geom;
        }
        /// <summary>
        /// 空间位置查询
        /// </summary>
        private void SelectByLocation()
        {
            ILayer layer=  MapControl.get_Layer(0);
            IFeatureLayer curFeatLayer = layer as IFeatureLayer;
            ISpatialFilter spatialfilter = new SpatialFilterClass();
            spatialfilter.Geometry = GetFeatureLayerGeometry(curFeatLayer);

        }

        private void btnHighlight_Click(object sender, EventArgs e)
        {
            SelectAndHighlightFeature();
        }

        private void btnSelectByLocation_Click(object sender, EventArgs e)
        {
            _selectByPoint = true;

        }

        /// <summary>
        /// 获取当前图层中被选中的要素
        /// </summary>
       private void GetSelectionSet()
        {
            ILayer curLayer = MapControl.get_Layer(0);
            IFeatureLayer curfeatLayer = curLayer as IFeatureLayer;
            IFeatureSelection featSelection = curLayer  as IFeatureSelection;
            ISelectionSet selectionSet = featSelection.SelectionSet;
            // 获取属性字段
            IFields fields = curfeatLayer.FeatureClass.Fields;
            //MessageBox.Show($"Selected feature count:{ selectionSet.Count}");
            for (var j = 0; j < fields.FieldCount; j++)
            {
                Console.WriteLine(fields.get_Field(j).AliasName);
            }

            ICursor cursor;
            selectionSet.Search(null, false, out cursor);
            IFeatureCursor featCursor = cursor as IFeatureCursor;
            IFeature feat = featCursor.NextFeature();
            string[] fieldValue;
            while (feat != null)
            {
                fieldValue = new string[fields.FieldCount];
                for (int i = 0; i < fields.FieldCount; i++)
                {
                    fieldValue[i] = feat.get_Value(i).ToString();
                    Console.WriteLine($"value:{ fieldValue[i]}");
                }
                feat = featCursor.NextFeature();
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            // 关闭选择模式
            _SelectFeatMod = false;
            curEngineEditor = new EngineEditorClass();
            IMap curMap = MapControl.Map as IMap;
            IFeatureLayer curlayer = MapControl.get_Layer(0) as IFeatureLayer;
            IDataset curDataSet = curlayer.FeatureClass as IDataset;
            IWorkspace cws = curDataSet.Workspace;
            curEngineEditor.EditSessionMode = esriEngineEditSessionMode.esriEngineEditSessionModeNonVersioned;
            curEditorTask = curEngineEditor as IEngineEditTask;
            curEditorTask = curEngineEditor.GetTaskByUniqueName("ControlToolsEditingCreateNewFeatureTask");
            curEngineEditor.CurrentTask = curEditorTask;
            curEngineEditor.EnableUndoRedo(true);
            curEngineEditor.StartEditing(cws, curMap);
            _editMod = true;

            // 设置编辑图层
            curEngineEditLayer = curEngineEditor as IEngineEditLayers;
            curEngineEditLayer.SetTargetLayer(curlayer, 0);

        }
        private void OnMouseDownnWhileEdit(int button, int shift, int x, int y)
        {
            IActiveView curActiveView = MapControl.ActiveView;
            IMap pMap = MapControl.Map;
            IFeatureLayer tFeatLayer = curEngineEditLayer.TargetLayer;
            IFeatureClass tFeatclass = tFeatLayer.FeatureClass;
            IPoint pPoint = curActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
            IGeometry geom = pPoint as IGeometry;
            double dLength = 0;
            ITopologicalOperator topoOperator = geom as ITopologicalOperator;
            ISpatialFilter pSpatailFilter = new SpatialFilterClass();

            switch (tFeatclass.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                    pSpatailFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                    dLength = MapManager.Pixel2MapUnits(curActiveView, 9);
                    break;
                case esriGeometryType.esriGeometryPolygon:
                    pSpatailFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                    break;
                case esriGeometryType.esriGeometryPolyline:
                    pSpatailFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelCrosses;
                    break;
            }
            IGeometry pBuffer = null;
            pBuffer = topoOperator.Buffer(dLength);
            geom = pBuffer.Envelope as IGeometry;
            pSpatailFilter.Geometry = geom;
            pSpatailFilter.GeometryField = tFeatclass.ShapeFieldName;
            IQueryFilter pQueryFiler = pSpatailFilter as IQueryFilter;
            IFeatureCursor featCursor = tFeatclass.Search(pQueryFiler, false);
            IFeature pFeat = featCursor.NextFeature();
            while (pFeat != null)
            {
                pMap.SelectFeature(tFeatLayer as ILayer, pFeat);

                pFeat = featCursor.NextFeature();
            }
            curActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(featCursor);
        }

        /// <summary>
        /// 移动要素
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void  MoveFeature(int x, int y)
        {
            IActiveView curView = MapControl.ActiveView;
            IPoint m_start = MapControl.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
            if (curEngineEditor == null)
            {
                return;
            }
            IFeatureCursor curFeatCur = MapManager.GetSelectedFeatures(curEngineEditLayer.TargetLayer);
            if (curFeatCur == null)
            {
                MessageBox.Show("未选择任何要素！");
                return;
            }
            IFeature curFeat = curFeatCur.NextFeature();
            IMoveGeometryFeedback moveGeoFeedback = new MoveGeometryFeedbackClass();
            moveGeoFeedback.Display = curView.ScreenDisplay;
            while (curFeat != null)
            {
                moveGeoFeedback.AddGeometry(curFeat.Shape);
                curFeat = curFeatCur.NextFeature();
            }
            moveGeoFeedback.Start(m_start);
            System.Runtime.InteropServices.Marshal.ReleaseComObject((curFeatCur));

        }
    }
}

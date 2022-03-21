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

namespace GISDemo
{
    public partial class appMainUI : Form
    {
        // 要素选择模式
        private bool _SelectFeatMod = false;
        // 右键浏览模式
        private bool _isPan = true;
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
                string mxdPath = @"./data/test.csv";
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
                this.MapControl.AddShapeFile(@"./data", "testData");
                // 另一种通过IWorkSpace添加

                // 第二种通过创建工作控件，数据集，图层，要素等添加
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
                System.IO.FileStream fs = new System.IO.FileStream(@"./data/test.csv", FileMode.Open);
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
            IFeatureWorkspace fws = (IFeatureWorkspace)wsf.OpenFromFile(@"./data", 0);
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
        private void MapControl_OnMouseMove(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseMoveEvent e)
        {
            #region 获取鼠标坐标和地图尺寸单位
            string coordinate = string.Format(
                "{0},{1}", e.mapX.ToString("#######.##"),
                e.mapY.ToString("#######.##"));
            string unite = MapControl.MapUnits.ToString().Substring(4);
            tbCoord.Text = coordinate;
            #endregion
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
            
            if (_SelectFeatMod == false)
            {
                _SelectFeatMod = true;
                btnSelectFeat.Text = "清除";
            }
            else
            {
                _SelectFeatMod = false;
                btnSelectFeat.Text = "要素选择";
                IActiveView pActiveView = MapControl.ActiveView;
                pActiveView.FocusMap.ClearSelection();
                pActiveView.PartialRefresh(
                    esriViewDrawPhase.esriViewGeoSelection, null, pActiveView.Extent
                    );
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

        private void MapControl_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 2 && _isPan ==true)
            {
                MapControl.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerHand;
                MapControl.Pan();
            }
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
    }
}

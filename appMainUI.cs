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

namespace GISDemo
{
    public partial class appMainUI : Form
    {
        public appMainUI()
        {
            InitializeComponent();
        }

        private void appMainUI_Load(object sender, EventArgs e)
        {
            // 修改初始化大小
            this.Width = 1440;
            this.Height = 810;
            //LoadData();
        }
        private void LoadData()
        {
            try
            {
                #region 加载本地mxd
                // 加载本地mxd
                string mxdPath = "./data/test.mxd";
                // 检查文件是否有效
                //if (this.MapControl.CheckMxFile(mxdPath))
                //{
                //    this.MapControl.LoadMxFile(mxdPath);
                //}

                IMapDocument curMapDocument = new MapDocument();
                curMapDocument.Open(mxdPath, "");
                MapControl.Map = curMapDocument.ActiveView.FocusMap;
                MapControl.ActiveView.Refresh();


                #endregion
                //加载shapfile文件
                #region 加载shapfile数据
                // 一种通过地图控件的AddShapFile添加
                //this.MapControl.AddShapeFile(@"./data", "testData");
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
        // 点结构 
        public struct CPoint
        {
            public string name;
            public double x;
            public double y;
        }
        public List<CPoint> LoadFromCsv()
        {
            try
            {
                Dictionary<List<string>, List<CPoint>> pointDic = new Dictionary<List<string>, List<CPoint>>();
                List<CPoint> PointList = new List<CPoint>();
                double[] xLIst = new double[1];
                char[] charArray = new char[] { };
                FileStream fs = new FileStream("./data/test.csv", FileMode.Open);
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

        private void btnTest_Click(object sender, EventArgs e)
        {
            List<CPoint> pointList = LoadFromCsv();
            if (pointList != null)
            {
                IFeatureLayer featLayer = GenerateShpFromPoint(pointList);
                if (featLayer != null)
                {
                    MapControl.Map.AddLayer(featLayer);
                    MessageBox.Show("导入成功");
                }
                
                
            }
        }
        private IFeatureLayer GenerateShpFromPoint(List<CPoint> cPoint)
        {
            IWorkspaceFactory wsf = new ShapefileWorkspaceFactoryClass();
            IFeatureWorkspace fws = (IFeatureWorkspace)wsf.OpenFromFile("./data", 0);
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
    }
}

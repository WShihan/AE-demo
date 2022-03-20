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
            LoadData();
        }
        private void LoadData()
        {
            try
            {

                // 加载本地mxd
                string mxdPath = "./data/test.mxd";
                // 检查文件是否有效
                if (this.MapControl.CheckMxFile(mxdPath))
                {
                    this.MapControl.LoadMxFile(mxdPath);
                }
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
        private struct CPoint
        {
            public string name;
            public double x;
            public double y;
        }
        public void LoadFromCsv()
        {
            Dictionary<List<string>, List<CPoint>> pointDic = new Dictionary<List<string>, List<CPoint>>();
            List<CPoint> PointList = new List<CPoint>();
            double[] xLIst = new double[1];
            List<CPoint> pList = new List<CPoint>();
            char[] charArray = new char[] { };
            FileStream fs = new FileStream("./data/test.csv", FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("GBK"));
            string line = sr.ReadLine();

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

        private void btnTest_Click(object sender, EventArgs e)
        {
            LoadFromCsv();
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

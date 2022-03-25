using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapOperation
{
    public class MapManager
    {
        /// <summary>
        /// 像素坐标转地图坐标
        /// </summary>
        /// <returns></returns>
        public static double Pixel2MapUnits(IActiveView activeView, double pixelUnits)
        {
            int pixelExtent = activeView.ScreenDisplay.DisplayTransformation.get_DeviceFrame().right -
                activeView.ScreenDisplay.DisplayTransformation.get_DeviceFrame().left;
            double realWorldDisplayExtent = activeView.ScreenDisplay.DisplayTransformation.VisibleBounds.Width;
            double sizeOfPixel = realWorldDisplayExtent / pixelExtent;
            return pixelUnits * sizeOfPixel;
        }

        /// <summary>
        /// 获取要素选择集
        /// </summary>
        /// <param name="featureLayer"></param>
        /// <returns></returns>
        public static IFeatureCursor GetSelectedFeatures(IFeatureLayer featureLayer)
        {
            ICursor pCursor = null;
            IFeatureCursor pFeatCur = null;
            if (featureLayer == null) return null;
            IFeatureSelection featSelection = featureLayer as IFeatureSelection;
            ISelectionSet pSelSet = featSelection.SelectionSet;
            if (pSelSet.Count == 0) return null;
            pSelSet.Search(null, false, out pCursor);
            pFeatCur = pCursor as IFeatureCursor;
            return pFeatCur;
        }
        /// <summary>
        /// 计算两点之间X轴方向和Y轴方向上距离
        /// </summary>
        /// <param name="lastpoint"></param>
        /// <param name="firstpoint"></param>
        /// <param name="deltaX"></param>
        /// <param name="deltaY"></param>
        /// <returns></returns>
        public static bool CalDistance(IPoint lastpoint, IPoint firstpoint, out double deltaX, out double deltaY)
        {                                      //终点，               起点，       输出deltaX，       输出deltaY
            deltaX = 0; deltaY = 0;
            if (lastpoint == null || firstpoint == null)
                return false;
            deltaX = lastpoint.X - firstpoint.X;
            deltaY = lastpoint.Y - firstpoint.Y;
            return true;
        }
        /// <summary>
        /// 修改Feature的Z、M值方法
        /// </summary>
        /// <param name="featureClass"></param>
        /// <param name="modifiedGeo"></param>
        /// <returns></returns>
        public static IGeometry ModifyGeomtryZMValue(IObjectClass featureClass, IGeometry modifiedGeo)
        {
            IFeatureClass trgFtCls = featureClass as IFeatureClass;
            if (trgFtCls == null) return null;
            string shapeFieldName = trgFtCls.ShapeFieldName;
            IFields fields = trgFtCls.Fields;
            int geometryIndex = fields.FindField(shapeFieldName);
            IField field = fields.get_Field(geometryIndex);
            IGeometryDef pGeometryDef = field.GeometryDef;
            IPointCollection pPointCollection = modifiedGeo as IPointCollection;
            if (pGeometryDef.HasZ)  //属性中有Z值
            {
                IZAware pZAware = modifiedGeo as IZAware;
                pZAware.ZAware = true;//可以使用Z值
                IZ iz1 = modifiedGeo as IZ;
                iz1.SetConstantZ(0);//将Z值设置为0
            }
            else
            {
                IZAware pZAware = modifiedGeo as IZAware;
                pZAware.ZAware = false;
            }
            if (pGeometryDef.HasM)//属性中有M值
            {
                IMAware pMAware = modifiedGeo as IMAware;
                pMAware.MAware = true;//可以使用M值
            }
            else
            {
                IMAware pMAware = modifiedGeo as IMAware;
                pMAware.MAware = false;
            }
            return modifiedGeo;
        }
    }

    
}

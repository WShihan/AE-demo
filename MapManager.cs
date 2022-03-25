using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GISDemo
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
    }

    
}

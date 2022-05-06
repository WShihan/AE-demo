using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using framework.Interface;

namespace framework.Interface
{
    public interface IEditContext
    {
        /// <summary>
        /// 编辑器
        /// </summary>
        IEngineEditor Editor
        {
            get;
            set;
        }
        /// <summary>
        /// 编辑任务
        /// </summary>
        IEngineEditTask EditTask
        {
            get;
            set;
        }
        /// <summary>
        /// 地图视图
        /// </summary>
        IActiveView ActiveView
        {
            get;
            set;
        }
        /// <summary>
        /// 地图
        /// </summary>
        IMap Map
        {
            get;
            set;
        }
    }
}

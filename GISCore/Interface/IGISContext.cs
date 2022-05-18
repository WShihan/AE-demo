using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;

namespace GISService.Interface
{
    public interface IGISContext
    {
        bool Editable{get;set;}
        IMap Map { get; set;}
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
        ArcWorkSpace WorkSpace
        {
            get;
        }

    }
}

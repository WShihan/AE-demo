using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace framework.Interface
{
    public interface IContext
    {
        bool Editable{get;set;}
        IEngineEditor EngineEditor { get;}
        IMap Map { get; set;}

    }
}

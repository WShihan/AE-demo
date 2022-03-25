using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace edit.Interface
{
    public abstract class IEditFunc
    {
        IEngineEditor m_EngineEditor;
        IEngineEditLayers m_EngineEditLayers;
        IActiveView m_activeView;
        IMap m_Map;
    }
}

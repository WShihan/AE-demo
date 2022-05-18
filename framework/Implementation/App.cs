using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using framework.Interface;
using GISService;
namespace framework.Implementation
{
    public class App : IApp
    {
        private GisCore _gisCore;
        public App() 
        {
            _gisCore = new GisCore();
        }
        public GisCore GISCore
        {
            get { return _gisCore; }
        }

    }
}

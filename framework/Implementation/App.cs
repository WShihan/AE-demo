using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using framework.Interface;

namespace framework.Implementation
{
    public class App : IApp
    {
        private GISContext _Giscontext;
        public App() 
        {
            _Giscontext = Implementation.GISContext.Instance;
        }
        public IGISContext GISContext
        {
            get { return _Giscontext; }
        }

    }
}

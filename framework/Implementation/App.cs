using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using framework.Interface;
namespace framework.Implementation
{
    public class App : IApp
    {
        private EditContext _editContext;
        public App() 
        {
            _editContext = EditContext.Instance;
        }
        public IEditContext EditContextIns
        {
            get { return _editContext; }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace framework.Interface
{
    public  interface IEditeTool
    {
        string Name { get; }
        int ID { get; }
        void OnMouseDown(int button, int shfit, int x, int y);
        void OnMouseMove(int button, int shfit, int x, int y);
        void OnMouseUp(int button, int shfit, int x, int y);
        void OnKeyDown(int x, int y);
        void OnKeyUp(int x, int y);
    }
}

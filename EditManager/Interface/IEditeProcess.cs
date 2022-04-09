using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manager.Interface
{
    public interface  IEditeProcess
    {
        void OnMouseDown(int x, int y);
        void OnMouseMove(int x, int y);
        void OnMouseUp(int x, int y);
        void OnKeyDown();
        void OnKeyUp();

    }
}

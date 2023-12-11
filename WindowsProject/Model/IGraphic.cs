using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointProject
{
    public interface IGraphics
    {
        //clearAll
        void ClearAll();
        //drawline
        void DrawLine(double x1, double y1, double x2, double y2);
        //drawrectangle
        void DrawRectangle(double x1, double y1, double x2, double y2);
        //drawcircle
        void DrawCircle(double x1, double y1, double x2, double y2);
    }
}

using System;
using System.Collections.Generic;
using PowerPointProject;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointProjectTests.Model
{
    public class MockGraphic : IGraphics
    {        

        //clearAll
        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }

        //drawline
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            //_graphics.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        //drawrectangle
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            double xDifference = x2 - x1;
            double yDifference = y2 - y1;
            //_graphics.DrawRectangle(Pens.Black, (float)x1, (float)y1, (float)xDifference, (float)yDifference);//左上角，長寬
            //DrawRectangle(Pen pen, int x, int y, int width, int height)
        }

        //drawcircle
        public void DrawCircle(double x1, double y1, double x2, double y2)
        {
            double xDifference = x2 - x1;
            double yDifference = y2 - y1;
            //_graphics.DrawEllipse(Pens.Black, (float)x1, (float)y1, (float)xDifference, (float)yDifference);
            //DrawEllipse(Pen pen, int x, int y, int width, int height)
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PowerPointProject
{
    public class WindowsFormsGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;
        //float _scale;
        public WindowsFormsGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
            //this._scale = scale;
        }

        //clearAll
        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }

        //drawline
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2 );
        }

        //drawrectangle
        public void DrawRectangle(double minX, double minY, double xDifference, double yDifference)
        {
            _graphics.DrawRectangle(Pens.Black, (float)minX, (float)minY, (float)xDifference, (float)yDifference);//左上角，長寬
            //DrawRectangle(Pen pen, int x, int y, int width, int height)
        }

        //drawcircle
        public void DrawCircle(double minX, double minY, double xDifference, double yDifference)
        {
            _graphics.DrawEllipse(Pens.Black, (float)minX, (float)minY, (float)xDifference, (float)yDifference);
            //DrawEllipse(Pen pen, int x, int y, int width, int height)
        }
    }
}

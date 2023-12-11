using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PowerPointProject
{
    public class Line : Shape
    {//需要一個Draw函式自己畫
        private string _shape;
        private const float HALF = 2;
        private const float RADIUS = 3;
        private const float DIAMETER = 10;
        private const string INFO_FORMAT = "({0}, {1}), ({2}, {3})";
        public double StartXCoordinate
        {
            get;
            set;
        }
        public double StartYCoordinate
        {
            get;
            set;
        }

        public double EndXCoordinate
        {
            get;
            set;
        }
        public double EndYCoordinate
        {
            get;
            set;
        }

        /*public List<string> Coordinate
        {
            get;
            set;
        }

        public List<string> Info
        {
            get;
            set;
        }*/

        //設定起始座標
        public override void SetStartCoordinate(Point startCoordinate)
        {
            StartXCoordinate = startCoordinate.X;
            StartYCoordinate = startCoordinate.Y;
        }

        //設定結束座標
        public override void SetEndCoordinate(Point endCoordinate)
        {
            EndXCoordinate = endCoordinate.X;
            EndYCoordinate = endCoordinate.Y;
        }

        //draw line
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(StartXCoordinate, StartYCoordinate, EndXCoordinate, EndYCoordinate);
        }//

        // 繪製該圖形的縮圖
        public override void DrawSlide(IGraphics graphics, Size panelSize, Size slideSize)
        {
            graphics.DrawLine(
                    StartXCoordinate * slideSize.Width / panelSize.Width,
                    StartYCoordinate * slideSize.Height / panelSize.Height,
                    EndXCoordinate * slideSize.Width / panelSize.Width,
                    EndXCoordinate * slideSize.Height / panelSize.Height
                );
        }

        //畫選取框框的小圈圈
        public override void DrawSelectedOutlook(IGraphics graphics)
        {
            //傳入座標一個點x，y座標，並減掉小圓半徑 difference 就是兩倍半徑
            graphics.DrawCircle(StartXCoordinate - RADIUS, StartYCoordinate - RADIUS, StartXCoordinate + RADIUS, StartYCoordinate + RADIUS);
            graphics.DrawCircle(EndXCoordinate - RADIUS, EndYCoordinate - RADIUS, EndXCoordinate + RADIUS, EndYCoordinate + RADIUS);
            graphics.DrawCircle(StartXCoordinate - RADIUS, EndYCoordinate - RADIUS, StartXCoordinate + RADIUS, EndYCoordinate + RADIUS);
            graphics.DrawCircle(EndXCoordinate - RADIUS, StartYCoordinate - RADIUS, EndXCoordinate + RADIUS, StartYCoordinate + RADIUS);
            graphics.DrawCircle((StartXCoordinate + EndXCoordinate) / HALF - RADIUS, StartYCoordinate - RADIUS, (StartXCoordinate + EndXCoordinate) / HALF + RADIUS, StartYCoordinate + RADIUS);
            graphics.DrawCircle((StartXCoordinate + EndXCoordinate) / HALF - RADIUS, EndYCoordinate - RADIUS, (StartXCoordinate + EndXCoordinate) / HALF + RADIUS, EndYCoordinate + RADIUS);
            graphics.DrawCircle(StartXCoordinate - RADIUS, (StartYCoordinate + EndYCoordinate) / HALF - RADIUS, StartXCoordinate + RADIUS, (StartYCoordinate + EndYCoordinate) / HALF + RADIUS);
            graphics.DrawCircle(EndXCoordinate - RADIUS, (StartYCoordinate + EndYCoordinate) / HALF - RADIUS, EndXCoordinate + RADIUS, (StartYCoordinate + EndYCoordinate) / HALF + RADIUS);
        }

        //override get coordinate
        public override string GetCoordinate()
        {
            return string.Format(INFO_FORMAT, StartXCoordinate, StartYCoordinate, EndXCoordinate, EndYCoordinate);
        }

        //override get shape name
        public override string GetShapeName()
        {
            return _shape;
        }
        /*//override get information
        public override List<string> GetInfo()
        {
            Info.Add(GetShapeName());
            Info.Add(GetCoordinate());
            return Info;
        }*/

        //check isSelected
        public override bool IsSelected(Point mousePosition)
        {
            if ((mousePosition.X > StartXCoordinate && mousePosition.Y > StartYCoordinate) && (mousePosition.X < EndXCoordinate && mousePosition.Y < EndYCoordinate))
            {
                return true;
            }
            return false;
        }

        //zoom magnitude
        public override void Zoom(double nowX, double nowY)
        {
            
        }

        //movement magnitude
        public override void Move(double diffX, double diffY)
        {
            StartXCoordinate += diffX;
            StartYCoordinate += diffY;
            EndXCoordinate += diffX;
            EndYCoordinate += diffY;
        }

        //check is selected
        public override bool IsRightDownSelected(Point mousePosition)
        {
            Point firstPoint = new Point(EndXCoordinate - RADIUS, EndYCoordinate - RADIUS);
            Point secondPoint = new Point(EndXCoordinate + RADIUS, EndYCoordinate + RADIUS);
            if((mousePosition.X > firstPoint.X && mousePosition.Y > firstPoint.Y) && (mousePosition.X < secondPoint.X && mousePosition.Y < secondPoint.Y))
            {
                return true;
            }
            return false;
        }

        //建構line
        public Line(string shape, Point startCoordinate, Point endCoordinate)
        {
            _shape = shape;
            StartXCoordinate = startCoordinate.X;
            StartYCoordinate = startCoordinate.Y;
            EndXCoordinate = endCoordinate.X;
            EndYCoordinate = endCoordinate.Y;
        }

    }
}

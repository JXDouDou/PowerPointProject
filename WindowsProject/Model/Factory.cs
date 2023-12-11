using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointProject
{
    public class Factory
    {
        const string RECTANGLE = "矩形";
        const string LINE = "線";
        const string CIRCLE = "圓形";
        const int X_MAX = 704;
        const int Y_MAX = 384;
        Random _random = new Random();

        // 創建shape
        public Shape CreateShape(string shapeName, Point startPoint, Point endPoint)
        {
            switch (shapeName)
            {
                case RECTANGLE:
                    return new Rectangle(shapeName, startPoint, endPoint);
                case LINE:
                    return new Line(shapeName, startPoint, endPoint);
                case CIRCLE:
                    return new Circle(shapeName, startPoint, endPoint);
                default:
                    return null;
            }
        }

        /*//random coordinate
        public void CoordinateRandom(ref double startXCoordinate, ref double startYCoordinate, ref double endXCoordinate, ref double endYCoordinate)
        {
            Point startPoint = new Point(_random.Next(0, X_MAX), _random.Next(0, Y_MAX));
            // Initialize endPoint to a value that ensures the condition is initially true
            Point endPoint = new Point(startPoint.X - 1, startPoint.Y - 1);
            startXCoordinate = startPoint.X;
            startYCoordinate = startPoint.Y;
            while (startPoint.X > endPoint.X)
            {
                endPoint = new Point(_random.Next(0, X_MAX), _random.Next(0, Y_MAX));
                endXCoordinate = endPoint.X;
            }
            while (startPoint.Y > endPoint.Y)
            {
                endPoint = new Point(_random.Next(0, X_MAX), _random.Next(0, Y_MAX));
                endYCoordinate = endPoint.Y;
            }
        }*/

        private Point GetRandomPoint()
        {
            return new Point(_random.Next(0, X_MAX), _random.Next(0, Y_MAX));
        }

        //座標生成
        public void CoordinateRandom(ref double startXCoordinate, ref double startYCoordinate, ref double endXCoordinate, ref double endYCoordinate)
        {
            Point startPoint = GetRandomPoint();
            Point endPoint = GetRandomPoint();

            startXCoordinate = startPoint.X;
            startYCoordinate = startPoint.Y;
            endXCoordinate = endPoint.X;
            endYCoordinate = endPoint.Y;

        }

    }
}

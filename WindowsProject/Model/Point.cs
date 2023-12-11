using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointProject
{
    public class Point
    {
        public Point(double xCoordinate, double yCoordinate)
        {
            X = xCoordinate;
            Y = yCoordinate;
        }

        public double X
        {
            get;
            set;
        }

        public double Y
        {
            get;
            set;
        }
    }
}

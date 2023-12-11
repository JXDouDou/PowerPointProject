using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointProjectTests.Model
{
    public interface IRandom
    {
        //for first case
        List<int> first_case(int min, int maxX, int maxY);
        //for second case
        List<int> second_case(int min, int maxX, int maxY);

    }

    class MockRandom : IRandom
    {
        public double firstX;
        public double firstY;
        public double secondX;
        public double secondY;
        Random _random = new Random();
        //firstX > secondX && startY > secondY
        public List<int> first_case(int min, int maxX, int maxY)
        {
            List<int> twoPoint = new List<int>();
            twoPoint.Add((int)(firstX = _random.Next(maxX / 2, maxX)));
            twoPoint.Add((int)(secondX = _random.Next(min, maxX / 2)));
            twoPoint.Add((int)(firstY = _random.Next(maxY / 2, maxY)));
            twoPoint.Add((int)(secondY = _random.Next(min, maxY / 2)));
            return twoPoint;
        }

        // firstX < secondX && startY < secondY
        public List<int> second_case(int min, int maxX, int maxY)
        {
            List<int> twoPoint = new List<int>();
            twoPoint.Add((int)(firstX = _random.Next(min, maxX / 2)));
            twoPoint.Add((int)(secondX = _random.Next(maxX / 2, maxX)));
            twoPoint.Add((int)(firstY = _random.Next(min, maxY / 2)));
            twoPoint.Add((int)(secondY = _random.Next(maxY / 2, maxY)));
            return twoPoint;
        }

    }
}

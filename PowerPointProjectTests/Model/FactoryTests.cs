using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPointProject;
using PowerPointProjectTests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointProject.Tests
{
    [TestClass()]
    public class FactoryTests
    {

        const string LINE = "線";
        const string RECTANGLE = "矩形";
        const string CIRCLE = "圓形";
        const int X_MAX = 704;
        const int Y_MAX = 384;

        Factory _factory;


        //初始化FactoryTest
        [TestInitialize()]
        public void Initialize()
        {
            _factory = new Factory();
        }

        //測試CreateShape(shapeName = Line)
        [TestMethod()]
        public void CreateLineTest()
        {
            // 0<x<704, 0<y<384
            Point startCoordinate = new Point(10, 200);
            Point endCoordinate = new Point(100, 300);
            Shape line_test = _factory.CreateShape(LINE, startCoordinate, endCoordinate);

            Assert.AreEqual(startCoordinate.X, ((Line)line_test).StartXCoordinate);
            Assert.AreEqual(startCoordinate.Y, ((Line)line_test).StartYCoordinate);
            Assert.AreEqual(endCoordinate.X, ((Line)line_test).EndXCoordinate);
            Assert.AreEqual(endCoordinate.Y, ((Line)line_test).EndYCoordinate);

        }

        //測試CreateShape(shapeName = rectangle)
        [TestMethod()]
        public void CreateRectangleTest()
        {
            // 0<x<704, 0<y<384
            Point startCoordinate = new Point(300, 200);
            Point endCoordinate = new Point(200, 300);
            Shape line_test = _factory.CreateShape(RECTANGLE, startCoordinate, endCoordinate);

            Assert.AreEqual(endCoordinate.X, ((Rectangle)line_test).StartXCoordinate);
            Assert.AreEqual(startCoordinate.Y, ((Rectangle)line_test).StartYCoordinate);
            Assert.AreEqual(startCoordinate.X, ((Rectangle)line_test).EndXCoordinate);
            Assert.AreEqual(endCoordinate.Y, ((Rectangle)line_test).EndYCoordinate);

        }

        //測試CreateShape(shapeName = circle)
        [TestMethod()]
        public void CreateCircleTest()
        {
            // 0<x<704, 0<y<384
            Point startCoordinate = new Point(300, 125);
            Point endCoordinate = new Point(200, 75);
            Shape line_test = _factory.CreateShape(CIRCLE, startCoordinate, endCoordinate);

            Assert.AreEqual(endCoordinate.X, ((Circle)line_test).StartXCoordinate);
            Assert.AreEqual(endCoordinate.Y, ((Circle)line_test).StartYCoordinate);
            Assert.AreEqual(startCoordinate.X, ((Circle)line_test).EndXCoordinate);
            Assert.AreEqual(startCoordinate.Y, ((Circle)line_test).EndYCoordinate);

        }
        //測試CreateShape(shapeName = ??) = null
        [TestMethod()]
        public void CreateNullTest()
        {
            // 0<x<704, 0<y<384
            Point startCoordinate = new Point(1, 3);
            Point endCoordinate = new Point(2, 4);
            Shape line_test = _factory.CreateShape("不知道", startCoordinate, endCoordinate);
            Assert.IsNull(line_test);

        }

        //test CoordinateRandom
        [TestMethod]
        public void TestCoordinateRandom()
        {
            // Arrange
            double startX = -1;
            double startY = -1;
            double endX = -1;
            double endY = -1;

            // Act 因為線的座標規定而先不用導正
            _factory.CoordinateRandom(ref startX, ref startY, ref endX, ref endY);

            // Assert
            Assert.IsTrue(startX >= 0 && startX <= X_MAX);
            Assert.IsTrue(startY >= 0 && startY <= Y_MAX);
            Assert.IsTrue(endX >= 0 && endX <= X_MAX);
            Assert.IsTrue(endY >= 0 && endY <= Y_MAX);

        }

        /*[TestMethod()]
        public void CoordinateRandomTest()
        {

            Assert.Fail();
        }*/
    }
}
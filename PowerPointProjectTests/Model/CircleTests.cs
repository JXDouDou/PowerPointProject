using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPointProject;
using PowerPointProjectTests.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointProject.Tests
{
    [TestClass()]
    public class CircleTests
    {
        MockRandom _mockRandom;
        MockGraphic _graphic;
        Circle _Circle;
        const int X_MAX = 704;
        const int Y_MAX = 384;

        //initialize
        [TestInitialize()]
        public void Initialize()
        {
            _graphic = new MockGraphic();
            _mockRandom = new MockRandom();
            List<int> testPoints = _mockRandom.first_case(0, X_MAX, Y_MAX);
            Point startCoordinate = new Point(testPoints[0], testPoints[2]);
            Point endCoordinate = new Point(testPoints[1], testPoints[3]);
            _Circle = new Circle("圓形", startCoordinate, endCoordinate);
        }

        //test set startCoordinate
        [TestMethod()]
        public void SetStartCoordinateTest()
        {
            List<int> setPoints = _mockRandom.first_case(0, X_MAX, Y_MAX);
            Point nowPoint = new Point(setPoints[0], setPoints[2]);
            _Circle.SetStartCoordinate(nowPoint);

        }

        //test set endCoordinate
        [TestMethod()]
        public void SetEndCoordinateTest()
        {
            List<int> setPoints = _mockRandom.first_case(0, X_MAX, Y_MAX);
            Point nowPoint = new Point(setPoints[0], setPoints[2]);
            _Circle.SetEndCoordinate(nowPoint);
        }

        //test Draw
        [TestMethod()]
        public void DrawTest()
        {
            _Circle.Draw(_graphic);
        }

        //test DrawSlide
        [TestMethod()]
        public void DrawSlideTest()
        {
            List<int> testPoints = _mockRandom.first_case(0, X_MAX, Y_MAX);
            Size panelSize = new Size(testPoints[0], testPoints[2]);
            Size slideSize = new Size(testPoints[1], testPoints[3]);
            _Circle.DrawSlide(_graphic, panelSize, slideSize);
        }

        //test DrawSelectedOutlook
        [TestMethod()]
        public void DrawSelectedOutlookTest()
        {
            _Circle.DrawSelectedOutlook(_graphic);
        }

        //test GetInfo
        [TestMethod()]
        public void GetCoordinateTest()
        {
            string testInfo = string.Format("({0}, {1}), ({2}, {3})", _Circle.StartXCoordinate, _Circle.StartYCoordinate, _Circle.EndXCoordinate, _Circle.EndYCoordinate);
            Assert.AreEqual(testInfo, _Circle.GetCoordinate());
        }

        //test GetShapeName
        [TestMethod()]
        public void GetShapeNameTest()
        {
            Assert.AreEqual("圓形", _Circle.GetShapeName());
        }

        //test IsSelected Case1
        [TestMethod()]
        public void IsSelectedTest_Case1()
        {
            Point testStart = new Point(300, 100);
            _Circle.SetStartCoordinate(testStart);
            Point testEnd = new Point(450, 200);
            _Circle.SetEndCoordinate(testEnd);
            Point nowMouse = new Point(325, 123);
            bool check = _Circle.IsSelected(nowMouse);
            Assert.AreEqual(true, check);
        }

        //test IsSelected Case
        [TestMethod()]
        public void IsSelectedTest_Case2()
        {
            Point testStart = new Point(300, 100);
            _Circle.SetStartCoordinate(testStart);
            Point testEnd = new Point(450, 200);
            _Circle.SetEndCoordinate(testEnd);
            Point nowMouse = new Point(455, 123);
            bool check = _Circle.IsSelected(nowMouse);
            Assert.AreEqual(false, check);
        }

        //test IsSelected Case3
        [TestMethod()]
        public void IsSelectedTest_Case3()
        {
            Point testStart = new Point(300, 100);
            _Circle.SetStartCoordinate(testStart);
            Point testEnd = new Point(450, 200);
            _Circle.SetEndCoordinate(testEnd);
            Point nowMouse = new Point(255, 88);
            bool check = _Circle.IsSelected(nowMouse);
            Assert.AreEqual(false, check);
        }

        //test how far we move
        [TestMethod()]
        public void MoveTest()
        {
            Point testStart = new Point(300, 100);
            _Circle.SetStartCoordinate(testStart);
            Point testEnd = new Point(450, 200);
            _Circle.SetEndCoordinate(testEnd);
            Point movement = new Point(20, 15);
            _Circle.Move(movement.X, movement.Y);
            Assert.AreEqual(_Circle.StartXCoordinate, 300 + 20);
            Assert.AreEqual(_Circle.StartYCoordinate, 100 + 15);
            Assert.AreEqual(_Circle.EndXCoordinate, 450 + 20);
            Assert.AreEqual(_Circle.EndYCoordinate, 200 + 15);
        }

        //CircleConstructor
        [TestMethod()]
        public void CircleTest()
        {

        }
    }
}
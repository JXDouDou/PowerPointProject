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
    public class LineTests
    {
        MockRandom _mockRandom;
        MockGraphic _graphic;
        Line _line;
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
            _line = new Line("線", startCoordinate, endCoordinate);
        }

        //test set startCoordinate
        [TestMethod()]
        public void SetStartCoordinateTest()
        {
            List<int> setPoints = _mockRandom.first_case(0, X_MAX, Y_MAX);
            Point nowPoint = new Point(setPoints[0], setPoints[2]);
            _line.SetStartCoordinate(nowPoint);
            
        }

        //test set endCoordinate
        [TestMethod()]
        public void SetEndCoordinateTest()
        {
            List<int> setPoints = _mockRandom.first_case(0, X_MAX, Y_MAX);
            Point nowPoint = new Point(setPoints[0], setPoints[2]);
            _line.SetEndCoordinate(nowPoint);
        }

        //test Draw
        [TestMethod()]
        public void DrawTest()
        {
            _line.Draw(_graphic);
        }

        //test DrawSlide
        [TestMethod()]
        public void DrawSlideTest()
        {
            List<int> testPoints = _mockRandom.first_case(0, X_MAX, Y_MAX);
            Size panelSize = new Size(testPoints[0], testPoints[2]);
            Size slideSize = new Size(testPoints[1], testPoints[3]);
            _line.DrawSlide(_graphic, panelSize, slideSize);
        }

        //test DrawSelectedOutlook
        [TestMethod()]
        public void DrawSelectedOutlookTest()
        {
            _line.DrawSelectedOutlook(_graphic);
        }

        //test GetInfo
        [TestMethod()]
        public void GetCoordinateTest()
        {
            string testInfo = string.Format("({0}, {1}), ({2}, {3})", _line.StartXCoordinate, _line.StartYCoordinate, _line.EndXCoordinate, _line.EndYCoordinate);
            Assert.AreEqual(testInfo, _line.GetCoordinate());
        }

        //test GetShapeName
        [TestMethod()]
        public void GetShapeNameTest()
        {
            Assert.AreEqual("線", _line.GetShapeName());
        }

        //test IsSelected Case1
        [TestMethod()]
        public void IsSelectedTest_Case1()
        {
            Point testStart = new Point(300, 100);
            _line.SetStartCoordinate(testStart);
            Point testEnd = new Point(450, 200);
            _line.SetEndCoordinate(testEnd);
            Point nowMouse = new Point(325, 123);
            bool check = _line.IsSelected(nowMouse);
            Assert.AreEqual(true, check);
        }

        //test IsSelected Case
        [TestMethod()]
        public void IsSelectedTest_Case2()
        {
            Point testStart = new Point(300, 100);
            _line.SetStartCoordinate(testStart);
            Point testEnd = new Point(450, 200);
            _line.SetEndCoordinate(testEnd);
            Point nowMouse = new Point(455, 123);
            bool check = _line.IsSelected(nowMouse);
            Assert.AreEqual(false, check);
        }

        //test IsSelected Case3
        [TestMethod()]
        public void IsSelectedTest_Case3()
        {
            Point testStart = new Point(300, 100);
            _line.SetStartCoordinate(testStart);
            Point testEnd = new Point(450, 200);
            _line.SetEndCoordinate(testEnd);
            Point nowMouse = new Point(255, 88);
            bool check = _line.IsSelected(nowMouse);
            Assert.AreEqual(false, check);
        }

        //test Zoom
        [TestMethod()]
        public void ZoomTest()
        {
            Point testStart = new Point(300, 100);
            _line.SetStartCoordinate(testStart);
            Point testEnd = new Point(450, 200);
            _line.SetEndCoordinate(testEnd);
            Point nowMouse = new Point(325, 123);
            _line.Zoom(nowMouse.X, nowMouse.Y);
            Assert.AreEqual(_line.EndXCoordinate, nowMouse.X);
            Assert.AreEqual(_line.EndYCoordinate, nowMouse.Y);
        }

        //test Coordinate reset
        [TestMethod()]
        public void ResetCoordinateTest()
        {
            Point testStart = new Point(450, 200);
            _line.SetStartCoordinate(testStart);
            Point testEnd = new Point(300, 100);
            _line.SetEndCoordinate(testEnd);
            _line.ResetCoordinate();
            Assert.AreEqual(_line.StartXCoordinate, 300);
            Assert.AreEqual(_line.StartYCoordinate, 100);
            Assert.AreEqual(_line.EndXCoordinate, 450);
            Assert.AreEqual(_line.EndYCoordinate, 200);
        }

        //test how far we move
        [TestMethod()]
        public void MoveTest()
        {
            Point testStart = new Point(300, 100);
            _line.SetStartCoordinate(testStart);
            Point testEnd = new Point(450, 200);
            _line.SetEndCoordinate(testEnd);
            Point movement = new Point(20, 15);
            _line.Move(movement.X, movement.Y);
            Assert.AreEqual(_line.StartXCoordinate, 300 + 20);
            Assert.AreEqual(_line.StartYCoordinate, 100 + 15);
            Assert.AreEqual(_line.EndXCoordinate, 450 + 20);
            Assert.AreEqual(_line.EndYCoordinate, 200 + 15);
        }

        //test Is Right Down or not
        [TestMethod()]
        public void IsRightDownSelectedTest()
        {
            Point testStart = new Point(300, 100);
            _line.SetStartCoordinate(testStart);
            Point testEnd = new Point(450, 200);
            _line.SetEndCoordinate(testEnd);
            Point nowMouse = new Point(455, 203);
            bool check = _line.IsRightDownSelected(nowMouse);
            Assert.AreEqual(true, check);
            Point nowMouse2 = new Point(477, 203);
            bool check2 = _line.IsRightDownSelected(nowMouse2);
            Assert.AreEqual(false, check2);
            Point nowMouse3 = new Point(1, 2);
            bool check3 = _line.IsRightDownSelected(nowMouse3);
            Assert.AreEqual(false, check3);
        }

        //LineConstructor
        [TestMethod()]
        public void LineTest()
        {

        }
    }
}
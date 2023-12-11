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
    public class PointStateTests
    {
        MockRandom _mockRandom;
        ModelOfDataGridView _model;
        PointState _pointState;
        const int X_MAX = 704;
        const int Y_MAX = 384;
        //produce random shape name
        string randomShapeName()
        {
            Random _random = new Random();
            int shapeName = _random.Next(0, 2);
            List<string> ShapeNameList = new List<string>();
            ShapeNameList.Add("線");
            ShapeNameList.Add("矩形");
            ShapeNameList.Add("圓形");
            return ShapeNameList[shapeName];
        }

        //initialize
        [TestInitialize()]
        public void Initialize()
        {
            _mockRandom = new MockRandom();
            _model = new ModelOfDataGridView();
            Point startCoordinate_0 = new Point(200, 40);
            Point endCoordinate_0 = new Point(300, 60);
            _model.CreateShapesForMouse(randomShapeName(), startCoordinate_0, endCoordinate_0);

            Point startCoordinate_1 = new Point(350, 70);
            Point endCoordinate_1 = new Point(400, 100);
            _model.CreateShapesForMouse(randomShapeName(), startCoordinate_1, endCoordinate_1);

            Point startCoordinate_2 = new Point(200, 40);
            Point endCoordinate_2 = new Point(400, 100);
            _model.CreateShapesForMouse(randomShapeName(), startCoordinate_2, endCoordinate_2);
            _pointState = new PointState(_model);
        }

        //test PointState constructor
        [TestMethod()]
        public void PointStateTest()
        {
            _model = new ModelOfDataGridView();
            Point startCoordinate_0 = new Point(200, 40);
            Point endCoordinate_0 = new Point(300, 60);
            _model.CreateShapesForMouse(randomShapeName(), startCoordinate_0, endCoordinate_0);

            Point startCoordinate_1 = new Point(350, 70);
            Point endCoordinate_1 = new Point(400, 100);
            _model.CreateShapesForMouse(randomShapeName(), startCoordinate_1, endCoordinate_1);

            Point startCoordinate_2 = new Point(200, 40);
            Point endCoordinate_2 = new Point(400, 100);
            _model.CreateShapesForMouse(randomShapeName(), startCoordinate_2, endCoordinate_2);
            _pointState = new PointState(_model);
        }

        //test pressedPointer
        [TestMethod()]
        public void PressedPointerTest()
        {
            _pointState.PressedPointer("線", 300, 60);
        }

        //test movedPointer
        [TestMethod()]
        public void MovedPointerTest()
        {
            List<int> testPoints_0 = _mockRandom.first_case(0, X_MAX, Y_MAX);
            Point nowPoint = new Point(testPoints_0[0], testPoints_0[2]);
            _pointState._isPressed = true;
            _pointState.MovedPointer(nowPoint.X, nowPoint.Y);
        }

        //test releasedPointer
        [TestMethod()]
        public void ReleasedPointerTest()
        {
           
        }

        //test Draw
        [TestMethod()]
        public void DrawTest()
        {
            
        }
    }
}
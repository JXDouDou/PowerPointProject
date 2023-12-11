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
    public class DrawingStateTests
    {
        MockRandom _mockRandom;
        ModelOfDataGridView _model;
        DrawingState _drawState;
        MockGraphic _graphic;
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
            _graphic = new MockGraphic();
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
            _drawState = new DrawingState(_model);
        }

        //test DrawingState
        [TestMethod()]
        public void DrawingStateTest()
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
            _drawState = new DrawingState(_model);
        }

        //test Pressed Pointer
        [TestMethod()]
        public void PressedPointerTest()
        {
            _drawState.PressedPointer("線", 300, 60);
            _drawState.PressedPointer("矩形", 300, 60);
            _drawState.PressedPointer("圓形", 300, 60);
            _drawState.PressedPointer(null, 300, 60);
        }

        //test MoveCase1
        [TestMethod()]
        public void MovedPointerTest_Case1()
        {
            List<int> testPoints_0 = _mockRandom.first_case(0, X_MAX, Y_MAX);
            Point nowPoint = new Point(testPoints_0[0], testPoints_0[2]);
            _drawState.PressedPointer("線", 300, 60);
            _drawState._isPressed = true;
            _drawState.MovedPointer(nowPoint.X, nowPoint.Y);

        }

        //test MoveCase2
        [TestMethod()]
        public void MovedPointerTest_Case2()
        {
            List<int> testPoints_0 = _mockRandom.first_case(0, X_MAX, Y_MAX);
            Point nowPoint = new Point(testPoints_0[0], testPoints_0[2]);
            _drawState._isPressed = false;
            _drawState.MovedPointer(nowPoint.X, nowPoint.Y);

        }

        //test releasedPointer case1
        [TestMethod()]
        public void ReleasedPointerTest_Case1()
        {
            _drawState.PressedPointer("線", 300, 60);
            _drawState._isPressed = true;
            _drawState.ReleasedPointer("線", 400, 70);
        }

        //test releasedPointer case2
        [TestMethod()]
        public void ReleasedPointerTest_Case2()
        {
            _drawState.PressedPointer("線", 300, 60);
            _drawState._isPressed = false;
            _drawState.ReleasedPointer("線", 400, 70);
        }

        //DrawCase1
        [TestMethod()]
        public void DrawTest_Case1()
        {
            _drawState.PressedPointer("線", 300, 60);
            _drawState._isPressed = true;
            _drawState.Draw(_graphic);
        }

        //DrawCase2
        [TestMethod()]
        public void DrawTest_Case2()
        {
            _drawState._isPressed = false;
            _drawState.Draw(_graphic);
        }
    }
}
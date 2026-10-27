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
    public class ModelOfDataGridViewTests
    {

        ModelOfDataGridView _model;
        MockRandom _random;
        MockGraphic _graphic;
        const int X_MAX = 704;
        const int Y_MAX = 384;
        private int _modelChangedCounter = 0;

        //test model changed
        private void TestModelChanged()
        {
            _modelChangedCounter++;
        }
        //produce randomShapeName
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

        //初始化model
        [TestInitialize()]
        public void Initialize()
        {
            _model = new ModelOfDataGridView();
            _random = new MockRandom();
            _graphic = new MockGraphic();
            _model._modelChanged += TestModelChanged;
        }

        //test change to DrawingMode
        [TestMethod()]
        public void DrawingModeTest()
        {
            _model.DrawingMode();
        }

        //test change to PointMode
        [TestMethod()]
        public void PointModeTest()
        {
            _model.PointMode();
        }

        //test PressedPointer
        [TestMethod()]
        public void PressedPointerTest()
        {
            List<int> testPoints = _random.first_case(0, X_MAX, Y_MAX);
            Point pressedCoordinate = new Point(testPoints[0], testPoints[2]);
            string nowShapeName = randomShapeName();
            _model.PressedPointer(nowShapeName, pressedCoordinate.X, pressedCoordinate.Y);
        }

        //test MovedPointer
        [TestMethod()]
        public void MovedPointerTest()
        {
            List<int> testPoints = _random.first_case(0, X_MAX, Y_MAX);
            Point movedCoordinate = new Point(testPoints[0], testPoints[2]);
            _model.MovedPointer(movedCoordinate.X, movedCoordinate.Y);
        }

        //test ReleasedPointer
        [TestMethod()]
        public void ReleasedPointerTest()
        {
            List<int> testPoints = _random.first_case(0, X_MAX, Y_MAX);
            Point releasedCoordinate = new Point(testPoints[0], testPoints[2]);
            string nowShapeName = randomShapeName();
            _model.ReleasedPointer(nowShapeName, releasedCoordinate.X, releasedCoordinate.Y);
        }

        //test zooming process
        [TestMethod()]
        public void ShapeZoomingTest()
        {
            List<int> testPoints = _random.first_case(0, X_MAX, Y_MAX);
            Point releasedCoordinate = new Point(testPoints[0], testPoints[2]);
            string nowShapeName = randomShapeName();
            _model.ShapeZooming(40, 80);
        }

        //test ShapeMoving
        [TestMethod()]
        public void ShapeMovingTest()
        {
            List<int> testPoints_0 = _random.first_case(0, X_MAX, Y_MAX);
            Point startCoordinate = new Point(testPoints_0[0], testPoints_0[2]);
            Point endCoordinate = new Point(testPoints_0[1], testPoints_0[3]);
            _model.CreateShapesForMouse(randomShapeName(), startCoordinate, endCoordinate);


            List<int> testPoints_1 = _random.first_case(0, X_MAX, Y_MAX);
            startCoordinate = new Point(testPoints_1[0], testPoints_1[2]);
            endCoordinate = new Point(testPoints_1[1], testPoints_1[3]);
            string shapeNameBuffer = randomShapeName();
            _model.CreateShapesForMouse(shapeNameBuffer, startCoordinate, endCoordinate);


            List<int> testPoints_2 = _random.first_case(0, X_MAX, Y_MAX);
            startCoordinate = new Point(testPoints_2[0], testPoints_2[2]);
            endCoordinate = new Point(testPoints_2[1], testPoints_2[3]);
            _model.CreateShapesForMouse(randomShapeName(), startCoordinate, endCoordinate);


            Point nowCoordinate = new Point(123, 32);
            _model.NowShapeSelected = 1;
            _model.ShapeMoving(nowCoordinate.X, nowCoordinate.Y);
        }

        //test Draw
        [TestMethod()]
        public void DrawTest()
        {
            _model.Draw(_graphic);
        }

        //test DrawSlide
        [TestMethod()]
        public void DrawSlideTest()
        {
            _model.DrawSlide(_graphic);
        }

        //test Create Shape with name
        [TestMethod()]
        public void CreateShapesTest()
        {
            Point allTest_1 = new Point(100, 200);
            Point allTest_2 = new Point(150, 250);
            _model.CreateShapes("線", allTest_1, allTest_2);
            _model.CreateShapes("矩形", allTest_1, allTest_2);
            _model.CreateShapes("圓形", allTest_1, allTest_2);
            _model.CreateShapes("我不知道", allTest_1, allTest_2);
        }

        //test Create Shapes by Mouse
        [TestMethod()]
        public void CreateShapesForMouseTest()
        {
            List<int> testPoints_0 = _random.first_case(0, X_MAX, Y_MAX);
            Point startCoordinate = new Point(testPoints_0[0], testPoints_0[2]);
            Point endCoordinate = new Point(testPoints_0[1], testPoints_0[3]);
            _model.CreateShapesForMouse("線", startCoordinate, endCoordinate);


            List<int> testPoints_1 = _random.first_case(0, X_MAX, Y_MAX);
            startCoordinate = new Point(testPoints_1[0], testPoints_1[2]);
            endCoordinate = new Point(testPoints_1[1], testPoints_1[3]);
            _model.CreateShapesForMouse("矩形", startCoordinate, endCoordinate);


            List<int> testPoints_2 = _random.first_case(0, X_MAX, Y_MAX);
            startCoordinate = new Point(testPoints_2[0], testPoints_2[2]);
            endCoordinate = new Point(testPoints_2[1], testPoints_2[3]);
            _model.CreateShapesForMouse("圓形", startCoordinate, endCoordinate);

            List<int> testPoints_3 = _random.first_case(0, X_MAX, Y_MAX);
            startCoordinate = new Point(testPoints_3[0], testPoints_3[2]);
            endCoordinate = new Point(testPoints_3[1], testPoints_3[3]);
            _model.CreateShapesForMouse("窩不知道", startCoordinate, endCoordinate);
        }

        //test check selected shape
        [TestMethod()]
        public void CheckSelectedShapeTest()
        {
            Point startCoordinate_0 = new Point(200, 40);
            Point endCoordinate_0 = new Point(300, 60);
            _model.CreateShapesForMouse(randomShapeName(), startCoordinate_0, endCoordinate_0);

            Point startCoordinate_1 = new Point(350, 70);
            Point endCoordinate_1 = new Point(400, 100);
            _model.CreateShapesForMouse(randomShapeName(), startCoordinate_1, endCoordinate_1);

            Point startCoordinate_2 = new Point(200, 40);
            Point endCoordinate_2 = new Point(400, 100);
            _model.CreateShapesForMouse(randomShapeName(), startCoordinate_2, endCoordinate_2);

            Point mousePoint = new Point(377, 77);
            bool niceCase = _model.CheckSelectedShape(mousePoint.X, mousePoint.Y);
            Assert.AreEqual(niceCase, true);

            Point badMousePoint = new Point(600, 111);
            bool badCase = _model.CheckSelectedShape(badMousePoint.X, badMousePoint.Y);
            Assert.AreEqual(badCase, false);
        }

        //test draw selected
        [TestMethod()]
        public void DrawSelectedShapeTest()
        {
            _model.DrawSelectedShape(_graphic);
        }

        //test moveShape
        [TestMethod()]
        public void MoveShapeTest()
        {
            Point nowPoint = new Point(43, 66);
            _model.MovedShape(nowPoint.X, nowPoint.Y);
        }

        //test getModelGridView
        [TestMethod()]
        public void GetModelGridViewTest()
        {
            List<ShapeGridViewColumns> testGrid = _model.GetModelGridView();
        }

        //test DelestShape
        [TestMethod()]
        public void DeleteShapeTest()
        {
            Point startCoordinate_0 = new Point(200, 40);
            Point endCoordinate_0 = new Point(300, 60);
            _model.CreateShapesForMouse(randomShapeName(), startCoordinate_0, endCoordinate_0);

            Point startCoordinate_1 = new Point(350, 70);
            Point endCoordinate_1 = new Point(400, 100);
            _model.CreateShapesForMouse(randomShapeName(), startCoordinate_1, endCoordinate_1);

            Point startCoordinate_2 = new Point(200, 40);
            Point endCoordinate_2 = new Point(400, 100);
            _model.CreateShapesForMouse(randomShapeName(), startCoordinate_2, endCoordinate_2);
            Random _testRandom = new Random();
            _model.DeleteShape(_testRandom.Next(0, 2));
        }

        //test pressed delete key
        [TestMethod()]
        public void PressDeleteKeyTest()
        {
            Point startCoordinate_0 = new Point(200, 40);
            Point endCoordinate_0 = new Point(300, 60);
            _model.CreateShapesForMouse(randomShapeName(), startCoordinate_0, endCoordinate_0);

            Point startCoordinate_1 = new Point(350, 70);
            Point endCoordinate_1 = new Point(400, 100);
            _model.CreateShapesForMouse(randomShapeName(), startCoordinate_1, endCoordinate_1);

            Point startCoordinate_2 = new Point(200, 40);
            Point endCoordinate_2 = new Point(400, 100);
            _model.CreateShapesForMouse(randomShapeName(), startCoordinate_2, endCoordinate_2);
            Random _testRandom = new Random();
            _model.DeleteShape(_testRandom.Next(0, 2));

            _model.NowShapeSelected = 1;
            _model.PressDeleteKey();
        }

        //我放棄讓這branch也100%
        [TestMethod()]
        public void NotifyModelChangedTest()
        {
            Assert.AreEqual(0, _modelChangedCounter);
            _model.NotifyModelChanged();
            _model.NotifyModelChanged();
            Assert.AreEqual(2, _modelChangedCounter);
        }
    }
}
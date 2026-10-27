using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPointProject;
using PowerPointProjectTests.Model;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointProject.Tests
{
    [TestClass()]
    public class ShapesTests
    {
        MockRandom _random;
        MockGraphic _graphic;
        Factory _factory;
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
        Shapes _shapes;
        //初始化ShapesTest
        [TestInitialize()]
        public void Initialize()
        {
            _shapes = new Shapes();
            _random = new MockRandom();
            _graphic = new MockGraphic();
            _factory = new Factory();
        }

        //測試CreateShape
        [TestMethod()]
        public void CreateShapeTest()
        {
            //for any case is true 由於factory都有跑到並正常執行 故先不管座標的方位問題
            List<int> testPoints = _random.first_case(0, X_MAX, Y_MAX);
            Point startCoordinate = new Point(testPoints[0], testPoints[2]);
            Point endCoordinate = new Point(testPoints[1], testPoints[3]);
            string nowShapeName = randomShapeName();
            _shapes.CreateShape(nowShapeName, startCoordinate, endCoordinate, true);

            //for any case is false
            List<int> testPoints_2 = _random.second_case(0, X_MAX, Y_MAX);
            Point startCoordinate_2 = new Point(testPoints[0], testPoints[2]);
            Point endCoordinate_2 = new Point(testPoints[1], testPoints[3]);
            string nowShapeName_2 = randomShapeName();
            _shapes.CreateShape(nowShapeName_2, startCoordinate_2, endCoordinate_2, false);

            Point testPoint1 = new Point(20, 40);
            Point testPoint2 = new Point(40, 60);
            _shapes.CreateShape(nowShapeName_2, testPoint1, testPoint2, true);
            Assert.AreEqual(_shapes.GetShapeListInfo()[2]._column3, "(20, 40), (40, 60)");
        }

        //測試CreatHintShape
        [TestMethod()]
        public void CreateHintShapeTest()
        {
            List<int> testPoints = _random.first_case(0, X_MAX, Y_MAX);
            Point startCoordinate = new Point(testPoints[0], testPoints[2]);
            Point endCoordinate = new Point(testPoints[1], testPoints[3]);
            string nowShapeName = randomShapeName();
            _shapes.CreateHintShape(nowShapeName, startCoordinate, endCoordinate);
        }

        /*//測試接收List<string>
        [TestMethod()]
        public void GetShapeInfoTest()
        {
            List<string> ShapesInfo = new List<string>();
        }*/

        //測試GetShapeListInfo的運作
        [TestMethod()]
        public void GetShapeListInfoTest()
        {

            List<Shape> ShapeList = new List<Shape>();

            List<int> testPoints = _random.first_case(0, X_MAX, Y_MAX);
            Point startCoordinate = new Point(testPoints[0], testPoints[2]);
            Point endCoordinate = new Point(testPoints[1], testPoints[3]);
            string nowShapeName = randomShapeName();
            _shapes.CreateShape(nowShapeName, startCoordinate, endCoordinate, true);
            List<ShapeGridViewColumns> ShapeGridList = _shapes.GetShapeListInfo();
            Assert.AreEqual(ShapeGridList[0]._column1, "刪除");
            ShapeList.Add(_factory.CreateShape(nowShapeName, startCoordinate, endCoordinate));
            Assert.AreEqual(ShapeGridList[0]._column2, nowShapeName);
            //Point fourthTestPoint = new Point((Rectangle)ShapeList[3].StartXCoordinate, testPoints[2]);
            //Point fourthTestPoint_2 = new Point(testPoints[1], testPoints[3]);

        }
        
        //測試deleteShape
        [TestMethod()]
        public void DeleteShapeTest()
        {
            List<int> testPoints_0 = _random.first_case(0, X_MAX, Y_MAX);
            Point startCoordinate = new Point(testPoints_0[0], testPoints_0[2]);
            Point endCoordinate = new Point(testPoints_0[1], testPoints_0[3]);
            _shapes.CreateShape("線", startCoordinate, endCoordinate, true);


            List<int> testPoints_1 = _random.first_case(0, X_MAX, Y_MAX);
            startCoordinate = new Point(testPoints_1[0], testPoints_1[2]);
            endCoordinate = new Point(testPoints_1[1], testPoints_1[3]);
            _shapes.CreateShape("矩形", startCoordinate, endCoordinate, true);


            List<int> testPoints_2 = _random.first_case(0, X_MAX, Y_MAX);
            startCoordinate = new Point(testPoints_2[0], testPoints_2[2]);
            endCoordinate = new Point(testPoints_2[1], testPoints_2[3]);
            _shapes.CreateShape("圓形", startCoordinate, endCoordinate, true);


            Assert.AreEqual(3, _shapes.GetShapeListInfo().Count);

            _shapes.DeleteShape(1);

            Assert.AreEqual(2, _shapes.GetShapeListInfo().Count);

            Assert.AreEqual("線", _shapes.GetShapeListInfo()[0]._column2);

            Assert.AreEqual("圓形", _shapes.GetShapeListInfo()[1]._column2);

            _shapes.DeleteShape(0);
            _shapes.DeleteShape(0);

            Assert.AreEqual(0, _shapes.GetShapeListInfo().Count);
        }

        //test FindSelectedShape
        [TestMethod()]
        public void FindSelectedShapeTest_Case1()
        {

            Point startCoordinate_0 = new Point(200, 40);
            Point endCoordinate_0 = new Point(300, 60);
            _shapes.CreateShape(randomShapeName(), startCoordinate_0, endCoordinate_0, true);

            Point startCoordinate_1 = new Point(350, 70);
            Point endCoordinate_1 = new Point(400, 100);
            _shapes.CreateShape(randomShapeName(), startCoordinate_1, endCoordinate_1, true);

            Point startCoordinate_2 = new Point(200, 40);
            Point endCoordinate_2 = new Point(400, 100);
            _shapes.CreateShape(randomShapeName(), startCoordinate_2, endCoordinate_2, true);

            Point mousePoint = new Point(377, 77);
            Assert.AreEqual(2, _shapes.FindSelectedShape(mousePoint.X, mousePoint.Y));

            Point badMousePoint = new Point(600, 111);
            Assert.AreEqual(-1, _shapes.FindSelectedShape(badMousePoint.X, badMousePoint.Y));
        }

        //Zoom select test
        [TestMethod()]
        public void ZoomSelectedShapeTest_Case1()
        {
            List<int> testPoints_0 = _random.first_case(0, X_MAX, Y_MAX);
            Point startCoordinate = new Point(testPoints_0[0], testPoints_0[2]);
            Point endCoordinate = new Point(testPoints_0[1], testPoints_0[3]);
            _shapes.CreateShape("線", startCoordinate, endCoordinate, true);


            List<int> testPoints_1 = _random.first_case(0, X_MAX, Y_MAX);
            startCoordinate = new Point(testPoints_1[0], testPoints_1[2]);
            endCoordinate = new Point(testPoints_1[1], testPoints_1[3]);
            _shapes.CreateShape("矩形", startCoordinate, endCoordinate, true);


            List<int> testPoints_2 = _random.first_case(0, X_MAX, Y_MAX);
            startCoordinate = new Point(100, 100);
            endCoordinate = new Point(300, 200);
            _shapes.CreateShape("圓形", startCoordinate, endCoordinate, true);


            Assert.AreEqual(3, _shapes.GetShapeListInfo().Count);

            _shapes.ZoomSelectedShape(2, 298, 198);
            _shapes.ZoomSelectedShape(4, 30, 80);
            _shapes.ZoomSelectedShape(-1, 30, 80);

        }

        //nice case
        [TestMethod()]
        public void MoveSelectedShapeTest_Case1()
        {
            List<int> testPoints_0 = _random.first_case(0, X_MAX, Y_MAX);
            Point startCoordinate = new Point(testPoints_0[0], testPoints_0[2]);
            Point endCoordinate = new Point(testPoints_0[1], testPoints_0[3]);
            _shapes.CreateShape("線", startCoordinate, endCoordinate, true);


            List<int> testPoints_1 = _random.first_case(0, X_MAX, Y_MAX);
            startCoordinate = new Point(testPoints_1[0], testPoints_1[2]);
            endCoordinate = new Point(testPoints_1[1], testPoints_1[3]);
            _shapes.CreateShape("矩形", startCoordinate, endCoordinate, true);


            List<int> testPoints_2 = _random.first_case(0, X_MAX, Y_MAX);
            startCoordinate = new Point(testPoints_2[0], testPoints_2[2]);
            endCoordinate = new Point(testPoints_2[1], testPoints_2[3]);
            _shapes.CreateShape("圓形", startCoordinate, endCoordinate, true);


            Assert.AreEqual(3, _shapes.GetShapeListInfo().Count);

            _shapes.Remove(1);
            _shapes.Remove(-1);
            _shapes.Remove(4);

            Assert.AreEqual(2, _shapes.GetShapeListInfo().Count);

            Assert.AreEqual("線", _shapes.GetShapeListInfo()[0]._column2);

            Assert.AreEqual("圓形", _shapes.GetShapeListInfo()[1]._column2);

            _shapes.Remove(0);
            _shapes.Remove(0);

            Assert.AreEqual(0, _shapes.GetShapeListInfo().Count);
        }

        //test DrawExistTest
        [TestMethod()]
        public void DrawExistTest()
        {
            List<int> testPoints_0 = _random.first_case(0, X_MAX, Y_MAX);
            Point startCoordinate = new Point(testPoints_0[0], testPoints_0[2]);
            Point endCoordinate = new Point(testPoints_0[1], testPoints_0[3]);
            _shapes.CreateShape("線", startCoordinate, endCoordinate, true);


            List<int> testPoints_1 = _random.first_case(0, X_MAX, Y_MAX);
            startCoordinate = new Point(testPoints_1[0], testPoints_1[2]);
            endCoordinate = new Point(testPoints_1[1], testPoints_1[3]);
            _shapes.CreateShape("矩形", startCoordinate, endCoordinate, true);


            List<int> testPoints_2 = _random.first_case(0, X_MAX, Y_MAX);
            startCoordinate = new Point(testPoints_2[0], testPoints_2[2]);
            endCoordinate = new Point(testPoints_2[1], testPoints_2[3]);
            _shapes.CreateShape("圓形", startCoordinate, endCoordinate, true);

            _shapes.DrawExist(_graphic);
        }

        //test DrawExistTest
        [TestMethod()]
        public void ZoomCoordinateResetTest()
        {
            List<int> testPoints_0 = _random.first_case(0, X_MAX, Y_MAX);
            Point startCoordinate = new Point(testPoints_0[0], testPoints_0[2]);
            Point endCoordinate = new Point(testPoints_0[1], testPoints_0[3]);
            _shapes.CreateShape("線", startCoordinate, endCoordinate, true);


            List<int> testPoints_1 = _random.first_case(0, X_MAX, Y_MAX);
            startCoordinate = new Point(testPoints_1[0], testPoints_1[2]);
            endCoordinate = new Point(testPoints_1[1], testPoints_1[3]);
            _shapes.CreateShape("矩形", startCoordinate, endCoordinate, true);


            List<int> testPoints_2 = _random.first_case(0, X_MAX, Y_MAX);
            startCoordinate = new Point(testPoints_2[0], testPoints_2[2]);
            endCoordinate = new Point(testPoints_2[1], testPoints_2[3]);
            _shapes.CreateShape("圓形", startCoordinate, endCoordinate, true);

            _shapes.ZoomCoordinateReset(2);
            _shapes.ZoomCoordinateReset(-1);
            _shapes.ZoomCoordinateReset(4);
        }

        //測試slide
        [TestMethod()]
        public void DrawSlideTest()
        {
            List<int> testPoints_0 = _random.first_case(0, X_MAX, Y_MAX);
            Point startCoordinate = new Point(testPoints_0[0], testPoints_0[2]);
            Point endCoordinate = new Point(testPoints_0[1], testPoints_0[3]);
            _shapes.CreateShape("線", startCoordinate, endCoordinate, true);


            List<int> testPoints_1 = _random.first_case(0, X_MAX, Y_MAX);
            startCoordinate = new Point(testPoints_1[0], testPoints_1[2]);
            endCoordinate = new Point(testPoints_1[1], testPoints_1[3]);
            _shapes.CreateShape("矩形", startCoordinate, endCoordinate, true);


            List<int> testPoints_2 = _random.first_case(0, X_MAX, Y_MAX);
            startCoordinate = new Point(testPoints_2[0], testPoints_2[2]);
            endCoordinate = new Point(testPoints_2[1], testPoints_2[3]);
            _shapes.CreateShape("圓形", startCoordinate, endCoordinate, true);

            _shapes.DrawSlide(_graphic, new Size(20, 40), new Size(40, 60));
        }

        //test drawSelectedShape
        [TestMethod()]
        public void DrawSelectedShapeTest()
        {
            List<int> testPoints_0 = _random.first_case(0, X_MAX, Y_MAX);
            Point startCoordinate = new Point(testPoints_0[0], testPoints_0[2]);
            Point endCoordinate = new Point(testPoints_0[1], testPoints_0[3]);
            _shapes.CreateShape("線", startCoordinate, endCoordinate, true);


            List<int> testPoints_1 = _random.first_case(0, X_MAX, Y_MAX);
            startCoordinate = new Point(testPoints_1[0], testPoints_1[2]);
            endCoordinate = new Point(testPoints_1[1], testPoints_1[3]);
            _shapes.CreateShape("矩形", startCoordinate, endCoordinate, true);


            List<int> testPoints_2 = _random.first_case(0, X_MAX, Y_MAX);
            startCoordinate = new Point(testPoints_2[0], testPoints_2[2]);
            endCoordinate = new Point(testPoints_2[1], testPoints_2[3]);
            _shapes.CreateShape("圓形", startCoordinate, endCoordinate, true);

            _shapes.DrawSelectedShape(_graphic, 2);
            _shapes.DrawSelectedShape(_graphic, 3);
            _shapes.DrawSelectedShape(_graphic, -1);
        }

        //nice case
        [TestMethod()]
        public void RemoveTest_Case1()
        {
            List<int> testPoints_0 = _random.first_case(0, X_MAX, Y_MAX);
            Point startCoordinate = new Point(testPoints_0[0], testPoints_0[2]);
            Point endCoordinate = new Point(testPoints_0[1], testPoints_0[3]);
            _shapes.CreateShape(randomShapeName(), startCoordinate, endCoordinate, true);


            List<int> testPoints_1 = _random.first_case(0, X_MAX, Y_MAX);
            startCoordinate = new Point(testPoints_1[0], testPoints_1[2]);
            endCoordinate = new Point(testPoints_1[1], testPoints_1[3]);
            _shapes.CreateShape(randomShapeName(), startCoordinate, endCoordinate, true);


            List<int> testPoints_2 = _random.first_case(0, X_MAX, Y_MAX);
            startCoordinate = new Point(testPoints_2[0], testPoints_2[2]);
            endCoordinate = new Point(testPoints_2[1], testPoints_2[3]);
            _shapes.CreateShape(randomShapeName(), startCoordinate, endCoordinate, true);

            Point diffPoint = new Point(20, 40);
            _shapes.MoveSelectedShape(1, diffPoint.X, diffPoint.Y);
        }

        //nowShape > count
        [TestMethod()]
        public void RemoveTest_Case2()
        {
            List<int> testPoints_0 = _random.first_case(0, X_MAX, Y_MAX);
            Point startCoordinate = new Point(testPoints_0[0], testPoints_0[2]);
            Point endCoordinate = new Point(testPoints_0[1], testPoints_0[3]);
            _shapes.CreateShape(randomShapeName(), startCoordinate, endCoordinate, true);


            List<int> testPoints_1 = _random.first_case(0, X_MAX, Y_MAX);
            startCoordinate = new Point(testPoints_1[0], testPoints_1[2]);
            endCoordinate = new Point(testPoints_1[1], testPoints_1[3]);
            _shapes.CreateShape(randomShapeName(), startCoordinate, endCoordinate, true);


            List<int> testPoints_2 = _random.first_case(0, X_MAX, Y_MAX);
            startCoordinate = new Point(testPoints_2[0], testPoints_2[2]);
            endCoordinate = new Point(testPoints_2[1], testPoints_2[3]);
            _shapes.CreateShape(randomShapeName(), startCoordinate, endCoordinate, true);

            Point diffPoint = new Point(20, 40);
            _shapes.MoveSelectedShape(4, diffPoint.X, diffPoint.Y);
        }

        //nowShape < 0
        [TestMethod()]
        public void RemoveTest_Case3()
        {
            List<int> testPoints_0 = _random.first_case(0, X_MAX, Y_MAX);
            Point startCoordinate = new Point(testPoints_0[0], testPoints_0[2]);
            Point endCoordinate = new Point(testPoints_0[1], testPoints_0[3]);
            _shapes.CreateShape(randomShapeName(), startCoordinate, endCoordinate, true);


            List<int> testPoints_1 = _random.first_case(0, X_MAX, Y_MAX);
            startCoordinate = new Point(testPoints_1[0], testPoints_1[2]);
            endCoordinate = new Point(testPoints_1[1], testPoints_1[3]);
            _shapes.CreateShape(randomShapeName(), startCoordinate, endCoordinate, true);


            List<int> testPoints_2 = _random.first_case(0, X_MAX, Y_MAX);
            startCoordinate = new Point(testPoints_2[0], testPoints_2[2]);
            endCoordinate = new Point(testPoints_2[1], testPoints_2[3]);
            _shapes.CreateShape(randomShapeName(), startCoordinate, endCoordinate, true);

            Point diffPoint = new Point(20, 40);
            _shapes.MoveSelectedShape(-1, diffPoint.X, diffPoint.Y);
        }

        //test Shapes
        [TestMethod()]
        public void ShapesTest()
        {
            Shapes _testShape = new Shapes();
        }
    }
}
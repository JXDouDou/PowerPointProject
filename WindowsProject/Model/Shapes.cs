using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PowerPointProject
{
    public class Shapes
    {//暫存的shape和shape list由他管
        private const string DELETE = "刪除";
        private Shape _shape;
        private Factory _factory;
        private List<Shape> _shapesNow;
        private double _startXCoordinate;
        private double _startYCoordinate;
        private double _endXCoordinate;
        private double _endYCoordinate;

        //create shape
        public void CreateShape(string shape, Point startCoordinate, Point endCoordinate, bool mode)
        {
            if (!mode)
            {
                _factory.CoordinateRandom(ref _startXCoordinate, ref _startYCoordinate, ref _endXCoordinate, ref _endYCoordinate);
                Point startPoint = new Point(_startXCoordinate, _startYCoordinate);
                Point endPoint = new Point(_endXCoordinate, _endYCoordinate);
                _shape = _factory.CreateShape(shape, startPoint, endPoint);
                _shapesNow.Add(_shape);
            }
            else
            {
                _shape = _factory.CreateShape(shape, startCoordinate, endCoordinate);
                _shapesNow.Add(_shape);
            }
        }

        //check Right Down is selected or not
        public bool CheckAtRightDown(double nowX, double nowY, int nowShapeSelected)
        {
            Point mousePosition = new Point(nowX, nowY);
            return _shapesNow[nowShapeSelected].IsRightDownSelected(mousePosition);
        }

        //hint shape create
        public Shape CreateHintShape(string shape, Point startCoordinate, Point endCoordinate)
        {
            return _shape = _factory.CreateShape(shape, startCoordinate, endCoordinate);
        }

        /*//return _shapesNow裡剛創的_shape的information
        public List<string> GetShapeInfo()
        {
            return _shape.GetInfo();
        }*/

        //return shapes grid view columns content
        public List<ShapeGridViewColumns> GetShapeListInfo()
        {
            List<ShapeGridViewColumns> shapeListData = _shapesNow.Select(shape => new ShapeGridViewColumns
            { 
                _column1 = DELETE,
                _column2 = shape.GetShapeName(),
                _column3 = shape.GetCoordinate() }).ToList();
            return shapeListData;
        }

        //delete now_shape
        public void DeleteShape(int rowIndex)
        {
            _shapesNow.RemoveAt(rowIndex);
        }

        // 尋找被選取的 shape
        public int FindSelectedShape(double nowX, double nowY)
        {
            Point nowPosition = new Point(nowX, nowY);
            int indexNow = _shapesNow.Count() - 1;
            for (; indexNow >= 0; indexNow--)
            {
                if (_shapesNow[indexNow].IsSelected(nowPosition))
                    return indexNow;
            }
            return indexNow;
        }

        // move selected shape
        public void MoveSelectedShape(int nowShape, double diffX, double diffY)
        {
            if (nowShape >= 0 && nowShape < _shapesNow.Count())
                _shapesNow[nowShape].Move(diffX, diffY);
        }

        // draw shapes
        public void DrawExist(IGraphics graphics)
        {
            foreach (Shape aShape in _shapesNow)
                aShape.Draw(graphics);
        }

        // draw existed shape list
        public void DrawSlide(IGraphics graphics, Size panelSize, Size slideSize)
        {
            foreach (Shape aShape in _shapesNow)
                aShape.DrawSlide(graphics, panelSize, slideSize);
        }

        // draw selected shape's outlook
        public void DrawSelectedShape(IGraphics graphics, int nowShape)
        {
            if (nowShape >= 0 && nowShape < _shapesNow.Count())
                _shapesNow[nowShape].DrawSelectedOutlook(graphics);
        }

        //remove now shape
        public void Remove(int nowShapeSelected)
        {
            if (nowShapeSelected >= 0 && nowShapeSelected < _shapesNow.Count())
                _shapesNow.RemoveAt(nowShapeSelected);
        }

        public Shapes()
        {
            _factory = new Factory();
            _shapesNow = new List<Shape>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PowerPointProject
{//只要被改了就用NotifyModelChanged()事件通知每個view以ModelChange()(此為事件)通知view去呼叫OnPaint再讓Model的Draw重新被called來實際畫圖
    public class ModelOfDataGridView : IModel
    {
        public delegate void ModelChangedEventHandler();
        public event ModelChangedEventHandler _modelChanged;
        const int SLIDE_WIDTH = 100;
        const int SLIDE_HEIGHT = 57;

        private const int PANEL_WIDTH = 941;
        private const int PANEL_HEIGHT = 482;
        private bool _rightDownCheck = false;
        const string RECTANGLE = "矩形";
        const string LINE = "線";
        const string CIRCLE = "圓形";
        const int OUT_OF_LIST = -1;
        /*private double _startXCoordinate;
        private double _startYCoordinate;
        private double _endXCoordinate;
        private double _endYCoordinate;*/

        private Shapes _shapes = new Shapes();
        //int _nowShapeSelected;
        public int _nowShapeSelected
        {
            get;
            set;
        }
        //List<Shape> _shape = new List<Shape>();

        IState _state;
        //Model自定義
        public ModelOfDataGridView()
        {//this是model
            PointMode();
            _shapes = new Shapes();
        }

        //設置成drawing mode
        public void DrawingMode()
        {
            _state = new DrawingState(this);
        }

        //設置成point mode
        public void PointMode()
        {
            _state = new PointState(this);
        }

        //處理滑鼠按下
        public void PressedPointer(string shapeName, double firstX, double firstY)
        {
            _state.PressedPointer(shapeName, firstX, firstY);
        }

        //處理滑鼠移動
        public void MovedPointer(double nowX, double nowY)
        {//即使view->presentationModel->Model 也可以用notify去通知view
            _state.MovedPointer(nowX, nowY);
            NotifyModelChanged();
        }

        //處理滑鼠放開
        public void ReleasedPointer(string shapeName, double lastX, double lastY)
        {
            _state.ReleasedPointer(shapeName, lastX, lastY);
            NotifyModelChanged();
        }

        //process shape moving
        public void ShapeMoving(double diffX, double diffY)
        {
            _shapes.MoveSelectedShape(_nowShapeSelected, diffX, diffY);
            NotifyModelChanged();
        }

        //清除
        /*public void Clear()
        {
            _isPressed = false;
            _lines.Clear();
            NotifyModelChanged();
        }*/

        //繪圖
        public void Draw(IGraphics graphics)
        {
            _shapes.DrawExist(graphics);
            _state.Draw(graphics);
        }

        // 繪製圖縮
        public void DrawSlide(IGraphics graphics)
        {
            graphics.ClearAll();
            _shapes.DrawSlide(graphics, new Size(PANEL_WIDTH, PANEL_HEIGHT), new Size(SLIDE_WIDTH, SLIDE_HEIGHT));
        }

        //create shape
        public void CreateShapes(string shape)
        {
            if (shape != RECTANGLE && shape != LINE && shape != CIRCLE)
            {
                return;
            }
            Point startCoordinate = new Point(-1, -1);
            Point endCoordinate = new Point(-1, -1);
            _shapes.CreateShape(shape, startCoordinate, endCoordinate, false);
            NotifyModelChanged();
        }

        //處理滑鼠的圖像生成
        public void CreateShapesForMouse(string shape, Point startCoordinate, Point endCoordinate)
        {
            if (shape != RECTANGLE && shape != LINE && shape != CIRCLE)
            {
                return;
            }
            _shapes.CreateShape(shape, startCoordinate, endCoordinate, true);
            NotifyModelChanged();
        }

        // check selected
        public bool CheckSelectedShape(double nowX, double nowY)
        {
            _nowShapeSelected = _shapes.FindSelectedShape(nowX, nowY);
            //在這加呼叫測試哪個state的座標計算
            if (_nowShapeSelected == OUT_OF_LIST)
            {
                return false;
            }
            return true;
        }

        // check Corner selected
        public bool CheckAtRightDown(double nowX, double nowY)
        {
            _rightDownCheck = _shapes.CheckAtRightDown(nowX, nowY, _nowShapeSelected);
            return _rightDownCheck;
        }

        //draw selected shape
        public void DrawSelectedShape(IGraphics graphics)
        {
            _shapes.DrawSelectedShape(graphics, _nowShapeSelected);
        }

        // move selected shape
        public void MoveShape(double nowX, double nowY)
        {
            _shapes.MoveSelectedShape(_nowShapeSelected, nowX, nowY);
            NotifyModelChanged();
        }

        //return data grid view content
        public List<ShapeGridViewColumns> GetModelGridView()
        {
            return _shapes.GetShapeListInfo();
        }

        //delete now_shape by dataGridView
        public void DeleteShape(int rowIndex)
        {
            _shapes.DeleteShape(rowIndex);
            NotifyModelChanged();
        }

        // pressed delete key
        public void PressDeleteKey()
        {
            _shapes.Remove(_nowShapeSelected);
            _nowShapeSelected = OUT_OF_LIST;
            NotifyModelChanged();
        }

        //通知view Model改變了
        public void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
    }
}

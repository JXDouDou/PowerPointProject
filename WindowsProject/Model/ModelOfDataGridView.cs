using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using WindowsProject.Model;
using WindowsProject.Model.Command;

namespace PowerPointProject
{//只要被改了就用NotifyModelChanged()事件通知每個view以ModelChange()(此為事件)通知view去呼叫OnPaint再讓Model的Draw重新被called來實際畫圖
    public class ModelOfDataGridView : IModel
    {
        public delegate void ModelChangedEventHandler();
        public event ModelChangedEventHandler _modelChanged;
        private const int X_MAX_SLIDE = 201;
        private const int Y_MAX_SLIDE = 120;
        int _nowSlideWidth = X_MAX_SLIDE;
        int _nowSlideHeight = Y_MAX_SLIDE;
        int _nowShapeSelected = -1;
        private const int X_MAX_PANEL = 788;
        private const int Y_MAX_PANEL = 443;
        private int _nowPanelWidth = X_MAX_PANEL;
        private int _nowPanelHeight = Y_MAX_PANEL;
        private bool _rightDownCheck = false;
        const string RECTANGLE = "矩形";
        const string LINE = "線";
        const string CIRCLE = "圓形";
        const int OUT_OF_LIST = -1;
        //Size _realPanelSize;
        Factory _factory = new Factory();
        CommandManager _commandManager = new CommandManager();
        private double _startXCoordinate;
        private double _startYCoordinate;
        private double _endXCoordinate;
        private double _endYCoordinate;

        private Shapes _shapes;
        //int _nowShapeSelected;
        public int NowShapeSelected
        {
            get
            {
                return _nowShapeSelected;
            }
            set
            {
                _nowShapeSelected = value;
            }
        }

        public int NowPanelWidth
        {
            set
            {
                _nowPanelWidth = value;
            }
        }

        public int NowPanelHeight
        {
            set
            {
                _nowPanelHeight = value;
            }
        }

        public int NowSlideWidth
        {
            set
            {
                _nowSlideWidth = value;
            }
        }

        public int NowSlideHeight
        {
            set
            {
                _nowSlideHeight = value;
            }
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

        //process zooming
        public void ShapeZooming(double nowX, double nowY)
        {
            _shapes.ZoomSelectedShape(NowShapeSelected, nowX, nowY);
        }

        //process shape moving
        public void ShapeMoving(double diffX, double diffY)
        {
            _shapes.MoveSelectedShape(NowShapeSelected, diffX, diffY);
            NotifyModelChanged();
        }

        //reset point of zoom
        public void ZoomCoordinateReset()
        {
            _shapes.ZoomCoordinateReset(NowShapeSelected);
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
            _shapes.DrawSlide(graphics, new Size(_nowPanelWidth, _nowPanelHeight), new Size(_nowSlideWidth, _nowSlideHeight));
        }

        //create shape by random coordinate
        public void CreateShapes(string shape, Point startPosition, Point endPosition)
        {
            if (shape != RECTANGLE && shape != LINE && shape != CIRCLE)
            {
                return;
            }
            _commandManager.Execute(new AddCommand(this, shape, startPosition, endPosition));
            NotifyModelChanged();
        }

        //處理滑鼠的圖像生成
        public void CreateShapesForMouse(string shape, Point startCoordinate, Point endCoordinate)
        {
            if (shape != RECTANGLE && shape != LINE && shape != CIRCLE)
            {
                return;
            }
            _commandManager.Execute(new DrawCommand(this, shape, startCoordinate, endCoordinate));
            NotifyModelChanged();
        }

        //方便command用的createShape
        public void CallCreateShape(string shape, Point startCoordinate, Point endCoordinate)
        {
            _shapes.CreateShape(shape, startCoordinate, endCoordinate, true);
        }

        //刪除最後一個shape
        public void DeleteLastShape()
        {
            _shapes.RemoveLastShape();
        }

        // check selected
        public bool CheckSelectedShape(double nowX, double nowY)
        {
            NowShapeSelected = _shapes.FindSelectedShape(nowX, nowY);
            //在這加呼叫測試哪個state的座標計算
            if (NowShapeSelected == OUT_OF_LIST)
            {
                return false;
            }
            return true;
        }

        // check Corner selected
        public bool CheckAtRightDown(double nowX, double nowY)
        {
            if (NowShapeSelected != OUT_OF_LIST)
            {
                _rightDownCheck = _shapes.CheckAtRightDown(nowX, nowY, NowShapeSelected);
                return _rightDownCheck;
            }
            return false;
        }

        //draw selected shape
        public void DrawSelectedShape(IGraphics graphics)
        {
            _shapes.DrawSelectedShape(graphics, NowShapeSelected);
        }

        // move selected shape(其實我沒用到= =)
        public void MovedShape(double nowX, double nowY)
        {
            _shapes.MoveSelectedShape(NowShapeSelected, nowX, nowY);
            NotifyModelChanged();
        }

        // move command
        public void MoveCommand(int selectedIndex, Shape originShape, Shape movedShape)
        {
            _commandManager.Execute(new MoveCommand(this, selectedIndex, originShape, movedShape));
        }

        //return data grid view content
        public List<ShapeGridViewColumns> GetModelGridView()
        {
            return _shapes.GetShapeListInfo();
        }

        //delete now_shape by dataGridView
        public void DeleteShape(int rowIndex)
        {
            Shapes nowShapes = GetShapes();
            Shape deleteShape = nowShapes.GetShape(rowIndex);
            _commandManager.Execute(new DeleteCommand(this, rowIndex, deleteShape));
            NotifyModelChanged();
        }

        //get selected shape for move command
        public Shape GetSelectedShape(int selectedIndex)
        {
            Shapes shapes = GetShapes();
            return shapes.GetShape(selectedIndex);
        }

        // get shapes
        public Shapes GetShapes()
        {
            return _shapes;
        }

        //delete command的ReverseExecute
        public void AddShape(int pushIndex, Shape pushShape)
        {
            _shapes.AddShape(pushIndex, pushShape);
        }

        // pressed delete key
        public void PressDeleteKey()
        {
            _shapes.Remove(NowShapeSelected);
            NowShapeSelected = OUT_OF_LIST;
            NotifyModelChanged();
        }

        //replace selected shape with new shpae
        public void ReplaceShape(int nowSelect, Shape targetShape)
        {
            _shapes.ReplaceShape(nowSelect, targetShape);
        }

        //return is RedoCount !0 or not
        public bool IsRedoEnabled
        {
            get
            {
                return _commandManager.IsRedoEnabled;
            }
        }

        //return is UndoCount !0 or not
        public bool IsUndoEnabled
        {
            get
            {
                return _commandManager.IsUndoEnabled;
            }
        }

        //do undo
        public void Undo()
        {
            _commandManager.Undo();
        }

        //do redo
        public void Redo()
        {
            _commandManager.Redo();
        }

        //通知view Model改變了
        public void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
    }
}

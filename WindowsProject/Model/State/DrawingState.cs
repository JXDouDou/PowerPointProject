using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointProject
{
    public class DrawingState : IState
    {
        Shape _hint;
        ModelOfDataGridView _model;
        double _startXCoordinate;
        double _startYCoordinate;
        double _endXCoordinate;
        double _endYCoordinate;
        //get set _isPressed
        public bool _isPressed
        {
            get;
            set;
        }

        private Shapes _shapes = new Shapes();

        public DrawingState(ModelOfDataGridView model)
        {
            this._model = model;
        }
        // pressedMouse
        public void PressedPointer(string shapeName, double firstX, double firstY)
        {
            if (shapeName != null)
            {
                _startXCoordinate = firstX;
                _startYCoordinate = firstY;
                Point startPoint = new Point(firstX, firstY);
                _hint = _shapes.CreateHintShape(shapeName, startPoint, startPoint);
                _isPressed = true;//可以想辦法弄掉
            }
        }

        // MouseMoved
        public void MovedPointer(double nowX, double nowY)
        {
            if (_isPressed)
            {
                Point endPoint = new Point(nowX, nowY);
                _hint.SetEndCoordinate(endPoint);
            }
        }

        // MouseReleased
        public void ReleasedPointer(string shapeName, double lastX, double lastY)
        {
            if (_isPressed && shapeName != null)//放下就把剛創的shape真的加進shapeList
            {
                _isPressed = false;
                Point startPoint = new Point(_startXCoordinate, _startYCoordinate);
                Point endPoint = new Point(lastX, lastY);
                _endXCoordinate = lastX;
                _endYCoordinate = lastY;
                _hint.SetStartCoordinate(startPoint);
                _hint.SetEndCoordinate(endPoint);
                _model.CreateShapesForMouse(shapeName, startPoint, endPoint);
            }
        }

        // drawing graphic
        public void Draw(IGraphics graphics)
        {
            if (_isPressed)
            {
                _hint.Draw(graphics);
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointProject
{
    public class PointState : IState
    {
        ModelOfDataGridView _model;
        bool _shapeSelected = false;
        bool _checkRightDown = false;
        double _startXCoordinate;
        double _startYCoordinate;
        double _startXCoordinateZoom;
        double _startYCoordinateZoom;
        /*double _endXCoordinate;
        double _endYCoordinate;*/
        //get set _isPressed
        public bool _isPressed
        {
            get;
            set;
        }

        public PointState(ModelOfDataGridView model)
        {
            this._model = model;
        }

        private Shapes _shapes = new Shapes();
        // pressedMouse
        public void PressedPointer(string shapeName, double nowX, double nowY)
        {
            _shapeSelected = _model.CheckSelectedShape(nowX, nowY);
            _checkRightDown = _model.CheckAtRightDown(nowX, nowY);
            if (_shapeSelected) 
            {
                if (_checkRightDown)
                {
                    _startXCoordinateZoom = nowX;
                    _startYCoordinateZoom = nowY;
                }
                else
                {
                    _startXCoordinate = nowX;
                    _startYCoordinate = nowY;
                }
            }
            _isPressed = true;
        }

        // MouseMoved
        public void MovedPointer(double nowX, double nowY)
        {
            if (_isPressed && _shapeSelected)
            {
                if (_checkRightDown)
                {
                    _model.ShapeZooming(nowX, nowY);
                }
                else
                {
                    _model.ShapeMoving(nowX - _startXCoordinate, nowY - _startYCoordinate);
                    _startXCoordinate = nowX;
                    _startYCoordinate = nowY;
                }
            }
        }

        // MouseReleased
        public void ReleasedPointer(string shapeName, double lastX, double lastY)
        {
            _isPressed = false;
        }

        // drawing graphic
        public void Draw(IGraphics graphics)
        {
            _model.DrawSelectedShape(graphics);
        }
    }
}

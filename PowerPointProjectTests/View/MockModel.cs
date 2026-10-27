using PowerPointProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointProjectTests.Model.State
{
    public class MockModel : IModel
    {
        public int _pressedMouse;

        public int NowShapeSelected
        {
            get;
        }

        public MockModel()
        {
            _pressedMouse = 0;
        }

        //MockModel Draw
        public void Draw(IGraphics graphics)
        {
            return;
        }

        //MockModel Drawing Mode
        public void DrawingMode()
        {
            return;
        }

        //MockModel DrawSlide
        public void DrawSlide(IGraphics graphics)
        {
            return;
        }

        //MockModel DrawSlide
        public void PointMode()
        {
            return;
        }

        //MockModel check selected shape
        public bool CheckSelectedShape(double nowX, double nowY)
        {
            if(nowX <= 500 && nowY <= 250)
            {
                return false;
            }
            return true;
        }

        //MockModel check at corner
        public bool CheckAtRightDown(double nowX, double nowY)
        {
            if (nowX <= 500 && nowY <= 250)
            {
                return false;
            }
            return true;
        }

        //MockModel Shape Zooming
        public void ShapeZooming(double nowX, double nowY)
        {
            return;
        }

        //MockModel Shape moving
        public void ShapeMoving(double nowX, double nowY)
        {
            return;
        }

        //MockModel zoom coordinate reset
        public void ZoomCoordinateReset()
        {
            return;
        }

        //MockModel Draw selected shape
        public void DrawSelectedShape(IGraphics graphics)
        {
            return;
        }

        //MockModel Press Delete Key
        public void PressDeleteKey()
        {
            return;
        }

        //MockModel Pressed Pointer
        public void PressedPointer(string shapeName, double firstX, double firstY)
        {
            _pressedMouse++;
            return;
        }

        //MockModel Released Pointer
        public void ReleasedPointer(string shapeName, double lastX, double lastY)
        {
            return;
        }

        //mockmodel replace shape
        public void ReplaceShape(int selectedIndex, Shape movedShape)
        {
            throw new NotImplementedException();
        }

        //mockmodel call create shape
        public void CallCreateShape(string shape, Point startCoordinate, Point endCoordinate)
        {
            throw new NotImplementedException();
        }

        //mock getShape
        public Shapes GetShapes()
        {
            throw new NotImplementedException();
        }

        //mock deleteLastShape
        public void DeleteLastShape()
        {
            throw new NotImplementedException();
        }

        //mock addShape
        public void AddShape(int selectedIndex, Shape deleteShape)
        {
            throw new NotImplementedException();
        }

        //mock notifyModelChange
        public void NotifyModelChanged()
        {
            throw new NotImplementedException();
        }

        //mock getSelectedShape
        public Shape GetSelectedShape(int selectIndex)
        {
            throw new NotImplementedException();
        }

        //mock moveCommand
        public void MoveCommand(int selectIndex, Shape originShape, Shape movedShape)
        {
            throw new NotImplementedException();
        }
    }
}


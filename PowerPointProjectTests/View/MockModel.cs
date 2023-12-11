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

        //MockModel Point Mode
        public void PointMode()
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

    }
}


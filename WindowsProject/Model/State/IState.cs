using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPointProject
{ 
    public interface IState
    {
        // pressedMouse
        void PressedPointer(string shapeName, double firstX, double firstY);

        // MouseMoved
        void MovedPointer(double nowX, double nowY);

        // MouseReleased
        void ReleasedPointer(string shapeName, double lastX, double lastY);

        // drawing graphic
        void Draw(IGraphics graphics);
    }
}

namespace PowerPointProject
{
    public interface IModel
    {
        //IModel Draw
        void Draw(IGraphics graphics);

        //IModel Drawing Mode
        void DrawingMode();

        //IModel DrawSlide
        void DrawSlide(IGraphics graphics);

        //IModel Point Mode
        void PointMode();

        //IModel Press Delete Key
        void PressDeleteKey();

        //IModel Pressed Pointer
        void PressedPointer(string shapeName, double firstX, double firstY);

        //IModel Released Pointer
        void ReleasedPointer(string shapeName, double lastX, double lastY);
    }
}
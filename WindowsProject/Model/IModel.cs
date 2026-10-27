namespace PowerPointProject
{
    public interface IModel
    {
        //model存著的選到的圖形的get set
        int NowShapeSelected
        { 
            get;
        }

        //IModel Draw
        void Draw(IGraphics graphics);

        //IModel Drawing Mode
        void DrawingMode();

        //IModel DrawSlide
        void DrawSlide(IGraphics graphics);

        //IModel Point Mode
        void PointMode();

        //IModel check selected shape
        bool CheckSelectedShape(double nowX, double nowY);

        //IModel check at corner
        bool CheckAtRightDown(double nowX, double nowY);

        //IModel shape zooming
        void ShapeZooming(double nowX, double nowY);

        //replace shape for moving
        void ReplaceShape(int selectedIndex, Shape movedShape);

        //IModel shape moving
        void ShapeMoving(double nowX, double nowY);

        //方便command用的createShape
        void CallCreateShape(string shape, Point startCoordinate, Point endCoordinate);

        //回傳整個shapes方便取得或更改shapeList
        Shapes GetShapes();

        //刪除最後一個shape
        void DeleteLastShape();

        //for command
        void AddShape(int selectedIndex, Shape deleteShape);

        //方便command寫的
        void NotifyModelChanged();

        //IModel shape moving
        void ZoomCoordinateReset();

        //IModel shape moving
        void DrawSelectedShape(IGraphics graphics);

        //IModel Press Delete Key
        void PressDeleteKey();

        //IModel Pressed Pointer
        void PressedPointer(string shapeName, double firstX, double firstY);

        //IModel Released Pointer
        void ReleasedPointer(string shapeName, double lastX, double lastY);

        //get shape selected
        Shape GetSelectedShape(int selectIndex);

        //處理moveCommand
        void MoveCommand(int selectIndex, Shape originShape, Shape movedShape);
    }
}
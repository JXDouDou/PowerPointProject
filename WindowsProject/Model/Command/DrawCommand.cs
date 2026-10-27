using PowerPointProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsProject.Model.Command
{
    class DrawCommand : ICommand
    {
        IModel _model;
        private Point _startPoint;
        private Point _endPoint;
        private string _shapeName;

        //draw Command
        public DrawCommand(IModel model, string shapeName, Point startPoint, Point endPoint)
        {
            this._model = model;
            _shapeName = shapeName;
            _startPoint = startPoint;
            _endPoint = endPoint;
        }

        //執行
        public void Execute()
        {
            _model.CallCreateShape(_shapeName, _startPoint, _endPoint);
        }

        //反執行
        public void ReverseExecute()
        {
            _model.DeleteLastShape();//刪最後一個圖形(要Undo一定是對這時候的最後一個圖形)
        }
    }
}

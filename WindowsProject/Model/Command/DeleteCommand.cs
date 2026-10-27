using PowerPointProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsProject.Model.Command
{
    class DeleteCommand : ICommand
    {
        IModel _model;
        private Shape _deleteShape;
        private int _selectedIndex;

        //deleteCommand
        public DeleteCommand(IModel model, int selectedIndex, Shape deleteShape)
        {
            this._model = model;
            this._deleteShape = deleteShape;
            _selectedIndex = selectedIndex;
        }

        //execute
        public void Execute()
        {
            _model.GetShapes().Remove(_selectedIndex);
            _model.NotifyModelChanged();
        }

        //reverseExecute
        public void ReverseExecute()
        {
            _model.AddShape(_selectedIndex, _deleteShape);
            _model.NotifyModelChanged();
        }
    }
}

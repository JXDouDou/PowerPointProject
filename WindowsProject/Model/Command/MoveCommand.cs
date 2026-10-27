using PowerPointProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsProject.Model.Command
{
    class MoveCommand : ICommand
    {
        IModel _model;
        private Shape _originShape;
        private Shape _movedShape;
        private int _selectedIndex;

        //move Command
        public MoveCommand(IModel model, int selectedIndex, Shape originShape, Shape movedShape)
        {
            this._model = model;
            this._originShape = originShape;
            this._movedShape = movedShape;
            _selectedIndex = selectedIndex;
        }

        //執行
        public void Execute()
        {
            _model.ReplaceShape(_selectedIndex, _movedShape);
            _model.NotifyModelChanged();
        }

        //反執行
        public void ReverseExecute()
        {
            _model.ReplaceShape(_selectedIndex, _originShape);
            _model.NotifyModelChanged();
        }
    }
}

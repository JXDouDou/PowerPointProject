using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsProject.Model
{
    public interface ICommand
    {
        //execute
        void Execute();

        //ReverseExecute
        void ReverseExecute();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            GridController ctrl = new GridController(3);
            GridView view = ctrl.ResponseView();
            view.DisplayGrid();
            
        }
    }
}

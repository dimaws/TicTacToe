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
            int size = 3;
            GridView view = new GridView(size);
            view.DisplayGrid();
            
        }
    }
}

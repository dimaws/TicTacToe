using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class GridView
    {
        // TODO реализовать слушателя/подписчика
        GridModel myGridModel;
        public GridView(GridModel myGridModel)
        {
            this.myGridModel = myGridModel;
        }
        public void DisplayGrid()
        {
            Console.Clear();

            for (int i = 0; i < myGridModel.Grid.Count; i++)
            {
                for (int j = 0; j < myGridModel.Grid.Count; j++)
                    Console.Write(myGridModel.Grid[i][j].ToString() + "\t");
                Console.WriteLine();  
            }

            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}

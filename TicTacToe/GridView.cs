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
        GridModel      myGridModel;
        GridController myGridController;

        public GridView(int sizeOfSide)
        {
            this.myGridController = new GridController(sizeOfSide);
            this.getModel();
            this.myGridController.view = this;
        }

        public void getModel()
        {
            this.myGridModel = myGridController.ResponseModel();
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
            Console.WriteLine("Ход Х: введите координаты ячейки:");

            myGridController.makeStep(getCell(Console.ReadLine().Split(' ')), ECellType.X);
            
        }
        Cell getCell(string[] str)
        {
            // TODO проверка данных в str на корректность 

            int i = Int32.Parse(str[0])-1;
            int j = Int32.Parse(str[1])-1;

            return myGridModel.Grid[i][j];
        }

    }
}

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
        GridModel myGridModel { get; set; }
        GridController myGridController { get; set; }

        public GridView(int sizeOfSide)
        {
            this.myGridController = new GridController(sizeOfSide);
            this.getModel();
            this.myGridController.view = this;
        }
        public void getModel()
        {
            this.myGridModel = myGridController.model;
        }
        public void DisplayGrid(string notifyMessage = "")
        {
            Console.Clear();

            for (int i = 0; i < myGridModel.getSizeOfSide() ; i++)
            {
                for (int j = 0; j < myGridModel.getSizeOfSide(); j++)
                    Console.Write("\t" + myGridModel.getCell(i, j).ToString());
                Console.WriteLine();  
            }

            switch (myGridModel.winner)
            {
                case ECellType.X: 
                    Console.WriteLine("Победили крестики.");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                case ECellType.O:
                    Console.WriteLine("Победили нолики.");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                case ECellType.Empty:
                    if (myGridModel.countOfEmptyCells <= 0)
                    {
                        Console.WriteLine("Ничья.");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    break;
            }

            Console.WriteLine();
            if (notifyMessage != "")
            {
                Console.Beep(150, 250);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(notifyMessage);
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else Console.WriteLine();

            Console.WriteLine("Введите координаты ячейки:");

            myGridController.makeStep(Console.ReadLine());
            
        }
        
    }
}

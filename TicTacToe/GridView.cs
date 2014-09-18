﻿using System;
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
        public void DisplayGrid(string notifyMessage = "")
        {
            Console.Clear();

            for (int i = 0; i < myGridModel.Grid.Count; i++)
            {
                for (int j = 0; j < myGridModel.Grid.Count; j++)
                    Console.Write("\t" + myGridModel.Grid[i][j].ToString());
                Console.WriteLine();  
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

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
            GridModel myGridModel = new GridModel(3);
            
            
            
            
            
            
            
            
            
            
            
            /* 18/09/2014: test
            for (int i = 0; i < myGridModel.Grid.Count; i++)
            {
                for (int j = 0; j < myGridModel.Grid.Count; j++)
                    Console.Write(myGridModel.Grid[i][j].ToString() + "\t");
                Console.WriteLine();  
            }
            */
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Grid
    {
        List<List<Cell>> grid;
        public int numberOfCells { get; private set; }
        public int sizeOfSide { get; private set; }

        public Grid(int sizeOfSide)
        {
            grid = new List<List<Cell>>(sizeOfSide);

            for (int i = 0; i < sizeOfSide; i++)
            {
                List<Cell> temp = new List<Cell>(sizeOfSide);
                for (int j = 0; j < sizeOfSide; j++)
                    temp.Add(new Cell());
                grid.Add(temp);
            }

            this.sizeOfSide = sizeOfSide;
            this.numberOfCells = sizeOfSide * sizeOfSide;
        }
        public Cell getCell(int row, int col)
        {
            return this.grid[row][col];
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class GridModel
    {
        public List<List<Cell>> Grid { get; set; } // Двумерный массив сетка игрового поля
        private int countOfEmptyCells; // счетчик оставшихся пустых ячеек, чтобы понять когда игра кончится.
        private ECellType currentPlayer = ECellType.X;

        public GridModel(int sizeOfSide)
        {
            // sizeOfSide - размер квадратного поля по одной стороне
            Grid = new List<List<Cell>>(sizeOfSide);
            for (int i = 0; i < sizeOfSide; i++)
            {
                List<Cell> temp = new List<Cell>(sizeOfSide);
                for (int j = 0; j < sizeOfSide; j++)
                    temp.Add(new Cell());
                Grid.Add(temp);
            }
            countOfEmptyCells = sizeOfSide * sizeOfSide;
        }
        bool checkStep(Cell cell, ECellType type)
        {
            if (cell.getState() == ECellType.Empty && type != ECellType.Empty)
                return true;
            return false;
        }

        public bool Step(Cell cell)
        {
            ECellType type = this.currentPlayer;
            if (!checkStep(cell, type))
                return false;
                
            cell.setState(type);
            countOfEmptyCells--;
            changeCurrentPlayer();
            return true;
            // TODO оповестить подписчиков об изменении модели
        }
        void changeCurrentPlayer()
        {
            switch(this.currentPlayer){
                case ECellType.X: 
                    this.currentPlayer = ECellType.O; 
                    break;
                case ECellType.O: 
                    this.currentPlayer = ECellType.X; 
                    break;
            }

        }

    }
}
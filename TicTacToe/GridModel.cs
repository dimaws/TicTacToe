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
        public int countOfEmptyCells; // счетчик оставшихся пустых ячеек, чтобы понять когда игра кончится.
        private ECellType currentPlayer = ECellType.X;
        public ECellType winner = ECellType.Empty;
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

        //public bool Step(Cell cell)
        public bool Step(int row, int col)
        {
            Cell cell = this.Grid[row][col];
            ECellType type = this.currentPlayer;
            if (!checkStep(cell, type))
                return false;
                
            cell.setState(type);
            countOfEmptyCells--;
            this.winner = checkWinner1(row, col);
            changeCurrentPlayer();
            return true;
            // TODO оповестить подписчиков об изменении модели
        }

        

        void changeCurrentPlayer()
        {
            switch(this.currentPlayer)
            {
                case ECellType.X: 
                    this.currentPlayer = ECellType.O; 
                    break;
                case ECellType.O: 
                    this.currentPlayer = ECellType.X; 
                    break;
            }
        }

        ECellType checkWinner(int row, int col)
        {
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //ПЕРЕДЕЛАТЬ ЭТОТ УЖАСНЫЙ КОД
            // VERY VERY BAD CODE, need rewrite

            Cell currentCell = this.Grid[ row ][ col ];

            // горизонтально
            List<List<Cell>> winningCombination = new List<List<Cell>>();
            List<Cell> temp;
            
            // вертикальные комбинации
            if ((row - 1 >= 0) && (row + 1 < this.Grid.Count))
            {
                temp = new List<Cell>(3);
                temp.Add(this.Grid[row][col]);
                temp.Add(this.Grid[row - 1][col]);
                temp.Add(this.Grid[row + 1][col]);
                winningCombination.Add(temp);
            }
            if ((row -1 >=0) && (row - 1 - 1 >=0))
            {
                temp = new List<Cell>(3);
                temp.Add(this.Grid[row][col]);
                temp.Add(this.Grid[row-1][col]);
                temp.Add(this.Grid[row-1-1][col]);
                winningCombination.Add(temp);
            }
            if ((row +1 < this.Grid.Count) && (row + 1 + 1 < this.Grid.Count))
            {
                temp = new List<Cell>(3);
                temp.Add(this.Grid[row][col]);
                temp.Add(this.Grid[row + 1][col]);
                temp.Add(this.Grid[row + 1 + 1][col]);
                winningCombination.Add(temp);
            }
            // горизонтальные комбинации
            if ((col - 1 >= 0) && (col + 1 < this.Grid.Count))
            {
                temp = new List<Cell>(3);
                temp.Add(this.Grid[row][col]);
                temp.Add(this.Grid[row][col - 1]);
                temp.Add(this.Grid[row][col + 1]);
                winningCombination.Add(temp);
            }
            if ((col - 1 >=0) && (col - 1 - 1 >=0))
            {
                temp = new List<Cell>(3);
                temp.Add(this.Grid[row][col]);
                temp.Add(this.Grid[row][col - 1]);
                temp.Add(this.Grid[row][col - 1 - 1]);
                winningCombination.Add(temp);
            }
            if ((col + 1 < this.Grid.Count) && (col +1 + 1 < this.Grid.Count))
            {
                temp = new List<Cell>(3);
                temp.Add(this.Grid[row][col]);
                temp.Add(this.Grid[row][col + 1]);
                temp.Add(this.Grid[row][col + 1 + 1]);
                winningCombination.Add(temp);
            }
            // комбинации левой диагонали
            if ((row - 1 >= 0) && (col - 1 >= 0) && (row + 1 < this.Grid.Count) && (col + 1 < this.Grid.Count))
            {
                temp = new List<Cell>(3);
                temp.Add(this.Grid[row][col]);
                temp.Add(this.Grid[row - 1][col - 1]);
                temp.Add(this.Grid[row + 1][col + 1]);
                winningCombination.Add(temp);
            }
            if ((row - 1 >= 0) && (col - 1 >=0) && (row - 1 - 1 >=0) && (col - 1 - 1 >=0))
            {
                temp = new List<Cell>(3);
                temp.Add(this.Grid[row][col]);
                temp.Add(this.Grid[row - 1][col - 1]);
                temp.Add(this.Grid[row - 1 - 1][col - 1 - 1]);
                winningCombination.Add(temp);
            }
            if ((row + 1 < this.Grid.Count) && (col + 1 < this.Grid.Count) && (row + 1 + 1 < this.Grid.Count) && (col + 1 + 1 < this.Grid.Count))
            {
                temp = new List<Cell>(3);
                temp.Add(this.Grid[row][col]);
                temp.Add(this.Grid[row + 1][col + 1]);
                temp.Add(this.Grid[row + 1 + 1][col + 1 + 1]);
                winningCombination.Add(temp);
            }
            // комбинации правой диагонали
            if ((row - 1 >= 0) && (col + 1 < this.Grid.Count) && (row + 1 < this.Grid.Count) && (col - 1 >= 0))
            {
                temp = new List<Cell>(3);
                temp.Add(this.Grid[row][col]);
                temp.Add(this.Grid[row - 1][col + 1]);
                temp.Add(this.Grid[row + 1][col - 1]);
                winningCombination.Add(temp);
            }
            if ((row - 1 >= 0) && (col + 1 < this.Grid.Count) && (row-1-1 >= 0) && (col+1+1 < this.Grid.Count))
            {
                temp = new List<Cell>(3);
                temp.Add(this.Grid[row][col]);
                temp.Add(this.Grid[row - 1][col + 1]);
                temp.Add(this.Grid[row - 1 - 1][col + 1 + 1]);
                winningCombination.Add(temp);
            }
            if ((row + 1 < this.Grid.Count) && (col - 1 >= 0) && (row + 1 + 1 < this.Grid.Count) && (col - 1 - 1 >= 0))
            {
                temp = new List<Cell>(3);
                temp.Add(this.Grid[row][col]);
                temp.Add(this.Grid[row + 1][col - 1]);
                temp.Add(this.Grid[row + 1 + 1][col - 1 - 1]);
                winningCombination.Add(temp);
            }

            for (int i=0; i<winningCombination.Count; i++){
                if (winningCombination[i][0].getState()==currentCell.getState() &&
                    winningCombination[i][1].getState()==currentCell.getState() &&
                    winningCombination[i][2].getState()==currentCell.getState())
                {
                    //Console.WriteLine("{0} win", currentCell.ToString());
                    return currentCell.getState();
                }
            }
            return ECellType.Empty;
        }

        ECellType checkWinner1(int row, int col)
        {
            if (!check(row, col, row + 1, col, 2))
                if (!check(row, col, row - 1, col, 2))
                    if (!check(row, col, row, col + 1, 2))
                        if (!check(row, col, row, col - 1, 2))
                            if (!check(row, col, row + 1, col + 1, 2))
                                if (!check(row, col, row - 1, col - 1, 2))
                                    if (!check(row, col, row + 1, col - 1, 2))
                                        if (!check(row, col, row - 1, col + 1, 2))
                                            if (!checkForCurrentCellInTheMiddle(row, col))
                                                return ECellType.Empty;
            return currentPlayer;
        }
        //bool check(int[] CurrentCoordinates, int[] TargetCoordinates, int deep)
        bool check(int currentRow, int currentCol, int targetRow, int targetCol, int deep)
        {
            int sizeOfSide = this.Grid.Count;
            bool result = false;
            deep--;

            if (targetRow >= 0 && targetRow < sizeOfSide) // проверка границ сверху/снизу
                if (targetCol >= 0 && targetCol < sizeOfSide) // проверка границ слева/справа
                    if (this.Grid[currentRow][currentCol].getState() == this.Grid[targetRow][targetCol].getState())
                    {
                        int differenceRow = targetRow - currentRow;
                        int differenceCol = targetCol - currentCol;
                        if (deep == 0) result = true;
                        else result = check(targetRow, targetCol, targetRow + differenceRow, targetCol + differenceCol, deep);
                    }
            return result;
        }
        bool checkForCurrentCellInTheMiddle(int currentRow, int currentCol)
        {
            // вертикально
            if (check(currentRow, currentCol, currentRow + 1, currentCol, 1))
                if (check(currentRow, currentCol, currentRow - 1, currentCol, 1))
                    return true;
            // горизонтально
            if (check(currentRow, currentCol, currentRow, currentCol + 1, 1))
                if (check(currentRow, currentCol, currentRow, currentCol - 1, 1))
                    return true;
            // правая диагональ
            if (check(currentRow, currentCol, currentRow + 1, currentCol + 1, 1))
                if (check(currentRow, currentCol, currentRow - 1, currentCol - 1, 1))
                    return true;
            // левая диагональ
            if (check(currentRow, currentCol, currentRow + 1, currentCol - 1, 1))
                if (check(currentRow, currentCol, currentRow - 1, currentCol + 1, 1))
                    return true;
            return false;
        }
    }
}
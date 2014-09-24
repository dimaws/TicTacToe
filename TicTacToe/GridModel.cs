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
        public Grid grid { get; set; }
        public int countOfEmptyCells { get; set; }// счетчик оставшихся пустых ячеек, чтобы понять когда игра кончится.
        private ECellType currentPlayer { get; set; }
        public ECellType winner { get; set; }
        public GridModel(int sizeOfSide)
        {
            this.grid = new Grid(sizeOfSide);
            this.countOfEmptyCells = this.grid.numberOfCells;
            this.winner = ECellType.Empty;
            this.currentPlayer = ECellType.X;
        }
        public int getSizeOfSide(){
            return grid.sizeOfSide;
        }
        public int getNumberOfCells()
        {
            return grid.numberOfCells;
        }
        public Cell getCell(int row, int col)
        {
            return grid.getCell(row, col);
        }
        bool checkStep(Cell cell, ECellType type)
        {
            if (cell.state == ECellType.Empty && type != ECellType.Empty)
                return true;
            return false;
        }

        public bool Step(int row, int col)
        {
            if (row < 0 || row >= this.grid.sizeOfSide || col < 0 || col >= this.grid.sizeOfSide)
                return false;
            Cell cell = this.grid.getCell(row, col);
            ECellType type = this.currentPlayer;
            if (!checkStep(cell, type))
                return false;
                
            cell.state = type;
            countOfEmptyCells--;
            this.winner = checkWinner(row, col);
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
            if (!check(row, col, row + 1, col, 2))
            //    if (!check(row, col, row - 1, col, 2))
                    if (!check(row, col, row, col + 1, 2))
            //            if (!check(row, col, row, col - 1, 2))
                            if (!check(row, col, row + 1, col + 1, 2))
            //                    if (!check(row, col, row - 1, col - 1, 2))
                                    if (!check(row, col, row + 1, col - 1, 2))
            //                            if (!check(row, col, row - 1, col + 1, 2))
            //                                if (!checkForCurrentCellInTheMiddle(row, col))
                                                return ECellType.Empty;
            return currentPlayer;
        }
        bool check(int currentRow, int currentCol, int targetRow, int targetCol, int deep, bool reverse = false, int count = 0)
        {

            int sizeOfSide = this.grid.sizeOfSide;
            bool result = false;
            count++; // чтобы n-ная итерация рекурсии знала, насколько она глубоко находится/сколько раз в рекурсии метод уже исполнился
            deep--; // для ограничения итераций и выхода из рекурсии

            int differenceOfRows = targetRow - currentRow;
            int differenceOfCols = targetCol - currentCol;

            if (targetRow >= 0 && targetRow < sizeOfSide && // проверка границ сверху/снизу
                targetCol >= 0 && targetCol < sizeOfSide && // проверка границ слева/справа
                this.grid.getCell(currentRow, currentCol).state == this.grid.getCell(targetRow, targetCol).state)
            {
                if (deep == 0) result = true;
                else result = check(targetRow, targetCol, targetRow + differenceOfRows, targetCol + differenceOfCols, deep, reverse, count);
            }
            else
            {
                if (!reverse)
                { // если кончился список, с последней найденной ячейки проверяем линию полностью в другую сторону.
                    reverse = true;
                    deep += count;
                    result = check(currentRow, currentCol, currentRow - differenceOfRows, currentCol - differenceOfCols, deep, reverse, count);
                }
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
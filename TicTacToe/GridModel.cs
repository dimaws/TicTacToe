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
            int numberOfCellsForWin = 3; // количество ячеек, необходимое для победы

            if (!check(row, col, +1, 0, numberOfCellsForWin - 1)) // проверяем ячейки по вертикали
                if (!check(row, col, 0, +1, numberOfCellsForWin - 1)) // проверяем ячейки по горизонтали
                    if (!check(row, col, +1, +1, numberOfCellsForWin - 1)) // проверяем ячейки по одной диагонали
                        if (!check(row, col, +1, -1, numberOfCellsForWin - 1)) // проверяем ячейки по другой диагонали
                            return ECellType.Empty;
            return currentPlayer;
        }
        bool check(int currentRow, int currentCol, int stepRow, int stepCol, int deep, bool reverse = false, int count = 0)
        {
            if (stepCol > 0) stepCol = +1;
            if (stepCol < 0) stepCol = -1;
            if (stepRow > 0) stepRow = +1;
            if (stepRow < 0) stepRow = -1;

            int nextRow = currentRow + stepRow;
            int nextCol = currentCol + stepCol;
            int sizeOfSide = this.grid.sizeOfSide; // размер стороны поля
            bool result = false;
            count++; // чтобы n-ная итерация рекурсии знала, насколько она глубоко находится/какая по счету итерация
            deep--; // для ограничения итераций и выхода из рекурсии

            if (nextRow >= 0 && nextRow < sizeOfSide && // проверка границ сверху/снизу
                nextCol >= 0 && nextCol < sizeOfSide && // проверка границ слева/справа
                this.grid.getCell(currentRow, currentCol) == this.grid.getCell(nextRow, nextCol))
            {
                if (deep == 0) result = true;
                else result = check(nextRow, nextCol, +stepRow, +stepCol, deep, reverse, count);
            }
            else
            {
                if (!reverse) // если кончился список, с последней найденной ячейки проверяем линию полностью в другую сторону.
                { 
                    reverse = true;
                    deep += count;
                    result = check(currentRow, currentCol, -stepRow, -stepCol, deep, reverse, count);
                }
            }
            return result;
        }
    }
}
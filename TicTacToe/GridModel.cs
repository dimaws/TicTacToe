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
            this.winner = checkNeighbor(row, col);
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

        //bool checkWin(ECellType player)
        //{
        //    /*******************
        //     * надо составить массив ходов игрока
        //     * к каждому ходу проверить соседние ячейки
        //     * если есть, то для уже найденной ячейки проверяем наличие следующей по линии ячейки
        //     * и так до момента определения выигрыша.
        //     * // более удобный вариант: сразу после хода можно проверять ячейки, соседствующие с только что заполненной, чтобы не обходить все поле в поисках победной комбинации
        //    *******************/
        //    for(int i=0; i<this.Grid.Count; i++){
        //        for(int j=1; j<this.Grid[i].Count; j++){
        //            if(this.Grid[i][j].getState() == player){
        //                // TODO описать проверку соседних ячеек, оносительно this.Grid[i][j]
        //            }
        //        }
        //    }
        //}

        ECellType checkNeighbor(int row, int col)
        {
            //if (addressCell.Length != 2)
            //{
            //    // передать должны уже нормально спарсенный и проверенный массив, но эта проверка на всякий случай
            //    throw.ArgumentException("Передан массив неверной размерности. массив должен состоять из 2х элементов.");
            //}
            Cell currentCell = this.Grid[ row ][ col ];


                    /*
                     * в данный момент я хочу пройти от выбранной ячейки вверх, 
                     *                                                   вниз, 
                     *                                                   влево, 
                     *                                                   вправо, 
                     *                                                   по одной диагонали вверх, 
                     *                                                   по одной диагонали вниз, 
                     *                                                   по другой диагонали вверх, 
                     *                                                   по другой диагонали вниз.
                     */


                     /* Возможно, стоит определить выигрышные комбинации для текущей ячейки и уже их проверять.
                     * Таким образом исключим заведомо невыигрышные диагональные комбинации
                     */
                    // горизонтально
                    List<List<Cell>> winningCombination = new List<List<Cell>>();
                    
                        //ПЕРЕДЕЛАТЬ ЭТОТ УЖАСНЫЙ КОД
                        // VERY VERY BAD CODE, need rewrite

                    
                                List<Cell> temp; // если для выигрыша достаточно линии из трех одинаковых ячеек.
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




            /*
             * получаем адрес ячейки в формате массива [строка, столбец]
             * вертикальные совпадения:
             * проверяем наличие ячейки снизу. (важен контроль границ поля)
             * начало рекурсии
             * если есть ячейка, 
             *      проверяем наличие ячейки снизу. (важен контроль границ поля)
             *      счетчик +1.
             * конец рекурсии
             * если нет ячейки, 
             *      проверяем наличие ячейки сверху от первоначальной. (важен контроль границ поля)
             * начало рекурсии
             * если есть ячейка, 
             *      проверяем наличие ячейки сверху. (важен контроль границ поля)
             *      счетчик +1.
             * конец рекурсии
             */
        }

    }
}
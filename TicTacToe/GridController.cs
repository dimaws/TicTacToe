using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class GridController
    {
        public GridModel model { get; set; }
        public GridView view { get; set; }
        
        public GridController(int sizeOfSide)
        {
            this.model = new GridModel(sizeOfSide);
        }
        
        public void makeStep(string str)
        {
            //Cell cell = getCell(str.Split(' '));
            string[] RowCol = str.Split(' ');
            int row = Int32.Parse(RowCol[0]) - 1;
            int col = Int32.Parse(RowCol[1]) - 1;
            //if (!this.model.Step(cell))
            if (!this.model.Step(row, col))
                view.displayGrid("Ход недоступен. Выберите другую.");
            else view.displayGrid();
        }
        Cell getCell(string[] str)
        {
            // TODO проверка данных в str на корректность 

            int row = Int32.Parse(str[0]) - 1;
            int col = Int32.Parse(str[1]) - 1;

            return this.model.getCell(row, col);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class GridController
    {
        GridModel model;
        public GridView view { get; set; }
        
        public GridController(int sizeOfSide)
        {
            this.model = new GridModel(sizeOfSide);
        }
        
        public GridModel ResponseModel()
        {
            return this.model;
        }
        
        public void makeStep(string str)
        {
            Cell cell = getCell(str.Split(' '));

            if (!this.model.Step(cell))
                view.DisplayGrid("В эту ячейку уже ходили. Выберите другую.");
            else view.DisplayGrid();
        }
        Cell getCell(string[] str)
        {
            // TODO проверка данных в str на корректность 

            int i = Int32.Parse(str[0]) - 1;
            int j = Int32.Parse(str[1]) - 1;

            return this.model.Grid[i][j];
        }

    }
}

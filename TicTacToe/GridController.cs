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
        public void makeStep(Cell cell, ECellType type)
        {
            if (!this.model.Step(cell, type)) 
                view.DisplayGrid("В эту ячейку уже ходили. Выберите другую.");
            else view.DisplayGrid();
        }
    }
}

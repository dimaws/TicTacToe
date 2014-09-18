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
            // TODO сделать проверку корректности шага. Модель должна вернуть ответ ок или не ок.
            this.model.Step(cell, type);
            view.DisplayGrid();
        }
        



    }
}

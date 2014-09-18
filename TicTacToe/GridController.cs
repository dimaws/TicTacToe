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
        GridView responseView;
        public GridController(int sizeOfSide)
        {
            this.model = new GridModel(sizeOfSide);
            responseView = new GridView(this.model);
        }
        public GridView ResponseView()
        {
            return responseView;
        }
        
        



    }
}

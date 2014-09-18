using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Cell
    {
        private ECellType state;
        public Cell()
        {
            this.state = ECellType.Empty;
        }
        public void setState(ECellType value)
        {
            this.state = value;
        }
        public ECellType getState()
        {
            return this.state;
        }
        bool isEmpty()
        {
            if (this.state == ECellType.Empty)
                return true;
            return false;
        }
        public override string ToString()
        {
            switch (this.state){
                case ECellType.Empty: return ".";
                case ECellType.X: return "X";
                case ECellType.O: return "O";
            default: return "default";
            }
        }

    }
}

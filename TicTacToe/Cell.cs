using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Cell
    {
        public ECellType state { get; set; }
        public Cell()
        {
            this.state = ECellType.Empty;
        }
        bool isEmpty()
        {
            if (this.state == ECellType.Empty)
                return true;
            return false;
        }
        public override string ToString()
        {
            switch (this.state)
            {
                case ECellType.Empty: return ".";
                case ECellType.X: return "X";
                case ECellType.O: return "O";
                default: return "error";
            }
        }
        public static bool operator ==(Cell a, Cell b)
        {
            if (a.state == b.state) 
                return true;
            else 
                return false;
        }
        public static bool operator !=(Cell a, Cell b)
        {
            if (a.state != b.state)
                return true;
            else
                return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class King : Figure
    {
        
        public King(bool isWhite, int i, int j)
        {

            _pos = new Position(i, j);
            _isDead = false;
            _isWhite = isWhite;
            if (_isWhite)
                pb.Image = Properties.Resources.WhiteKing;
            else
                pb.Image = Properties.Resources.BlackKing;
            _name = "King";
        }

        public override List<Position> Moveable()
        {
            List<Position> temp = new List<Position>();

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;
                    if (_pos.I + i >= 0 && _pos.I + i < 8 && _pos.J + j >= 0 && _pos.J + j < 8)
                        temp.Add(new Position(_pos.I + i, _pos.J + j));
                }
            }
            
            if (!HasMoved)
            {
                temp.Add(new Position(_pos.I + 2, _pos.J));
                temp.Add(new Position(_pos.I - 2, _pos.J));
            }
            
            return temp;
        }
    }
}

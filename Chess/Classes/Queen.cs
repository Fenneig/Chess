using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class Queen : Figure
    {
        public Queen(bool isWhite, int i, int j)
        {
            _pos = new Position(i, j);
            _isDead = false;
            _isWhite = isWhite;
            if (_isWhite)
                pb.Image = Properties.Resources.WhiteQueen;
            else
                pb.Image = Properties.Resources.BlackQueen;
            _name = "Queen";
        }

        public override List<Position> Moveable()
        {
            List<Position> temp = new List<Position>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (_pos.I == i && _pos.J == j) continue;
                    if (_pos.I == i) temp.Add(new Position(i, j));
                    if (_pos.J == j) temp.Add(new Position(i, j));
                    if (i + j == _pos.I + _pos.J) temp.Add(new Position(i, j));
                    if (i - j == _pos.I - _pos.J) temp.Add(new Position(i, j));
                }
            }
            
            return temp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class Knight : Figure
    {
        public Knight(bool isWhite, int i, int j)
        {
            _pos = new Position(i, j);
            _isDead = false;
            _isWhite = isWhite;
            if (_isWhite)
                pb.Image = Properties.Resources.WhiteKnight;
            else
                pb.Image = Properties.Resources.BlackKnight;
            _name = "Knight";
        }

        /*
                    i-2 j-1    
                    i-2 j+1
                    i-1 j+2
                    i-1 j-2
                    i+1 j+2
                    i+1 j-2
                    i+2 j-1
                    i+2 j+1
         */

        public override List<Position> Moveable()
        {
            List<Position> temp = new List<Position>();
            for (int i = -2; i <= 2; i++)
            {
                for (int j = -2; j <= 2; j++)
                {
                    if (Math.Abs(i) + Math.Abs(j) == 3)
                    {
                        if (_pos.I + i >= 0 && _pos.I + i < 8 && _pos.J + j >= 0 && _pos.J + j < 8)
                        {
                            temp.Add(new Position(_pos.I + i, _pos.J + j));
                        }
                    } 
                }
            }
            return temp;
        }
    }
}

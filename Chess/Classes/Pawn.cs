using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class Pawn : Figure
    {
        public Pawn(bool isWhite, int i, int j)
        {
            _pos = new Position(i, j);
            _isDead = false;
            _isWhite = isWhite;
            if (_isWhite)
                pb.Image = Properties.Resources.WhitePawn;
            else
                pb.Image = Properties.Resources.BlackPawn;
            _name = "Pawn";
        }

        public override List<Position> Moveable()
        {
            List<Position> temp = new List<Position>();
            if (_isWhite)
            {
                if (_pos.J == 6)
                    temp.Add(new Position(_pos.I, _pos.J - 2));
                for (int i = -1; i <= 1; i++)
                {
                    if (_pos.I + i >= 0 && _pos.I + i < 8) 
                        temp.Add(new Position(_pos.I + i, _pos.J - 1));
                }
            }
            else
            {
                if (_pos.J == 1)
                    temp.Add(new Position(_pos.I, _pos.J+2));
                for (int i = -1; i <= 1; i++)
                {
                    if (_pos.I + i >= 0 && _pos.I + i < 8)
                        temp.Add(new Position(_pos.I + i, _pos.J + 1));
                }
            }
            return temp;
        }

    }
}

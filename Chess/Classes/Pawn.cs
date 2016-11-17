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
                _pb.Image = Properties.Resources.WhitePawn;
            else
                _pb.Image = Properties.Resources.BlackPawn;
        }

        public override List<Position> Moveable()
        {
            List<Position> list = new List<Position>();
            Position temp = new Position();
            if (_isWhite)
            {
                if (_pos.J == 6)
                    list.Add(new Position(_pos.I, _pos.J - 2));
                for (int i = -1; i <= 1; i++)
                    list.Add(new Position(_pos.I - i, _pos.J - 1));
            }
            return list;
        }
    }
}

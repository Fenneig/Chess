using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class Bishop : Figure
    {
        public Bishop(bool isWhite, int i, int j)
        {
            _pos = new Position(i, j);
            _isDead = false;
            _isWhite = isWhite;
            if (_isWhite)
                _pb.Image = Properties.Resources.WhiteBishop;
            else
                _pb.Image = Properties.Resources.BlackBishop;
        }

        public override List<Position> Moveable()
        {
            throw new NotImplementedException();
        }
    }
}

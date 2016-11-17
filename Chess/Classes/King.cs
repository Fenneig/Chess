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
                _pb.Image = Properties.Resources.WhiteKing;
            else
                _pb.Image = Properties.Resources.BlackKing;
        }

        public override List<Position> Moveable()
        {
            throw new NotImplementedException();
        }
    }
}

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
                _pb.Image = Properties.Resources.WhiteQueen;
            else
                _pb.Image = Properties.Resources.BlackQueen;
        }

        public override List<Position> Moveable()
        {
            throw new NotImplementedException();
        }
    }
}

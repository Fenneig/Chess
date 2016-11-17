using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class Castle : Figure
    {
        public Castle(bool isWhite, int i, int j)
        {
            _pos = new Position(i, j);
            _isDead = false;
            _isWhite = isWhite;
            if (_isWhite)
                _pb.Image = Properties.Resources.WhiteCastle;
            else
                _pb.Image = Properties.Resources.BlackCastle;
        }

        public override List<Position> Moveable()
        {
            throw new NotImplementedException();
        }
    }
}

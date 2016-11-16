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
        public Bishop(bool isWhite)
        {
            _isDead = false;
            _isWhite = isWhite;
            if (_isWhite)
                _pb.Image = Properties.Resources.WhiteBishop;
            else
                _pb.Image = Properties.Resources.BlackBishop;
        }
        public override void Eat(int i, int j)
        {
            throw new NotImplementedException();
        }

        public override void Move(int i, int j)
        {
            throw new NotImplementedException();
        }
    }
}

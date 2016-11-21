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
                pb.Image = Properties.Resources.WhiteCastle;
            else
                pb.Image = Properties.Resources.BlackCastle;
            _name = "Castle";
        }

        public override List<Position> Moveable()
        {
            List<Position> temp = new List<Position>();
            for (int i = 0; i < 8; i++)
            {
                if (_pos.I != i)
                    temp.Add(new Position(i, _pos.J));
            }
            for (int j = 0; j < 8; j++)
            {
                if (_pos.J != j)
                    temp.Add(new Position(_pos.I, j));
            }

            return temp;
        }

        public override void Dying()
        {
            _isDead = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    abstract class Figure
    {
        public bool _isWhite;
        public bool _isDead;
        public Position _pos;

        public PictureBox _pb = new PictureBox();

        public abstract List<Position> Moveable();

        public PictureBox pb { get { return _pb; } }
        
    }
}

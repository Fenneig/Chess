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
        int _i, _j;
        public PictureBox _pb = new PictureBox();


        public abstract void Move(int i, int j);
        public abstract void Eat(int i, int j);

        public PictureBox pb { get { return _pb; } }
        
    }
}

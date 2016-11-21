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
        protected bool _isWhite;
        protected bool _isDead;
        protected Position _pos;
        protected string _name;

        private PictureBox _pb = new PictureBox();

        public bool IsDead
        {
            get { return _isDead; }
            set { _isDead = value; }
        } 

        public abstract List<Position> Moveable();

        public PictureBox pb
        {
            get { return _pb; }
        }

        public string GetName
        {
            get { return _name; }
        }

        public bool IsWhite
        {
            get { return _isWhite; }
        }

        public Position Pos
        {
            set { _pos = value; }
        }

        public abstract void Dying();
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Chess
{
    class Field
    {
        PictureBox _pb;
        bool isWhite;

        public Point Location
        {
            set { _pb.Location = value; }
        }

        public PictureBox PB
        {
            get { return _pb; }
        }

        public Field(int i, int j, PictureBox pb)
        {
            isWhite = ((i + j) % 2 == 1);
            _pb = pb;
            _pb.SizeMode = PictureBoxSizeMode.AutoSize;
            if (isWhite)
            {
                _pb.BackgroundImage = Properties.Resources.WhiteBG;
                _pb.Image = Properties.Resources.WhiteBG;
            }
            else
            {
                _pb.BackgroundImage = Properties.Resources.BlackBG;
                _pb.Image = Properties.Resources.BlackBG;
            }
        }

        public void Put_Figure(Figure fig)
        {
            _pb.Image = fig.pb.Image;
        }
        

    }
}

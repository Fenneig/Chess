using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Chess
{
    class Cell
    {
        private PictureBox _pb;
        private bool _isWhiteCell;
        private bool _isOccupied;
        private Figure _fig;
        private bool _isSelected = false;
        private bool _moves = false;

        public Point PBLocation
        {
            set { _pb.Location = value; }
        }

        public PictureBox PB
        {
            get { return _pb; }
        }

        public Cell(int i, int j, PictureBox pb)
        {
            _isWhiteCell = ((i + j) % 2 == 1);
            _pb = pb;
            _pb.SizeMode = PictureBoxSizeMode.AutoSize;
            _isOccupied = false;
            _fig = null;
            if (_isWhiteCell)
            {
                _pb.BackgroundImage = Properties.Resources.WhiteBG;
                _pb.Image = Properties.Resources.WhiteBG;
                _pb.Image = null;
            }
            else
            {
                _pb.BackgroundImage = Properties.Resources.BlackBG;
                _pb.Image = Properties.Resources.BlackBG;
                _pb.Image = null;
            }
        }

        public void PutFigure(Figure fig)
        {
            _pb.Image = fig.pb.Image;
            _isOccupied = true;
            _fig = fig;
        }

        public void LeaveFigure()
        {
            _pb.Image = _pb.BackgroundImage;
            _isOccupied = false;
            _fig.Dying();
            _fig = null;
        }

        public bool IsOccupied
        {
            get { return _isOccupied; }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
        }

        public bool IsMoves
        {
            get { return _moves; }
            set { _moves = value; }
        }

        public void SelectCell()
        {
            _isSelected = true;
            if (_isWhiteCell)
            {
                _pb.BackgroundImage = Properties.Resources.WhiteBGMove;
            }
            else
            {
                _pb.BackgroundImage = Properties.Resources.BlackBGMove;
            }
        }

        public void DeselectCell()
        {
            _isSelected = false;
            if (_isWhiteCell)
            {
                _pb.BackgroundImage = Properties.Resources.WhiteBG;
            }
            else
            {
                _pb.BackgroundImage = Properties.Resources.BlackBG;
            }
        }

        public Figure GetFigure
        {
            get { return _fig; }
        }
        

    }
}

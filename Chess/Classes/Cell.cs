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
        private bool _isOccupied = false;
        private bool _isSelected = false;
        private bool _moves = false;
        private int _isBeatenByWhite = 0;
        private int _isBeatenByBlack = 0;
        private Figure _fig;
        private Position _pos;

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
            _pos = new Position(i, j);
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
            _pb.Image = null;
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

        public Position Pos
        {
            get { return _pos; }
        }
        
        public void BeatWhite()
        {
            _isBeatenByWhite++;
        }

        public void deBeatWhite()
        {
            _isBeatenByWhite--;
        }

        public void BeatBlack()
        {
            _isBeatenByBlack++;
        }

        public void deBeatBlack()
        {
            _isBeatenByBlack--;
        }
        

    }
}

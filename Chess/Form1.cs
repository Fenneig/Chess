using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class MainForm : Form
    {
        PictureBox[,] field = new PictureBox[8, 8];

        public MainForm()
        {
            InitializeComponent();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    field[i, j] = new PictureBox();
                    this.Controls.Add(field[i, j]);
                    field[i, j].Image = ((i + j) % 2 == 0) ? Properties.Resources.BlackBG : Properties.Resources.WhiteBG;
                    field[i, j].Location = new Point(i * 81 + 16, j * 81 + 16);
                    field[i, j].SizeMode = PictureBoxSizeMode.AutoSize;
                }
            }
            PictureBox RedFrame = new PictureBox();
            this.Controls.Add(RedFrame);
            RedFrame.Size = new Size(680, 680);
            RedFrame.BackColor = Color.DarkRed;
            
        }
    }
}

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
        Cell[,] field = new Cell[8, 8];
        int size = 81;
        int indent = 16;
        Logic lg;

        public MainForm()
        {
            InitializeComponent();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    PictureBox pb = new PictureBox();
                    pb.SizeMode = PictureBoxSizeMode.AutoSize;
                    field[i, j] = new Cell(i, j, pb);
                    field[i, j].PBLocation = new Point(i * size + indent, j * size + indent + 24);
                    field[i, j].PB.MouseClick += Pb_MouseClick;
                    this.Controls.Add(field[i, j].PB);
                    field[i, j].PB.Tag = new Position(i, j);
                }
            }

            PictureBox RedFrame = new PictureBox();
            this.Controls.Add(RedFrame);
            RedFrame.Size = new Size(680, 680);
            RedFrame.BackColor = Color.DarkRed;
            RedFrame.Location = new Point(0, 24);

            lg = new Logic(field);
            lg.CreateDefaultPosition();
        }

        private void Pb_MouseClick(object sender, MouseEventArgs e)
        {
            Position pos = (Position)((PictureBox)sender).Tag;
            label1.Text = "i = " + pos.I + ", j = " + pos.J;
            lg.Click(pos);            
        }



    }
}

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
                    field[i, j].PBLocation = new Point(i * size + indent, j * size + indent);
                    field[i, j].PB.MouseClick += Pb_MouseClick;
                    this.Controls.Add(field[i, j].PB);
                    field[i, j].PB.Tag = new Position(i, j);
                }
            }

            PictureBox RedFrame = new PictureBox();
            this.Controls.Add(RedFrame);
            RedFrame.Size = new Size(680, 680);
            RedFrame.BackColor = Color.DarkRed;

            CreateDefaultPosition();

            lg = new Logic(field);
        }

        private void Pb_MouseClick(object sender, MouseEventArgs e)
        {
            Position pos = (Position)((PictureBox)sender).Tag;
            label1.Text = "i = " + pos.I + ", j = " + pos.J;
            lg.Click(pos);            
        }

        public void CreateDefaultPosition()
        {
            Figure blackCastle1 = new Castle(false, 0, 0);
            Figure blackCastle2 = new Castle(false, 7, 0);
            Figure blackKnight1 = new Knight(false, 1, 0);
            Figure blackKnight2 = new Knight(false, 6, 0);
            Figure blackBishop1 = new Bishop(false, 2, 0);
            Figure blackBishop2 = new Bishop(false, 5, 0);
            Figure blackKing    =   new King(false, 3, 0);
            Figure blackQueen   =  new Queen(false, 4, 0);
            Figure blackPawn1   =   new Pawn(false, 0, 1);
            Figure blackPawn2   =   new Pawn(false, 1, 1);
            Figure blackPawn3   =   new Pawn(false, 2, 1);
            Figure blackPawn4   =   new Pawn(false, 3, 1);
            Figure blackPawn5   =   new Pawn(false, 4, 1);
            Figure blackPawn6   =   new Pawn(false, 5, 1);
            Figure blackPawn7   =   new Pawn(false, 6, 1);
            Figure blackPawn8   =   new Pawn(false, 7, 1);

            Figure whiteCastle1 = new Castle(true, 0, 7);
            Figure whiteCastle2 = new Castle(true, 7, 7);
            Figure whiteKnight1 = new Knight(true, 1, 7);
            Figure whiteKnight2 = new Knight(true, 6, 7);
            Figure whiteBishop1 = new Bishop(true, 2, 7);
            Figure whiteBishop2 = new Bishop(true, 5, 7);
            Figure whiteKing    =   new King(true, 3, 7);
            Figure whiteQueen   =  new Queen(true, 4, 7);
            Figure whitePawn1   =   new Pawn(true, 0, 6);
            Figure whitePawn2   =   new Pawn(true, 1, 6);
            Figure whitePawn3   =   new Pawn(true, 2, 6);
            Figure whitePawn4   =   new Pawn(true, 3, 6);
            Figure whitePawn5   =   new Pawn(true, 4, 6);
            Figure whitePawn6   =   new Pawn(true, 5, 6);
            Figure whitePawn7   =   new Pawn(true, 6, 6);
            Figure whitePawn8   =   new Pawn(true, 7, 6);

            field[0, 0].PutFigure(blackCastle1);
            field[1, 0].PutFigure(blackKnight1);
            field[2, 0].PutFigure(blackBishop1);
            field[3, 0].PutFigure(blackKing);
            field[4, 0].PutFigure(blackQueen);
            field[5, 0].PutFigure(blackBishop2);
            field[6, 0].PutFigure(blackKnight2);
            field[7, 0].PutFigure(blackCastle2);
            field[0, 1].PutFigure(blackPawn1);
            field[1, 1].PutFigure(blackPawn2);
            field[2, 1].PutFigure(blackPawn3);
            field[3, 1].PutFigure(blackPawn4);
            field[4, 1].PutFigure(blackPawn5);
            field[5, 1].PutFigure(blackPawn6);
            field[6, 1].PutFigure(blackPawn7);
            field[7, 1].PutFigure(blackPawn8);

            field[0, 7].PutFigure(whiteCastle1);
            field[1, 7].PutFigure(whiteKnight1);
            field[2, 7].PutFigure(whiteBishop1);
            field[3, 7].PutFigure(whiteKing);
            field[4, 7].PutFigure(whiteQueen);
            field[5, 7].PutFigure(whiteBishop2);
            field[6, 7].PutFigure(whiteKnight2);
            field[7, 7].PutFigure(whiteCastle2);
            field[0, 6].PutFigure(whitePawn1);
            field[1, 6].PutFigure(whitePawn2);
            field[2, 6].PutFigure(whitePawn3);
            field[3, 6].PutFigure(whitePawn4);
            field[4, 6].PutFigure(whitePawn5);
            field[5, 6].PutFigure(whitePawn6);
            field[6, 6].PutFigure(whitePawn7);
            field[7, 6].PutFigure(whitePawn8);

        }


    }
}

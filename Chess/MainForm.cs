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

        Field[,] field = new Field[8, 8];

        public MainForm()
        {
            InitializeComponent();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    PictureBox pb = new PictureBox();
                    pb.SizeMode = PictureBoxSizeMode.AutoSize;
                    field[i, j] = new Field(i, j, pb);
                    field[i, j].Location = new Point(i * 81 + 16, j * 81 + 16);
                    this.Controls.Add(field[i,j].PB);
                }
            }

            PictureBox RedFrame = new PictureBox();
            this.Controls.Add(RedFrame);
            RedFrame.Size = new Size(680, 680);
            RedFrame.BackColor = Color.DarkRed;

            CreateDefaultPosition();
        }

        public void CreateDefaultPosition()
        {
            Figure blackCastle1 = new Castle(false);
            Figure blackCastle2 = new Castle(false);
            Figure blackBishop1 = new Bishop(false);
            Figure blackBishop2 = new Bishop(false);
            Figure blackKnight1 = new Knight(false);
            Figure blackKnight2 = new Knight(false);
            Figure blackKing    = new King(false);
            Figure blackQueen   = new Queen(false);
            Figure blackPawn1   = new Pawn(false);
            Figure blackPawn2   = new Pawn(false);
            Figure blackPawn3   = new Pawn(false);
            Figure blackPawn4   = new Pawn(false);
            Figure blackPawn5   = new Pawn(false);
            Figure blackPawn6   = new Pawn(false);
            Figure blackPawn7   = new Pawn(false);
            Figure blackPawn8   = new Pawn(false);

            Figure whiteCastle1 = new Castle(true);
            Figure whiteCastle2 = new Castle(true);
            Figure whiteBishop1 = new Bishop(true);
            Figure whiteBishop2 = new Bishop(true);
            Figure whiteKnight1 = new Knight(true);
            Figure whiteKnight2 = new Knight(true);
            Figure whiteKing    = new King(true);
            Figure whiteQueen   = new Queen(true);
            Figure whitePawn1   = new Pawn(true);
            Figure whitePawn2   = new Pawn(true);
            Figure whitePawn3   = new Pawn(true);
            Figure whitePawn4   = new Pawn(true);
            Figure whitePawn5   = new Pawn(true);
            Figure whitePawn6   = new Pawn(true);
            Figure whitePawn7   = new Pawn(true);
            Figure whitePawn8   = new Pawn(true);

            field[0, 0].Put_Figure(blackCastle1);
            field[1, 0].Put_Figure(blackKnight1);
            field[2, 0].Put_Figure(blackBishop1);
            field[3, 0].Put_Figure(blackKing);
            field[4, 0].Put_Figure(blackQueen);
            field[5, 0].Put_Figure(blackBishop2);
            field[6, 0].Put_Figure(blackKnight2);
            field[7, 0].Put_Figure(blackCastle2);
            field[0, 1].Put_Figure(blackPawn1);
            field[1, 1].Put_Figure(blackPawn2);
            field[2, 1].Put_Figure(blackPawn3);
            field[3, 1].Put_Figure(blackPawn4);
            field[4, 1].Put_Figure(blackPawn5);
            field[5, 1].Put_Figure(blackPawn6);
            field[6, 1].Put_Figure(blackPawn7);
            field[7, 1].Put_Figure(blackPawn8);

            field[0, 7].Put_Figure(whiteCastle1);
            field[1, 7].Put_Figure(whiteKnight1);
            field[2, 7].Put_Figure(whiteBishop1);
            field[3, 7].Put_Figure(whiteKing);
            field[4, 7].Put_Figure(whiteQueen);
            field[5, 7].Put_Figure(whiteBishop2);
            field[6, 7].Put_Figure(whiteKnight2);
            field[7, 7].Put_Figure(whiteCastle2);
            field[0, 6].Put_Figure(whitePawn1);
            field[1, 6].Put_Figure(whitePawn2);
            field[2, 6].Put_Figure(whitePawn3);
            field[3, 6].Put_Figure(whitePawn4);
            field[4, 6].Put_Figure(whitePawn5);
            field[5, 6].Put_Figure(whitePawn6);
            field[6, 6].Put_Figure(whitePawn7);
            field[7, 6].Put_Figure(whitePawn8);

        }


    }
}

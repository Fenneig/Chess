using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Logic
    {
        Cell[,] _table = new Cell[8, 8];
        string _figureName;
        int _movesCounter = 0;
        bool _isWhiteTurn;

        public Logic(Cell[,] table)
        {
            _table = table;
        }

        //Обработка нажатия мышки
        public void Click(Position pos)
        {
            _isWhiteTurn = (_movesCounter % 2 == 0);
            //проверяю есть ли в клетке фигура
            if (_table[pos.I, pos.J].IsOccupied && !_table[pos.I, pos.J].IsSelected)
            {
                //проверяю совпадает ли цвет фигуры с цветом текущего игрока
                if (_isWhiteTurn == _table[pos.I, pos.J].GetFigure.IsWhite)
                {
                    ShowMoves(pos);
                    _table[pos.I, pos.J].IsMoves = true;
                }
            }
            //проверяю возможность походить в эту клетку 
            else if (_table[pos.I, pos.J].IsSelected)
            {
                Move(pos);
            }
            //очищаю возможные ходы если было кликнуто по клетке с которой нельзя взаимодействовать  
            else Deselection();
        }

        private void Move(Position pos)
        {
            //если в клетке стоит фигура то убираю её
            if (_table[pos.I, pos.J].IsOccupied) _table[pos.I, pos.J].LeaveFigure();

            //нахожу фигуру которая ходила убираю её из предыдущей клетки и перемещаю в новую
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (_table[i, j].IsMoves)
                    {
                        _table[pos.I, pos.J].PutFigure(_table[i, j].GetFigure);
                        _table[pos.I, pos.J].GetFigure.Pos = pos;
                        _table[i, j].LeaveFigure();
                        _table[pos.I, pos.J].GetFigure.HasMoved = true;
                        //смотрю может ли пешка стать королевой
                        if (_figureName == "Pawn" && (pos.J == 0 || pos.J == 7))
                            BecomeQueen(pos);
                        if (_figureName == "King" && (Math.Abs(pos.I - i) == 2))
                            Castling(pos);
                        break;
                    }
            //убираю возможные ходы оповещаю, что был сделан ход
            Deselection();
            _movesCounter++;
        }

        //рокировка
        private void Castling(Position pos)
        {
            if (pos.I == 1)
            {
                _table[2, pos.J].PutFigure(_table[0, pos.J].GetFigure);
                _table[2, pos.J].GetFigure.Pos = new Position(2, pos.J);
                _table[0, pos.J].LeaveFigure();
            }
            else if (pos.I == 6)
            {
                _table[5, pos.J].PutFigure(_table[7, pos.J].GetFigure);
                _table[5, pos.J].GetFigure.Pos = new Position(5, pos.J);
                _table[7, pos.J].LeaveFigure();
            }
        }

        //метод превращающий пешку в королеву
        private void BecomeQueen(Position pos)
        {
            _table[pos.I, pos.J].LeaveFigure();
            Figure Queen;
            if (_isWhiteTurn)
                Queen = new Queen(true, pos.I, pos.J);
            else
                Queen = new Queen(false, pos.I, pos.J);
            _table[pos.I, pos.J].PutFigure(Queen);
        }
        
        private void ShowMoves(Position pos)
        {
            //перед показом новых возможных для хода позиций убираю старые
            Deselection();
            //определяю чей сейчас ход, какой фигурой пытается ходить пользователь
            _isWhiteTurn = (_movesCounter % 2 == 0);
            _figureName = _table[pos.I, pos.J].GetFigure.GetName;
            //выбираю все клетки на которые может пойти фигура
            Selection(_table[pos.I, pos.J].GetFigure.Moveable());
            //удаляю клетки на которые фигура не может ходить
            RemoveWrongSelects(_table[pos.I, pos.J]);
        }

        private void Deselection()
        {
            //убираю выбор клеток со всего поля
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    _table[i, j].DeselectCell();
                    _table[i, j].IsMoves = false;
                }
        }

        private void Selection(List<Position> list)
        {
            //получаю таблицу клеток которые надо пометить и помечаю.
            foreach (var v in list)
                _table[v.I, v.J].SelectCell();
        }

        private void RemoveWrongSelects(Cell temp)
        {
            //убираю клетки в которые фигуры не могут ходить
            switch (_figureName)
            {
                #region Убираем лишние ходы пешки
                case "Pawn":
                    {
                        if (temp.GetFigure.IsWhite)
                        {
                            if (_table[temp.Pos.I, temp.Pos.J - 1].IsOccupied)
                            {
                                _table[temp.Pos.I, temp.Pos.J - 1].DeselectCell();
                                if (temp.Pos.J == 6)
                                    _table[temp.Pos.I, temp.Pos.J - 2].DeselectCell();
                            }
                            if (temp.Pos.J == 6)
                                if (_table[temp.Pos.I, temp.Pos.J - 2].IsOccupied)
                                {
                                    _table[temp.Pos.I, temp.Pos.J - 2].DeselectCell();
                                }
                            if ((temp.Pos.I > 0 && temp.Pos.J > 0) && !_table[temp.Pos.I - 1, temp.Pos.J - 1].IsOccupied)
                            {
                                _table[temp.Pos.I - 1, temp.Pos.J - 1].DeselectCell();
                            }
                            else
                            {
                                if ((temp.Pos.I > 0 && temp.Pos.J > 0) && _table[temp.Pos.I - 1, temp.Pos.J - 1].GetFigure.IsWhite)
                                {
                                    _table[temp.Pos.I - 1, temp.Pos.J - 1].DeselectCell();
                                }
                            }

                            if ((temp.Pos.I < 7 && temp.Pos.J > 0) && !_table[temp.Pos.I + 1, temp.Pos.J - 1].IsOccupied)
                            {
                                _table[temp.Pos.I + 1, temp.Pos.J - 1].DeselectCell();
                            }
                            else
                            {
                                if ((temp.Pos.I < 7 && temp.Pos.J > 0) && _table[temp.Pos.I + 1, temp.Pos.J - 1].GetFigure.IsWhite)
                                {
                                    _table[temp.Pos.I + 1, temp.Pos.J - 1].DeselectCell();
                                }
                            }
                        }
                        else
                        {
                            if (_table[temp.Pos.I, temp.Pos.J + 1].IsOccupied)
                            {
                                _table[temp.Pos.I, temp.Pos.J + 1].DeselectCell();
                                if (temp.Pos.J == 1)
                                    _table[temp.Pos.I, temp.Pos.J + 2].DeselectCell();
                            }
                            if (temp.Pos.J == 1)
                                if (_table[temp.Pos.I, temp.Pos.J + 2].IsOccupied)
                                {
                                    _table[temp.Pos.I, temp.Pos.J + 2].DeselectCell();
                                }
                            if ((temp.Pos.I > 0 && temp.Pos.J < 7) && !_table[temp.Pos.I - 1, temp.Pos.J + 1].IsOccupied)
                            {
                                _table[temp.Pos.I - 1, temp.Pos.J + 1].DeselectCell();
                            }
                            else
                            {
                                if ((temp.Pos.I > 0 && temp.Pos.J < 7) && !_table[temp.Pos.I - 1, temp.Pos.J + 1].GetFigure.IsWhite)
                                {
                                    _table[temp.Pos.I - 1, temp.Pos.J + 1].DeselectCell();
                                }
                            }

                            if ((temp.Pos.I < 7 && temp.Pos.J < 7) && !_table[temp.Pos.I + 1, temp.Pos.J + 1].IsOccupied)
                            {
                                _table[temp.Pos.I + 1, temp.Pos.J + 1].DeselectCell();
                            }
                            else
                            {
                                if ((temp.Pos.I < 7 && temp.Pos.J < 7) && !_table[temp.Pos.I + 1, temp.Pos.J + 1].GetFigure.IsWhite)
                                {
                                    _table[temp.Pos.I + 1, temp.Pos.J + 1].DeselectCell();
                                }
                            }
                        }

                        break;
                    }
                #endregion
                    
                #region Убираем лишние ходы коня
                case "Knight":
                    {
                        for (int i = -2; i <= 2; i++)
                        {
                            for (int j = -2; j <= 2; j++)
                            {
                                if (Math.Abs(i) + Math.Abs(j) == 3)
                                {
                                    if (temp.Pos.I + i >= 0 && temp.Pos.I + i < 8 && temp.Pos.J + j >= 0 && temp.Pos.J + j < 8)
                                    {
                                        if (temp.GetFigure.IsWhite)
                                        {
                                            if (_table[temp.Pos.I + i, temp.Pos.J + j].IsOccupied)
                                                if (_table[temp.Pos.I + i, temp.Pos.J + j].GetFigure.IsWhite)
                                                    _table[temp.Pos.I + i, temp.Pos.J + j].DeselectCell();
                                        }
                                        else
                                        {
                                            if (_table[temp.Pos.I + i, temp.Pos.J + j].IsOccupied && !_table[temp.Pos.I + i, temp.Pos.J + j].GetFigure.IsWhite)
                                                _table[temp.Pos.I + i, temp.Pos.J + j].DeselectCell();
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                #endregion
    
                #region Убираем лишние ходы слона
                case "Bishop":
                    {
                        // Идем в 4 стороны

                        // 1 right-up
                        int i = temp.Pos.I;
                        int j = temp.Pos.J;
                        bool blocked = false;

                        while ((i + 1) < 8 && (j - 1) >= 0) 
                        {
                            i++;
                            j--;
                            if (blocked)
                            {
                                _table[i, j].DeselectCell();
                            }
                            else
                            {
                                if (_table[i, j].IsOccupied)
                                {
                                    blocked = true;
                                    if (temp.GetFigure.IsWhite == _table[i, j].GetFigure.IsWhite)
                                        _table[i, j].DeselectCell();
                                }
                            }
                        }

                        //2 left-up

                        blocked = false;
                        i = temp.Pos.I;
                        j = temp.Pos.J;

                        while ((i - 1) >= 0 && (j - 1) >= 0) 
                        {
                            i--;
                            j--;

                            if (blocked)
                            {
                                _table[i, j].DeselectCell();
                            }
                            else
                            {
                                if (_table[i, j].IsOccupied)
                                {
                                    blocked = true;
                                    if (temp.GetFigure.IsWhite == _table[i, j].GetFigure.IsWhite)
                                        _table[i, j].DeselectCell();
                                }
                            }
                        }

                        //3 right-down

                        blocked = false;
                        i = temp.Pos.I;
                        j = temp.Pos.J;

                        while ((i + 1) < 8  && (j + 1) < 8)
                        {
                            i++;
                            j++;

                            if (blocked)
                            {
                                _table[i, j].DeselectCell();
                            }
                            else
                            {
                                if (_table[i, j].IsOccupied)
                                {
                                    blocked = true;
                                    if (temp.GetFigure.IsWhite == _table[i, j].GetFigure.IsWhite)
                                        _table[i, j].DeselectCell();
                                }
                            }
                        }

                        //4 left-down

                        blocked = false;
                        i = temp.Pos.I;
                        j = temp.Pos.J;

                        while ((i - 1) >= 0 && (j + 1) < 8)
                        {
                            i--;
                            j++;

                            if (blocked)
                            {
                                _table[i, j].DeselectCell();
                            }
                            else
                            {
                                if (_table[i, j].IsOccupied)
                                {
                                    blocked = true;
                                    if (temp.GetFigure.IsWhite == _table[i, j].GetFigure.IsWhite)
                                        _table[i, j].DeselectCell();
                                }
                            }
                        }

                        break;
                    }
                #endregion

                #region Убираем лишние ходы ладьи
                case "Castle":
                    {
                        // Идем в 4 стороны

                        //1 up
                        int i = temp.Pos.I;
                        int j = temp.Pos.J;
                        bool blocked = false;

                        while ((j - 1) >= 0)
                        {
                            j--;

                            if (blocked)
                            {
                                _table[i, j].DeselectCell();
                            }
                            else
                            {
                                if (_table[i, j].IsOccupied)
                                {
                                    blocked = true;
                                    if (temp.GetFigure.IsWhite == _table[i, j].GetFigure.IsWhite)
                                        _table[i, j].DeselectCell();
                                }
                            }
                        }

                        //2 down
                        j = temp.Pos.J;
                        blocked = false;

                        while ((j + 1) < 8)
                        {
                            j++;

                            if (blocked)
                            {
                                _table[i, j].DeselectCell();
                            }
                            else
                            {
                                if (_table[i, j].IsOccupied)
                                {
                                    blocked = true;
                                    if (temp.GetFigure.IsWhite == _table[i, j].GetFigure.IsWhite)
                                        _table[i, j].DeselectCell();
                                }
                            }
                        }

                        //3 left
                        j = temp.Pos.J;
                        blocked = false;

                        while ((i - 1) >= 0)
                        {
                            i--;

                            if (blocked)
                            {
                                _table[i, j].DeselectCell();
                            }
                            else
                            {
                                if (_table[i, j].IsOccupied)
                                {
                                    blocked = true;
                                    if (temp.GetFigure.IsWhite == _table[i, j].GetFigure.IsWhite)
                                        _table[i, j].DeselectCell();
                                }
                            }
                        }

                        //4 right
                        i = temp.Pos.I;
                        blocked = false;

                        while ((i + 1) < 8)
                        {
                            i++;

                            if (blocked)
                            {
                                _table[i, j].DeselectCell();
                            }
                            else
                            {
                                if (_table[i, j].IsOccupied)
                                {
                                    blocked = true;
                                    if (temp.GetFigure.IsWhite == _table[i, j].GetFigure.IsWhite)
                                        _table[i, j].DeselectCell();
                                }
                            }
                        }

                        break;
                    }
                #endregion

                #region Убираем лишние ходы короля
                case "King":
                    {
                        if (!temp.GetFigure.HasMoved)
                        {
                            bool flag = true;
                            for (int i = 1; i < 4; i++)
                                if (_table[i, temp.Pos.J].IsOccupied) flag = false;
                            if (!flag)
                                _table[1, temp.Pos.J].DeselectCell();
                            flag = true;
                            for (int i = 5; i <= 6; i++)
                                if (_table[i, temp.Pos.J].IsOccupied) flag = false;
                            if (!flag)
                                _table[6, temp.Pos.J].DeselectCell();
                        }
                        for (int i = -1; i <= 1; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
                                if (i == 0 && j == 0) continue;
                                if (temp.Pos.I + i >= 0 && temp.Pos.I + i < 8 && temp.Pos.J + j >= 0 && temp.Pos.J + j < 8) 
                                    if (_table[temp.Pos.I + i, temp.Pos.J + j].IsOccupied && 
                                       (_table[temp.Pos.I + i, temp.Pos.J + j].GetFigure.IsWhite == temp.GetFigure.IsWhite))
                                        _table[temp.Pos.I + i, temp.Pos.J + j].DeselectCell();
                            }
                        }
                        break;
                    }
                #endregion

                #region Убираем лишние ходы королевы
                case "Queen":
                    {
                        // Идем в 8 сторон

                        // 1 right-up
                        int i = temp.Pos.I;
                        int j = temp.Pos.J;
                        bool blocked = false;

                        while ((i + 1) < 8 && (j - 1) >= 0)
                        {
                            i++;
                            j--;
                            if (blocked)
                            {
                                _table[i, j].DeselectCell();
                            }
                            else
                            {
                                if (_table[i, j].IsOccupied)
                                {
                                    blocked = true;
                                    if (temp.GetFigure.IsWhite == _table[i, j].GetFigure.IsWhite)
                                        _table[i, j].DeselectCell();
                                }
                            }
                        }

                        //2 left-up

                        blocked = false;
                        i = temp.Pos.I;
                        j = temp.Pos.J;

                        while ((i - 1) >= 0 && (j - 1) >= 0)
                        {
                            i--;
                            j--;

                            if (blocked)
                            {
                                _table[i, j].DeselectCell();
                            }
                            else
                            {
                                if (_table[i, j].IsOccupied)
                                {
                                    blocked = true;
                                    if (temp.GetFigure.IsWhite == _table[i, j].GetFigure.IsWhite)
                                        _table[i, j].DeselectCell();
                                }
                            }
                        }

                        //3 right-down

                        blocked = false;
                        i = temp.Pos.I;
                        j = temp.Pos.J;

                        while ((i + 1) < 8 && (j + 1) < 8)
                        {
                            i++;
                            j++;

                            if (blocked)
                            {
                                _table[i, j].DeselectCell();
                            }
                            else
                            {
                                if (_table[i, j].IsOccupied)
                                {
                                    blocked = true;
                                    if (temp.GetFigure.IsWhite == _table[i, j].GetFigure.IsWhite)
                                        _table[i, j].DeselectCell();
                                }
                            }
                        }

                        //4 left-down

                        blocked = false;
                        i = temp.Pos.I;
                        j = temp.Pos.J;

                        while ((i - 1) >= 0 && (j + 1) < 8)
                        {
                            i--;
                            j++;

                            if (blocked)
                            {
                                _table[i, j].DeselectCell();
                            }
                            else
                            {
                                if (_table[i, j].IsOccupied)
                                {
                                    blocked = true;
                                    if (temp.GetFigure.IsWhite == _table[i, j].GetFigure.IsWhite)
                                        _table[i, j].DeselectCell();
                                }
                            }
                        }

                        //5 up

                        blocked = false;
                        i = temp.Pos.I;
                        j = temp.Pos.J;

                        while ((j - 1) >= 0)
                        {
                            j--;

                            if (blocked)
                            {
                                _table[i, j].DeselectCell();
                            }
                            else
                            {
                                if (_table[i, j].IsOccupied)
                                {
                                    blocked = true;
                                    if (temp.GetFigure.IsWhite == _table[i, j].GetFigure.IsWhite)
                                        _table[i, j].DeselectCell();
                                }
                            }
                        }

                        //6 down
                        j = temp.Pos.J;
                        blocked = false;

                        while ((j + 1) < 8)
                        {
                            j++;

                            if (blocked)
                            {
                                _table[i, j].DeselectCell();
                            }
                            else
                            {
                                if (_table[i, j].IsOccupied)
                                {
                                    blocked = true;
                                    if (temp.GetFigure.IsWhite == _table[i, j].GetFigure.IsWhite)
                                        _table[i, j].DeselectCell();
                                }
                            }
                        }

                        //7 left
                        j = temp.Pos.J;
                        blocked = false;

                        while ((i - 1) >= 0)
                        {
                            i--;

                            if (blocked)
                            {
                                _table[i, j].DeselectCell();
                            }
                            else
                            {
                                if (_table[i, j].IsOccupied)
                                {
                                    blocked = true;
                                    if (temp.GetFigure.IsWhite == _table[i, j].GetFigure.IsWhite)
                                        _table[i, j].DeselectCell();
                                }
                            }
                        }

                        //8 right
                        i = temp.Pos.I;
                        blocked = false;

                        while ((i + 1) < 8)
                        {
                            i++;

                            if (blocked)
                            {
                                _table[i, j].DeselectCell();
                            }
                            else
                            {
                                if (_table[i, j].IsOccupied)
                                {
                                    blocked = true;
                                    if (temp.GetFigure.IsWhite == _table[i, j].GetFigure.IsWhite)
                                        _table[i, j].DeselectCell();
                                }
                            }
                        }


                        break;
                    }
                #endregion

                default: break;
            }
        }

        public void CreateDefaultPosition()
        {
            Figure blackCastle1 = new Castle(false, 0, 0);
            Figure blackCastle2 = new Castle(false, 7, 0);
            Figure blackKnight1 = new Knight(false, 1, 0);
            Figure blackKnight2 = new Knight(false, 6, 0);
            Figure blackBishop1 = new Bishop(false, 2, 0);
            Figure blackBishop2 = new Bishop(false, 5, 0);
            Figure blackKing = new King(false, 4, 0);
            Figure blackQueen = new Queen(false, 3, 0);
            Figure blackPawn1 = new Pawn(false, 0, 1);
            Figure blackPawn2 = new Pawn(false, 1, 1);
            Figure blackPawn3 = new Pawn(false, 2, 1);
            Figure blackPawn4 = new Pawn(false, 3, 1);
            Figure blackPawn5 = new Pawn(false, 4, 1);
            Figure blackPawn6 = new Pawn(false, 5, 1);
            Figure blackPawn7 = new Pawn(false, 6, 1);
            Figure blackPawn8 = new Pawn(false, 7, 1);

            Figure whiteCastle1 = new Castle(true, 0, 7);
            Figure whiteCastle2 = new Castle(true, 7, 7);
            Figure whiteKnight1 = new Knight(true, 1, 7);
            Figure whiteKnight2 = new Knight(true, 6, 7);
            Figure whiteBishop1 = new Bishop(true, 2, 7);
            Figure whiteBishop2 = new Bishop(true, 5, 7);
            Figure whiteKing = new King(true, 4, 7);
            Figure whiteQueen = new Queen(true, 3, 7);
            Figure whitePawn1 = new Pawn(true, 0, 6);
            Figure whitePawn2 = new Pawn(true, 1, 6);
            Figure whitePawn3 = new Pawn(true, 2, 6);
            Figure whitePawn4 = new Pawn(true, 3, 6);
            Figure whitePawn5 = new Pawn(true, 4, 6);
            Figure whitePawn6 = new Pawn(true, 5, 6);
            Figure whitePawn7 = new Pawn(true, 6, 6);
            Figure whitePawn8 = new Pawn(true, 7, 6);

            _table[0, 0].PutFigure(blackCastle1);
            _table[1, 0].PutFigure(blackKnight1);
            _table[2, 0].PutFigure(blackBishop1);
            _table[3, 0].PutFigure(blackQueen);
            _table[4, 0].PutFigure(blackKing);
            _table[5, 0].PutFigure(blackBishop2);
            _table[6, 0].PutFigure(blackKnight2);
            _table[7, 0].PutFigure(blackCastle2);
            _table[0, 1].PutFigure(blackPawn1);
            _table[1, 1].PutFigure(blackPawn2);
            _table[2, 1].PutFigure(blackPawn3);
            _table[3, 1].PutFigure(blackPawn4);
            _table[4, 1].PutFigure(blackPawn5);
            _table[5, 1].PutFigure(blackPawn6);
            _table[6, 1].PutFigure(blackPawn7);
            _table[7, 1].PutFigure(blackPawn8);

            _table[0, 7].PutFigure(whiteCastle1);
            _table[1, 7].PutFigure(whiteKnight1);
            _table[2, 7].PutFigure(whiteBishop1);
            _table[3, 7].PutFigure(whiteQueen);
            _table[4, 7].PutFigure(whiteKing);
            _table[5, 7].PutFigure(whiteBishop2);
            _table[6, 7].PutFigure(whiteKnight2);
            _table[7, 7].PutFigure(whiteCastle2);
            _table[0, 6].PutFigure(whitePawn1);
            _table[1, 6].PutFigure(whitePawn2);
            _table[2, 6].PutFigure(whitePawn3);
            _table[3, 6].PutFigure(whitePawn4);
            _table[4, 6].PutFigure(whitePawn5);
            _table[5, 6].PutFigure(whitePawn6);
            _table[6, 6].PutFigure(whitePawn7);
            _table[7, 6].PutFigure(whitePawn8);

        }



    }
}
    
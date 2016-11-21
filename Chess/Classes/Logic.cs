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

        public void Click(Position pos)
        {
            _isWhiteTurn = (_movesCounter % 2 == 0);
            if (_table[pos.I, pos.J].IsOccupied && !_table[pos.I, pos.J].IsSelected)
            {
                if (_isWhiteTurn == _table[pos.I, pos.J].GetFigure.IsWhite)
                {
                    ShowMoves(pos);
                    _table[pos.I, pos.J].IsMoves = true;
                }
            }
            else if (_table[pos.I, pos.J].IsSelected)
            {
                Move(pos);
            }

            else Deselection();
        }

        private void Move(Position pos)
        {

            if (_table[pos.I, pos.J].IsOccupied) _table[pos.I, pos.J].LeaveFigure();

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (_table[i, j].IsMoves)
                    {
                        _table[pos.I, pos.J].PutFigure(_table[i, j].GetFigure);
                        _table[pos.I, pos.J].GetFigure.Pos = pos;
                        _table[i, j].LeaveFigure();
                        break;
                    }

            Deselection();
            _movesCounter++;
        }
        
        private void ShowMoves(Position pos)
        {
            Deselection();
            _isWhiteTurn = (_movesCounter % 2 == 0);
            Cell temp = _table[pos.I, pos.J];
            if (temp.GetFigure.IsWhite == _isWhiteTurn)
            {
                if (temp.IsOccupied)
                {
                    List<Position> posTemp = new List<Position>();
                    _figureName = temp.GetFigure.GetName;
                    posTemp = temp.GetFigure.Moveable();
                    Selection(posTemp);
                    RemoveWrongSelects(temp, pos);
                }
            }
        }

        private void Deselection()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    _table[i, j].DeselectCell();
                    _table[i, j].IsMoves = false;
                }
        }

        private void Selection(List<Position> list)
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    foreach (var temp in list)
                        if (i == temp.I && j == temp.J) _table[i, j].SelectCell();
        }

        private void RemoveWrongSelects(Cell temp, Position pos)
        {
            switch (_figureName)
            {
                #region Убираем лишние ходы пешки
                case "Pawn":
                    {
                        if (temp.GetFigure.IsWhite)
                        {
                            if (_table[pos.I, pos.J - 1].IsOccupied)
                            {
                                _table[pos.I, pos.J - 1].DeselectCell();
                                _table[pos.I, pos.J - 2].DeselectCell();
                            }
                            if (_table[pos.I, pos.J - 2].IsOccupied)
                            {
                                _table[pos.I, pos.J - 2].DeselectCell();
                            }
                            if ((pos.I > 0 && pos.J > 0) && !_table[pos.I - 1, pos.J - 1].IsOccupied)
                            {
                                _table[pos.I - 1, pos.J - 1].DeselectCell();
                            }
                            else
                            {
                                if ((pos.I > 0 && pos.J > 0) && _table[pos.I - 1, pos.J - 1].GetFigure.IsWhite)
                                {
                                    _table[pos.I - 1, pos.J - 1].DeselectCell();
                                }
                            }

                            if ((pos.I < 7 && pos.J > 0) && !_table[pos.I + 1, pos.J - 1].IsOccupied)
                            {
                                _table[pos.I + 1, pos.J - 1].DeselectCell();
                            }
                            else
                            {
                                if ((pos.I < 7 && pos.J > 0) && _table[pos.I + 1, pos.J - 1].GetFigure.IsWhite)
                                {
                                    _table[pos.I + 1, pos.J - 1].DeselectCell();
                                }
                            }
                        }
                        else
                        {
                            if (_table[pos.I, pos.J + 1].IsOccupied)
                            {
                                _table[pos.I, pos.J + 1].DeselectCell();
                                _table[pos.I, pos.J + 2].DeselectCell();
                            }
                            if (_table[pos.I, pos.J + 2].IsOccupied)
                            {
                                _table[pos.I, pos.J + 2].DeselectCell();
                            }
                            if ((pos.I > 0 && pos.J < 7) && !_table[pos.I - 1, pos.J + 1].IsOccupied)
                            {
                                _table[pos.I - 1, pos.J + 1].DeselectCell();
                            }
                            else
                            {
                                if ((pos.I > 0 && pos.J < 7) && !_table[pos.I - 1, pos.J + 1].GetFigure.IsWhite)
                                {
                                    _table[pos.I - 1, pos.J + 1].DeselectCell();
                                }
                            }

                            if ((pos.I < 7 && pos.J < 7) && !_table[pos.I + 1, pos.J + 1].IsOccupied)
                            {
                                _table[pos.I + 1, pos.J + 1].DeselectCell();
                            }
                            else
                            {
                                if ((pos.I < 7 && pos.J < 7) && !_table[pos.I + 1, pos.J + 1].GetFigure.IsWhite)
                                {
                                    _table[pos.I + 1, pos.J + 1].DeselectCell();
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
                                    if (pos.I + i >= 0 && pos.I + i < 8 && pos.J + j >= 0 && pos.J + j < 8)
                                    {
                                        if (temp.GetFigure.IsWhite)
                                        {
                                            if (_table[pos.I + i, pos.J + j].IsOccupied)
                                                if (_table[pos.I + i, pos.J + j].GetFigure.IsWhite)
                                                    _table[pos.I + i, pos.J + j].DeselectCell();
                                        }
                                        else
                                        {
                                            if (_table[pos.I + i, pos.J + j].IsOccupied && !_table[pos.I + i, pos.J + j].GetFigure.IsWhite)
                                                _table[pos.I + i, pos.J + j].DeselectCell();
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
                        int i = pos.I;
                        int j = pos.J;
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
                        i = pos.I;
                        j = pos.J;

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
                        i = pos.I;
                        j = pos.J;

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
                        i = pos.I;
                        j = pos.J;

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
                        int i = pos.I;
                        int j = pos.J;
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
                        j = pos.J;
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
                        j = pos.J;
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
                        i = pos.I;
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
                        for (int i = -1; i <= 1; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
                                if (i == 0 && j == 0) continue;
                                if (pos.I + i >= 0 && pos.I + i < 8 && pos.J + j >= 0 && pos.J + j < 8) 
                                    if (_table[pos.I + i, pos.J + j].IsOccupied && 
                                       (_table[pos.I + i, pos.J + j].GetFigure.IsWhite == temp.GetFigure.IsWhite))
                                        _table[pos.I + i, pos.J + j].DeselectCell();
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
                        int i = pos.I;
                        int j = pos.J;
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
                        i = pos.I;
                        j = pos.J;

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
                        i = pos.I;
                        j = pos.J;

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
                        i = pos.I;
                        j = pos.J;

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
                        i = pos.I;
                        j = pos.J;

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
                        j = pos.J;
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
                        j = pos.J;
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
                        i = pos.I;
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

    }
}
    
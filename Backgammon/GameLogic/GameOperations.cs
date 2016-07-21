using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class GameOperations
    {
        private GameState _gameState;

        public GameOperations(GameState gameState)
        {
            _gameState = gameState;
        }

        public List<int> GetDiceRoll()
        {
            List<int> dice = new List<int>();
            Random rnd = new Random();
            int firstDie = rnd.Next(1, 6);
            int secondDie = rnd.Next(1, 6);

            if (firstDie == secondDie)
            {
                for (int i = 0; i < 4; i++)
                {
                    dice.Add(firstDie);
                }
            }
            else
            {
                dice.Add(firstDie);
                dice.Add(secondDie);
            }

            return dice;
        }

        public bool checkValidMove(int die)
        {
            int start, end;
            int pivot;

            if (_gameState.CurrPlayer.OutsideCheckers > 0)
            {
                if (_gameState.CurrPlayer.IsClockwise)
                {
                    start = 0;
                    end = 6;
                }
                else
                {
                    start = 18;
                    end = 24;
                }

                for (int i = start; i < end; i++)
                {
                    if ((int)_gameState.Board[i].Color == (int)_gameState.CurrPlayer.Color || _gameState.Board[i].Count <= 1)
                    {
                        return true;
                    }
                }

                return false;
            }

            if (_gameState.CurrPlayer.IsClockwise)
            {
                pivot = 24 - die;

                foreach (int column in _gameState.CurrPlayer.ColumnsOccupied)
                {
                    if (column < pivot)
                    {
                        if ((int)_gameState.Board[column + die].Color == (int)_gameState.CurrPlayer.Color || _gameState.Board[column + die].Count <= 1)
                        {
                            return true;
                        }
                        else if (_gameState.CurrPlayer.ColumnsOccupied[0] >= 18)
                        {
                            if (column == pivot || _gameState.CurrPlayer.ColumnsOccupied[0] > pivot)
                            {
                                return true;
                            }
                        }
                    }
                }

                return false;
            }
            else
            {
                pivot = die - 1;

                foreach (int column in _gameState.CurrPlayer.ColumnsOccupied)
                {
                    if (column > pivot)
                    {
                        if ((int)_gameState.Board[column - die].Color == (int)_gameState.CurrPlayer.Color || _gameState.Board[column - die].Count <= 1)
                        {
                            return true;
                        }
                    }
                    else if (_gameState.CurrPlayer.ColumnsOccupied[_gameState.CurrPlayer.ColumnsOccupied.Count - 1] <= 5)
                    {
                        if (column == pivot || _gameState.CurrPlayer.ColumnsOccupied[_gameState.CurrPlayer.ColumnsOccupied.Count - 1] < pivot)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        public bool CheckValidityOfMove(sMove move, List<int> dice)
        {

            if (dice.Contains(move.Die))
            {
                if (_gameState.CurrPlayer.OutsideCheckers > 0 && move.Type == eTypeOfMove.In)
                {
                    if (_gameState.CurrPlayer.IsClockwise &&
                        ((int)_gameState.Board[move.Die - 1].Color == (int)_gameState.CurrPlayer.Color || _gameState.Board[move.Die - 1].Count <= 1))
                    {
                        return true;
                    }
                    else if (!_gameState.CurrPlayer.IsClockwise &&
                      ((int)_gameState.Board[24 - move.Die].Color == (int)_gameState.CurrPlayer.Color || _gameState.Board[24 - move.Die].Count <= 1))
                    {
                        return true;
                    }
                }

                if (_gameState.CurrPlayer.OutsideCheckers == 0 && move.Type != eTypeOfMove.In)
                {
                    if (move.Column != null)
                    {
                        int column = (int)move.Column;

                        if (_gameState.CurrPlayer.ColumnsOccupied.Contains(column))
                        {
                            if (_gameState.CurrPlayer.IsClockwise)
                            {
                                if (column + move.Die < 24)
                                {
                                    if ((int)_gameState.Board[column + move.Die].Color == (int)_gameState.CurrPlayer.Color || _gameState.Board[column + move.Die].Count <= 1)
                                    {
                                        return true;
                                    }
                                }
                                else
                                {
                                    if (_gameState.CurrPlayer.ColumnsOccupied[0] >= 18 && (move.Die == 24 - column || 24 - _gameState.CurrPlayer.ColumnsOccupied[0] < move.Die))
                                    {
                                        return true;
                                    }
                                }

                            }
                            else
                            {
                                if (column - move.Die > -1)
                                {
                                    if ((int)_gameState.Board[column - move.Die].Color == (int)_gameState.CurrPlayer.Color || _gameState.Board[column - move.Die].Count <= 1)
                                    {
                                        return true;
                                    }
                                }
                                else
                                {
                                    if (_gameState.CurrPlayer.ColumnsOccupied[_gameState.CurrPlayer.ColumnsOccupied.Count - 1] <= 5 && (move.Die == column + 1 || _gameState.CurrPlayer.ColumnsOccupied[_gameState.CurrPlayer.ColumnsOccupied.Count - 1] < move.Die))
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        public void MakeMove(sMove move)
        {
            int columnTo;
            

            if (move.Type == eTypeOfMove.In)
            {
                if (_gameState.CurrPlayer.IsClockwise)
                {
                    MakeInMove(move.Die - 1);
                }
                else
                {
                    MakeInMove(24 - move.Die);
                }
            }
            else
            {
                int columnFrom = (int)move.Column;

                if (_gameState.CurrPlayer.IsClockwise)
                {
                    columnTo = columnFrom + move.Die;

                    if (columnTo > 23)
                    {
                        _gameState.CurrPlayer.RemovedCheckers++;
                    }
                    else
                    {
                        MakeRegularMove(columnTo);
                    }
                }
                else
                {
                    columnTo = columnFrom - move.Die;

                    if (columnTo < 0)
                    {
                        _gameState.CurrPlayer.RemovedCheckers++;
                    }
                    else
                    {
                        MakeRegularMove(columnTo);
                    }
                }

                _gameState.Board[columnFrom].Count--;
                if (_gameState.Board[columnFrom].Count == 0)
                {
                    _gameState.Board[columnFrom].Color = eOccupiedColor.Empty;
                    _gameState.CurrPlayer.ColumnsOccupied.Remove(columnFrom);
                }
            }
        }

        private void MakeInMove(int column)
        {
            if ((int)_gameState.Board[column].Color != (int)_gameState.CurrPlayer.Color)
            {
                if (_gameState.Board[column].Count != 0)
                {
                    _gameState.OtherPlayer.OutsideCheckers++;
                    _gameState.OtherPlayer.ColumnsOccupied.Remove(column);
                }
                else
                {
                    _gameState.Board[column].Count++;
                }

                _gameState.Board[column].Color = (eOccupiedColor)((int)_gameState.CurrPlayer.Color);
                _gameState.CurrPlayer.ColumnsOccupied.Add(column);
                _gameState.CurrPlayer.ColumnsOccupied.Sort();
            }
            else
            {
                _gameState.Board[column].Count++;
            }

            _gameState.CurrPlayer.OutsideCheckers--;


        }

        private void MakeRegularMove(int columnTo)
        {
            if ((int)_gameState.Board[columnTo].Color == (int)_gameState.OtherPlayer.Color)
            {
                _gameState.OtherPlayer.OutsideCheckers++;
                _gameState.Board[columnTo].Color = (eOccupiedColor)((int)_gameState.CurrPlayer.Color);

                _gameState.OtherPlayer.ColumnsOccupied.Remove(columnTo);
                _gameState.CurrPlayer.ColumnsOccupied.Add(columnTo);
                _gameState.CurrPlayer.ColumnsOccupied.Sort();
            }
            else if (_gameState.Board[columnTo].Color == eOccupiedColor.Empty)
            {
                _gameState.Board[columnTo].Color = (eOccupiedColor)((int)_gameState.CurrPlayer.Color);
                _gameState.Board[columnTo].Count++;

                _gameState.CurrPlayer.ColumnsOccupied.Add(columnTo);
                _gameState.CurrPlayer.ColumnsOccupied.Sort();
            }
            else
            {
                _gameState.Board[columnTo].Count++;
            }
        }
    }
}

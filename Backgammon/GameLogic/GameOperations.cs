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
	
	        if(_gameState.CurrPlayer.IsClockwise) 
            {
                pivot = 24 - die;
		        
                foreach(int column in _gameState.CurrPlayer.ColumnsOccupied) 
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
		        
                foreach(int column in _gameState.CurrPlayer.ColumnsOccupied) 
                {
			        if (column > pivot) 
                    {
                        if ((int)_gameState.Board[column - die].Color == (int)_gameState.CurrPlayer.Color || _gameState.Board[column - die].Count <= 1) 
                        {
                            return true;
                        }
                    } 
                    else if (_gameState.CurrPlayer.ColumnsOccupied[_gameState.CurrPlayer.ColumnsOccupied.Count] <= 5) 
                    {

                    
                        if (column == pivot || _gameState.CurrPlayer.ColumnsOccupied[_gameState.CurrPlayer.ColumnsOccupied.Count] < pivot) 
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
            throw new NotImplementedException();
        }

        public void MakeMove(sMove move)
        {
            throw new NotImplementedException();
        }
    }
}

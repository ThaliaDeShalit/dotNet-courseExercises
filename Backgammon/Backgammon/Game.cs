using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic;

namespace Backgammon
{
    class Game
    {
        public void Run()
        {
            string firstPlayerName;
            string secondPlayerName;
            string winner = string.Empty;

            UI userInterface = new UI();
            List<int> dice;

            firstPlayerName = userInterface.GetName();
            secondPlayerName = userInterface.GetName();

            GameState currGameState = new GameState(firstPlayerName, secondPlayerName);
            GameOperations gameOperator = new GameOperations(currGameState);

            bool gameOver = false;
            bool hasValidMoves = false;

            sMove move;

            // maybe add dice roll to determine who starts?

            while (!gameOver)
            {
                userInterface.DrawBoard(); //(screen.clear)

                Console.WriteLine("please press any key to roll dice");
                Console.Read();
                dice = gameOperator.GetDiceRoll();

                Console.WriteLine("the dice roll are: {0} and {1}", dice[0], dice[1]);

                while (dice.Count > 0)
                {
                    foreach (int die in dice)
                    {
                        if (gameOperator.checkValidMove(die))
                        {
                            hasValidMoves = true;
                            break;
                        }
                    }

                    if (!hasValidMoves)
                    {
                        Console.WriteLine("no legal moves");
                        break;
                    }
                    else
                    {
                        move = getMove();

                        while (!gameOperator.CheckValidityOfMove(move, dice))
                        {
                            Console.WriteLine("you cant make that move, enter a valid move");
                        }

                        gameOperator.MakeMove(move);
                        dice.Remove(move.Die);

                        if (currGameState.CurrPlayer.RemovedCheckers == 15)
                        {
                            gameOver = true;
                            winner = currGameState.CurrPlayer.Name;
                            break;
                        }
                    }

                    if (!gameOver)
                    {
                        currGameState.NextTurn();
                    }
                    else
                    {
                        Console.WriteLine("Game over, the winner is {0}", winner);
                    }
                }
            }
        }

        public sMove getMove() 
        {
            string input = string.Empty;
            char[] splitBy = {','};
            string[] parsedInput = null;
            int die;
            int column;

            Console.WriteLine("please enter move in the format ‘x,y’ where x marks the number of colom from which to move or ‘in’ for re-entry of checker to game, and y marks the die used");

            while(true) 
            {
                input = Console.ReadLine();
                parsedInput = input.Split(splitBy);

                if (parsedInput.Length == 2) 
                {
                    if (parsedInput[0] == "in") 
                    {
			            if (int.TryParse(parsedInput[1], out die) && die >= 1 && die <= 6) 
                        {
				        return new sMove(null, die, eTypeOfMove.In);
			            }
                    }

                    if (int.TryParse(parsedInput[0], out column) && int.TryParse(parsedInput[1], out die))
                    {
                        if (column >= 1 && column <= 24 && die >= 1 && die <= 6)
                        {
                            return new sMove(column - 1, die, eTypeOfMove.Regular);
                        }
                    }

                    Console.WriteLine("invalid input, please enter a valid input");
		        }
            }
        }	
    }
}

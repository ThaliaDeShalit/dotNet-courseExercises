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
            StringBuilder sb = new StringBuilder();

            UI userInterface = new UI();
            List<int> dice;

            firstPlayerName = userInterface.GetName("first");
            secondPlayerName = userInterface.GetName("second");

            bool gameOver = false;
            bool hasValidMoves = false;

            sMove move;

            int firstPlayerFirstDieRoll;
            int secondPlayerFirstDieRoll;
            Random rnd = new Random();

            Console.WriteLine("{0}, please roll die to determine who starts by pressing enter", firstPlayerName);
            Console.ReadLine();
            firstPlayerFirstDieRoll = rnd.Next(1, 6);
            Console.WriteLine("{0}, you got {1}. \n{2}, please roll die to determine who starts by pressing enter", firstPlayerName, firstPlayerFirstDieRoll, secondPlayerName);
            Console.ReadLine();
            secondPlayerFirstDieRoll = rnd.Next(1, 6);

            while (firstPlayerFirstDieRoll == secondPlayerFirstDieRoll)
            {
                Console.WriteLine("{0}, you got {1} which means you got a tie. {2} please roll again", secondPlayerName, secondPlayerFirstDieRoll, firstPlayerName);
                Console.ReadLine();
                firstPlayerFirstDieRoll = rnd.Next(1, 6);
                Console.WriteLine("{0}, you got {1}. \n{2}, please roll again", firstPlayerName, firstPlayerFirstDieRoll, secondPlayerName);
                Console.ReadLine();
                secondPlayerFirstDieRoll = rnd.Next(1, 6);
            }

            GameState currGameState = new GameState(firstPlayerName, secondPlayerName, firstPlayerFirstDieRoll, secondPlayerFirstDieRoll);
            GameOperations gameOperator = new GameOperations(currGameState);

            Console.WriteLine("{0}, you got {1} which means {2} plays first", secondPlayerName, secondPlayerFirstDieRoll, currGameState.CurrPlayer.Name);
            Console.WriteLine();

            string xPlayer = currGameState.CurrPlayer.Color == eColor.Black? currGameState.CurrPlayer.Name: currGameState.OtherPlayer.Name;
            string oPlayer = xPlayer.Equals(currGameState.CurrPlayer.Name) ? currGameState.OtherPlayer.Name : currGameState.CurrPlayer.Name;

            Console.WriteLine("{0}, you play X. {1}, you play O. please press enter to start playing", xPlayer, oPlayer);
            Console.ReadLine();

            while (!gameOver)
            {
                userInterface.DrawBoard(currGameState.Board); 

                Console.WriteLine("{0}, please press enter to roll dice", currGameState.CurrPlayer.Name);
                Console.Read();
                dice = gameOperator.GetDiceRoll();

                Console.WriteLine("the dice are: {0} and {1}", dice[0], dice[1]);

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
                        move = userInterface.GetMove();

                        while (!gameOperator.CheckValidityOfMove(move, dice))
                        {
                            Console.WriteLine("you cant make that move, enter a valid move");
                            move = userInterface.GetMove();
                        }

                        gameOperator.MakeMove(move);
                        dice.Remove(move.Die);

                        userInterface.DrawBoard(currGameState.Board);

                        for (int i = 0; i < dice.Count; i++)
                        {
                            sb.Append(dice[i] + " ");
                        }

                        Console.WriteLine("reamining dice are: {0}", sb.ToString());
                        sb.Clear();

                        if (currGameState.CurrPlayer.RemovedCheckers == 15)
                        {
                            gameOver = true;
                            winner = currGameState.CurrPlayer.Name;
                            break;
                        }
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
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic;

namespace Backgammon
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstPlayerName;
            string secondPlayerName;

            UI userInterface = new UI();
            sDiceRolls currentRoll;
            
            GameState currGameState;
            GameOperations gameOperator;

            firstPlayerName = userInterface.GetName();
            secondPlayerName = userInterface.GetName();

            while (true)
            {
                userInterface.DrawBoard();

                currentRoll = userInterface.RollDice();

                gameOperator.CalcValidMoves(currGameState.CurrentPlayer, currentRoll);


            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic;

namespace Backgammon
{
    public class UI
    {
        public string GetName()
        {
            string nameOfPlayer;

            Console.WriteLine("Please enter a name:");
            while ((nameOfPlayer = Console.ReadLine()).Length < 0)
            {
                Console.WriteLine("Name is invalid, please enter a valid name");
            }

            return nameOfPlayer;
        }

        public sDiceRolls RollDice()
        {
            Console.WriteLine("Please press any key to roll dice");
            Console.ReadLine();

            sDiceRolls diceRoll = new sDiceRolls(sDiceRolls.DiceRoll(), sDiceRolls.DiceRoll());

            Console.WriteLine("You have rolled {0} and {1}", diceRoll.FirstDice, diceRoll.SecondDice);

            return diceRoll;
        }
    }
}

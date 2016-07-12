using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 

namespace GameUI
{
    public class UI
    {
        public static string GetName()
        {
            string nameOfPlayer;

            Console.WriteLine("Please enter a name:");
            while ((nameOfPlayer = Console.ReadLine()).Length < 0)
            {
                Console.WriteLine("Name is invalid, please enter a valid name");
            }

            return nameOfPlayer;
        }

        public static int[] rollDice()
        {
            Console.WriteLine("Please press any key to roll dice");
        }
    }
}

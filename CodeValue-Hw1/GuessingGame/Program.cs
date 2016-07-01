using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int secret = new Random().Next(1, 100);
            int numOfGuesses = 1;
            string input;
            int numberFromInput;
            string output;

            Console.WriteLine("Please guess a number between 1-100");
            input = Console.ReadLine();
            numberFromInput = int.Parse(input);

            while (numOfGuesses <= 7 && numberFromInput != secret)
            {
                if (numberFromInput < secret)
                {
                    Console.WriteLine("Your guess is too small, please guess again");
                }
                else
                {
                    Console.WriteLine("Your guess is too big, please guess again");
                }
                
                input = Console.ReadLine();
                numberFromInput = int.Parse(input);

                numOfGuesses++;
            }

            if (numOfGuesses != 8)
            {
                output = String.Format(@"Yay, you have correctly guessed in {0} guesses!", numOfGuesses);
            }
            else
            {
                output = String.Format(@"You failed, the right number was {0}", secret);
            }

            Console.WriteLine(output);
        }
    }
}

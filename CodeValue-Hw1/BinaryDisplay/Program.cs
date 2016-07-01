using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDisplay
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = null;
            int numFromUser = 0;
            bool wasSuccesful = false;
            int sumOfOnes = 0;

            while (!wasSuccesful)
            {
                Console.WriteLine("Please enter an integer");
                input = Console.ReadLine();
                wasSuccesful = int.TryParse(input, out numFromUser);
            }

            Console.WriteLine("The binary represantation of {0} is {1}", numFromUser, Convert.ToString(numFromUser, 2));

            for (int i = 0; i < 32; i++)
            {
                if ((numFromUser & 0x1) == 1)
                {
                    sumOfOnes++;
                }

                numFromUser >>= 1;
            }

            Console.WriteLine("The number of \"1\"s in {0} is {1}", input, sumOfOnes);
        }
    }
}

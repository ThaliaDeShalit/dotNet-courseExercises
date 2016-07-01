using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarStairs
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int numberFromInput = 0;
            bool wasParsedSuccesfully = false;
            StringBuilder sb = new StringBuilder();

            while (!wasParsedSuccesfully)
            {
                Console.WriteLine("please enter an integer");
                input = Console.ReadLine();
                wasParsedSuccesfully = int.TryParse(input, out numberFromInput);
            }

            for (int i = 0; i < numberFromInput; i++)
            {
                sb.Append("$");
                Console.WriteLine(sb.ToString());
            }
        }
    }
}

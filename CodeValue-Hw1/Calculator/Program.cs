using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            double x, y;
            double result = 0;

            Console.WriteLine("input first double");
            input = Console.ReadLine();
            x = double.Parse(input);

            Console.WriteLine("input second double");
            input = Console.ReadLine();
            y = double.Parse(input);

            Console.WriteLine("input an operator out of the following: +, -, *, /");
            input = Console.ReadLine();

            while (input != "+" && input != "-" && input != "*" && input != "/")
            {
                Console.WriteLine("bad input, please enter a valid input");
                input = Console.ReadLine();
            }

            switch (input)
            {
                case "+":
                    result = x + y;
                    break;
                case "-":
                    result = x - y;
                    break;
                case "*":
                    result = x * y;
                    break;
                case "/":
                    while (y == 0)
                    {
                        Console.WriteLine("You can not divide by 0, please enter another denominator");
                        string helper = Console.ReadLine();
                        y = double.Parse(helper);
                    }

                    result = x / y;
                    break;
            }

            Console.WriteLine("{0} {1} {2} = {3}", x, input, y, result);
        }
    }
}

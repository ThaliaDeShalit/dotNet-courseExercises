using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            string numberInString;
            int number;

            Console.WriteLine("What's your name?");
            name = Console.ReadLine();
            
            Console.WriteLine("Hello " + name);
            Console.WriteLine("Enter a number between 1-10");
            numberInString = Console.ReadLine();

            number = int.Parse(numberInString);

            for (int i = 0; i < number; i++)
            {
                // using the name variable to add spaces to the outpur
                name = " " + name;

                Console.WriteLine(name);
            }
        }
    }
}

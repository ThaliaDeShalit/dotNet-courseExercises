using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            int x, y;
            int[] primes;

            while (!int.TryParse(input.Split()[0], out x) || !int.TryParse(input.Split()[1], out y))
            {
                Console.WriteLine("Please enter two integer in the following format: x y");
                input = Console.ReadLine();
            }

            if (x > y)
            {
                primes = CalcPrimes(y, x);
            }
            else
            {
                primes = CalcPrimes(x, y);
            }

            Console.WriteLine("the primes are:");
            foreach (int prime in primes)
            {
                Console.Write("{0} ", prime);
            }
        }

        static int[] CalcPrimes(int x, int y)
        {
            ArrayList primeNumbers = new ArrayList();
            int[] numToReturn;

            for (int i = x; i <= y; i++)
            {
                if (isPrime(i))
                {
                    primeNumbers.Add(i);
                }
            }

            numToReturn = new int[primeNumbers.Count];
            primeNumbers.CopyTo(numToReturn);

            return numToReturn;
        }

        private static bool isPrime(int num)
        {
            if (num <= 1)
            {
                return false;
            }
            else
            {
                for (int i = 2; (double)i <= Math.Sqrt((double) num); i++)
                {
                    if (num % i == 0)
                    {
                        return false;
                    }

                }
                return true;
            }
        }
    }
}

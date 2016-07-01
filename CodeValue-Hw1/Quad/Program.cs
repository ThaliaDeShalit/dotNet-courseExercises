using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quad
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c;

            if (args.Length < 3)
            {
                Console.WriteLine("Not enough args");
                return;
            }

            if (!(double.TryParse(args[0], out a) && double.TryParse(args[1], out b) && double.TryParse(args[2], out c))) {
                Console.WriteLine("one of the arguments is invalid");
                return;
            }


            solveQuadratic(a, b, c);            
        }

        private static void solveQuadratic(double a, double b, double c)
        {
            double sqrtpart = b * b - 4 * a * c;
            double x, x1, x2;

            if (sqrtpart > 0)
            {
                x1 = (-b + Math.Sqrt(sqrtpart)) / (2 * a);
                x2 = (-b - Math.Sqrt(sqrtpart)) / (2 * a);
                Console.WriteLine("Two Solutions: {0,8:f4} or  {1,8:f4}", x1, x2);
            }
            else if (sqrtpart < 0)
            {
                Console.WriteLine("No Solutions");
            }
            else
            {
                x = (-b + Math.Sqrt(sqrtpart)) / (2 * a);
                Console.WriteLine("One Solution: {0,8:f4}", x);
            }
        }
    }
}

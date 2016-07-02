using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    class Program
    {
        static void Main(string[] args)
        {
            Rational r1 = new Rational(2, 5); // 2/5
            Rational r2 = new Rational(-1, 3); // -1/3
            Rational r3 = new Rational(1); // 1/1
            Rational r4 = new Rational(4, 3); // 4/3

            // checking numerator property
            Console.WriteLine("Numerator for r1 (which is {0}) is {1}", r1, r1.Numerator);

            // checking denominator property
            Console.WriteLine("Denominator for r2 (which is {0}) is {1}", r2, r2.Denominator);

            // checking double value property
            Console.WriteLine("Double value for {0} is {1}, for {2} is {3}, and for {4} is {5}", r1, r1.DoubleValue, r3, r3.DoubleValue, r4, r4.DoubleValue);

            // checking add
            Console.WriteLine("{0} + {1} = {2}", r1, r2, r1.Add(r2));
            Console.WriteLine("{0} + {1} = {2}", r3, r2, r2.Add(r3));

            // checking mul
            Console.WriteLine("{0} * {1} = {2}", r1, r4, r1.Mul(r4));
            Console.WriteLine("{0} * {1} = {2}", r2, r3, r2.Mul(r3));

            // checking reduce, which happens automaticly in toString
            Rational r5 = new Rational(4, 16);
            Console.WriteLine("{0} / {1} = {2} = {3}", 4, 16, r5, r5.DoubleValue);

            int x = 2;
            Rational r6 = x;
            Rational r7 = new Rational(2, 10);
            double d = (double)r7;

            Console.WriteLine("int x = 2, Rational r6 = x = {0}", r6);        
            Console.WriteLine("Rational r7 = {0}, double d = (double)r7 = {1}", r7, d);


            Console.WriteLine("{0} * {1} = {2}", r5, r6, r5 * r6);
            Console.WriteLine("{0} / {1} = {2}", r6, r5, r6 / r5);
            Console.WriteLine("{0} - {1} = {2}", r6, 2, r6 - 2); 
        }
    }
}

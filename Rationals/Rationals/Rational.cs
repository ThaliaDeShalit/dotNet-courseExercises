using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    struct Rational
    {
        private int _numerator;
        private int _denominator;

        internal Rational(int numerator, int denominator)
        {
            _numerator = numerator;
            _denominator = denominator;
        }

        internal Rational(int numerator)
        {
            _numerator = numerator;
            _denominator = 1;
        }

        internal int Numerator
        {
            get
            {
                return _numerator;
            }
            private set
            {
                _numerator = value;
            }
        }

        internal int Denominator
        {
            get
            {
                return _denominator;
            }
            private set
            {
                _denominator = value;
            }
        }

        internal double DoubleValue
        {
            get
            {
                return (double)_numerator / (double)_denominator;
            }
        }

        internal Rational Add(Rational x)
        {
            return new Rational((x.Numerator * Denominator + Numerator * x.Denominator), (x.Denominator * Denominator));
        }

        internal Rational Mul(Rational x)
        {
            return new Rational((x.Numerator * Numerator), (x.Denominator * Denominator));
        }

        internal void Reduce()
        {
            int gcd = GCD(Numerator, Denominator);

            Numerator /= gcd;
            Denominator /= gcd;
        }

        private int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        public override bool Equals(Object o)
        {
            bool isEqual = false;

            if (o is Rational)
            {
                Rational r = (Rational)o;
                isEqual = Numerator * r.Denominator == Denominator * r.Numerator;
            }

            return isEqual;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int newDenominator = 0;

            Reduce();

            // if rational is in the type of 12/12 or 5/5 or -3/-3
            if (Numerator == Denominator)
            {
                return "1";
            }

            // making sure that in case numerator is positive and denominator is negative, the minus sign is infornt of the rational
            if (Denominator < 0)
            {
                if (Numerator > 0)
                {
                    sb.Append("-");
                    newDenominator = Denominator * (-1);
                }
            }

            sb.Append(Numerator);
            sb.Append("/");
            if (newDenominator != 0)
            {
                sb.Append(newDenominator);
            }
            else
            {
                sb.Append(Denominator);
            }

            return sb.ToString();
        }
    }
}

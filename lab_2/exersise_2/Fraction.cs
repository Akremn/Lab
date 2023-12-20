using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exersise_2
{
    public partial class Fraction
    {
        private long _numerator;
        private long _denominator;

        public Fraction(long numerator, long denominator)
        {

            long gcd = Gcd(numerator, denominator);

            if (denominator != 0)
            {
                _numerator = numerator / gcd;
                _denominator = denominator / gcd;


                if (_numerator < 0 && _denominator < 0)
                {
                    _numerator = Math.Abs(_numerator);
                    _denominator = Math.Abs(_denominator);
                }
                else if (_denominator < 0)
                {
                    _numerator = -_numerator;
                    _denominator = Math.Abs(_denominator);
                }
            }
            else
            {
                throw new ArgumentException("denome must mot contaic zero value");
            }

        }

        public override string ToString()
        {
            if (_numerator == _denominator)
            {
                return _numerator.ToString();
            }
            else
            {
                return _numerator + "/" + _denominator;
            }

        }
        public long Numerator
        {
            get { return _numerator; }
        }

        public long Denominator
        {
            get { return _denominator; }
        }



        public string ToStringWithIntPart()
        {
            long wholePart = _numerator / _denominator;
            long numerator = _numerator % _denominator;

            string str = "(" + Math.Abs(wholePart) + "+" + Math.Abs(numerator) + "/" + Math.Abs(_denominator) + ")";

            if (_numerator < 0 || _denominator < 0)
            {
                str = "-(" + Math.Abs(wholePart) + "+" + Math.Abs(numerator) + "/" + Math.Abs(_denominator) + ")";
            }
            return str;
        }
        public double ToDouble()
        {
            return Convert.ToDouble(_numerator) / Convert.ToDouble(_denominator);
        }

        public static long Gcd(long a, long b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == 0)
            {
                return 1;

            }
            else
            {
                while (a != 0 && b != 0)
                {
                    if (a > b)
                    {
                        a %= b;

                    }
                    else
                    {
                        b %= a;
                    }
                }

                long gcd = a + b;

                return gcd;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exersise_2
{
    public partial class Fraction
    {
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            long newNumberator = f1._numerator * f2._denominator + f1._denominator * f2._numerator;
            long newDenominator = f1._denominator * f2._denominator;
            return new Fraction(newNumberator, newDenominator);
        }
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            long newNumberator = f1._numerator * f2._denominator - f1._denominator * f2._numerator;
            long newDenominator = f1._denominator * f2._denominator;
            return new Fraction(newNumberator, newDenominator);
        }
        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            long newNumberator = f1._numerator * f2._denominator;
            long denominator = f1._denominator * f2._numerator;
            return new Fraction(newNumberator, denominator);
        }
        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            long newNumberator = f1._numerator * f2._numerator;
            long denominator = f1._denominator * f2._denominator;
            return new Fraction(newNumberator, denominator);
        }
    }
}

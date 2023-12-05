using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ConsoleApp9
{
    public class MyFrac : IMyNumber<MyFrac>, IComparable<MyFrac>
    {
        public BigInteger Nom { get; private set; } // Чисельник
        public BigInteger Denom { get; private set; } // Знаменник

        public MyFrac(BigInteger nom, BigInteger denom)
        {
            if (denom == 0)
            {
                throw new ArgumentException("Знаменник не може дорівнювати нулю.");
            }

            Nom = nom;
            Denom = denom;
            Simplify(); // Спрощення дробу після ініціалізації
        }

        public MyFrac(int nom, int denom) : this(new BigInteger(nom), new BigInteger(denom)) { } // Конструктор, який приймає значення типу int і викликає конструктор для BigInteger

        public MyFrac Add(MyFrac that)
        {
            // Додавання дробів
            return new MyFrac(
                BigInteger.Add(BigInteger.Multiply(Nom, that.Denom), BigInteger.Multiply(Denom, that.Nom)),
                BigInteger.Multiply(Denom, that.Denom)
            );
        }

        public MyFrac Subtract(MyFrac that)
        {
            // Віднімання дробів
            return new MyFrac(
                BigInteger.Subtract(BigInteger.Multiply(Nom, that.Denom), BigInteger.Multiply(Denom, that.Nom)),
                BigInteger.Multiply(Denom, that.Denom)
            );
        }

        public MyFrac Multiply(MyFrac that)
        {
            // Множення дробів
            return new MyFrac(BigInteger.Multiply(Nom, that.Nom), BigInteger.Multiply(Denom, that.Denom));
        }

        public MyFrac Divide(MyFrac that)
        {
            if (that.Nom == 0)
            {
                throw new DivideByZeroException("Ділення на нуль.");
            }

            // Ділення дробів
            return new MyFrac(BigInteger.Multiply(Nom, that.Denom), BigInteger.Multiply(Denom, that.Nom));
        }

        private void Simplify()
        {
            // Спрощення дробу до найменших цілих чисел
            BigInteger gcd = BigInteger.GreatestCommonDivisor(Nom, Denom);
            Nom /= gcd;
            Denom /= gcd;
        }

        public override string ToString()
        {
            return $"{Nom}/{Denom}"; // Повернення дробу у форматі "Чисельник/Знаменник"
        }

        public int CompareTo(MyFrac that)
        {
            // Порівняння двох дробів
            MyFrac thisNormalized = new MyFrac(Nom, Denom);
            MyFrac thatNormalized = new MyFrac(that.Nom, that.Denom);

            thisNormalized.Simplify();
            thatNormalized.Simplify();

            return (int)(thisNormalized.Nom * thatNormalized.Denom - thisNormalized.Denom * thatNormalized.Nom);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    public class MyComplex : IMyNumber<MyComplex>
    {
        public double Real { get; private set; } // Дійсна частина комплексного числа
        public double Imaginary { get; private set; } // Уявна частина комплексного числа

        public MyComplex(double re, double im)
        {
            Real = re;
            Imaginary = im;
        }

        public MyComplex Add(MyComplex that)
        {
            return new MyComplex(Real + that.Real, Imaginary + that.Imaginary); // Додавання комплексних чисел
        }

        public MyComplex Subtract(MyComplex that)
        {
            return new MyComplex(Real - that.Real, Imaginary - that.Imaginary); // Віднімання комплексних чисел
        }

        public MyComplex Multiply(MyComplex that)
        {
            return new MyComplex(Real * that.Real - Imaginary * that.Imaginary,
                Real * that.Imaginary + Imaginary * that.Real); // Множення комплексних чисел
        }

        public MyComplex Divide(MyComplex that)
        {
            double denominator = that.Real * that.Real + that.Imaginary * that.Imaginary;

            if (denominator == 0)
            {
                throw new DivideByZeroException("Ділення на нуль.");
            }

            double real = (Real * that.Real + Imaginary * that.Imaginary) / denominator;
            double imaginary = (Imaginary * that.Real - Real * that.Imaginary) / denominator;

            return new MyComplex(real, imaginary); // Ділення комплексних чисел
        }

        public override string ToString()
        {
            return $"{Real} + {Imaginary}i"; // Повернення комплексного числа у вигляді "Дійсна частина + Уявна частина i"
        }
    }
}

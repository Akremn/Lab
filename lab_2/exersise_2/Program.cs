using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exersise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Функція 1

            Console.WriteLine("Enter numberator: ");
            long numberator1 = long.Parse(Console.ReadLine());

            Console.WriteLine("Enter denominator: ");
            long denominator1 = long.Parse(Console.ReadLine());

            Fraction fraction1 = new Fraction(numberator1, denominator1);

            Console.WriteLine("Скорочений дріб: {0}", fraction1);
            Console.WriteLine("Дріб з цілою частиною: {0}", fraction1.ToStringWithIntPart());
            Console.WriteLine("Дріб як подвійний: {0} \n", fraction1.ToDouble());


            //Функція 2

            Console.WriteLine("Enter numberator: ");
            long numberator2 = long.Parse(Console.ReadLine());

            Console.WriteLine("Enter denominator: ");
            long denominator2 = long.Parse(Console.ReadLine());

            Fraction fraction2 = new Fraction(numberator2, denominator2);

            Console.WriteLine("Скорочений дріб: {0}", fraction2);
            Console.WriteLine("Дріб з цілою частиною: {0}", fraction2.ToStringWithIntPart());
            Console.WriteLine("Дріб як подвійний: {0} \n", fraction2.ToDouble());

            //Оператори

            Fraction sum = fraction1 + fraction2;
            Console.WriteLine("\tSum : {0}", sum);


            Fraction difference = fraction1 - fraction2;
            Console.WriteLine("\tDifference : {0}", difference);


            Fraction multiply = fraction1 * fraction2;
            Console.WriteLine("\tMulriply : {0}", multiply);


            Fraction division = fraction1 / fraction2;
            Console.WriteLine("\tDivision : {0}", division);


            Console.ReadKey();
        }
    }
}

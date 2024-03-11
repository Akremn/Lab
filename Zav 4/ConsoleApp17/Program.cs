using System;

namespace lab4oop
{
    class Program
    {
        delegate double Equation(double x);
        static void Main(string[] args)
        {
            Console.WriteLine("Вводьте рядки послідовно один за одним. \nПоки вони матимуть вигляд 0 x чи 1 x чи 2 x \n(тобто, цифра від 0 до 2, а після неї запис конкретного дійсного числа),\nпрограма обчислюватиме одну з трьох функцій");
            Console.WriteLine("0 -- sqrt(abs(x))");
            Console.WriteLine("1 -- x^3 (інакше кажучи, x*x*x)");
            Console.WriteLine("2 -- x + 3.5");

            Equation[] equations = 
            {
                x => Math.Sqrt(Math.Abs(x)),
                x => Math.Pow(x, 3),
                x => x + 3.5
            };

            while (true)
            {
                try
                {
                    string[] data = Console.ReadLine().Trim().Split();
                    int Index = int.Parse(data[0]);
                    double operand = double.Parse(data[1]);

                    double result = equations[Index](operand);
                    Console.WriteLine($"Результат: {result}");
                }
                catch (Exception a)
                {
                    Console.WriteLine("Помилка");
                    break;
                }
            }
        }
    }
}
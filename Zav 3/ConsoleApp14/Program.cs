using SeriesUtils;
using System;

namespace SeriesUtils
{
    public delegate double SeriesTerm(int n);
    public static class SeriesCalculator
    {
        public static double CalculateSeriesSum(SeriesTerm termFun, double precision)
        {
            double sum = 0;
            double term = termFun(0);
            int n = 0;

            while (Math.Abs(term) >= precision)
            {
                sum += term;
                n++;
                term = termFun(n);
            }
            

            return sum;
        }

        public static double GeometricSeriesTerm(int n)
        {
            return 1.0 / Math.Pow(2, n);
        }
        public static double Factorial(int n)
        {
            double term = 1.0;
            for (int i = 1; i <= n; i++)
            {
                term *= i;
            }
            return term;
        }
        public static double FactorialSeriesTerm(int n)
        {
            return 1.0 / Factorial(n + 1);
        }
        public static double AlternatingSeriesTerm(int n)
        {
            return Math.Pow(-1, n + 1) / Math.Pow(2, n);
        }
        
    }
}

public class Program
{
    public static void Main()
    {
        double geometricSum = SeriesCalculator.CalculateSeriesSum(SeriesCalculator.GeometricSeriesTerm, 0.0001);
        Console.WriteLine($"Sum of the geometric series: {geometricSum}");
        Console.WriteLine();  

        double factorialSum = SeriesCalculator.CalculateSeriesSum(SeriesCalculator.FactorialSeriesTerm, 0.0001);
        Console.WriteLine($"Sum of the factorial series: {factorialSum}");
        Console.WriteLine();  
        
        double alternatingSum = SeriesCalculator.CalculateSeriesSum(SeriesCalculator.AlternatingSeriesTerm, 0.0001);
        Console.WriteLine($"Sum of the alternating series: {alternatingSum}");
    }
}
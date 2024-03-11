using System;
using System.Linq;

namespace ArrayUtils
{
    public class Program
    {
        public delegate bool FilterDelegate(int number, int k);
        public static void Main()
        {
            Console.Write("Введіть масив чисел через пробіл: ");
            int[] originalArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.Write("Введіть значення k: ");
            int k = int.Parse(Console.ReadLine());

            FilterDelegate filterDelegate = IsMultiple;

            // Using Where method
            int[] filteredArrayWhere = FilterArrayUsingWhere(originalArray, k, filterDelegate);
            Console.WriteLine("Filtered Array using Where method:");
            foreach (var num in filteredArrayWhere)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            // Using custom implementation
            int[] filteredArrayCustom = FilterArrayWithoutLibrary(originalArray, k, filterDelegate);
            Console.WriteLine("Filtered Array using custom implementation:");
            foreach (var num in filteredArrayCustom)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
        public static int[] FilterArrayUsingWhere(int[] inputArray, int k, FilterDelegate filter)
        {
            var result = inputArray.Where(x => filter(x, k)).ToArray();
            return result;
        }
        public static int[] FilterArrayWithoutLibrary(int[] inputArray, int k, FilterDelegate filter)
        {
            int count = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (filter(inputArray[i], k))
                {
                    count++;
                }
            }

            int[] resultArray = new int[count];
            int index = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (filter(inputArray[i], k))
                {
                    resultArray[index] = inputArray[i];
                    index++;
                }
            }

            return resultArray;
        }
        static bool IsMultiple(int number, int k)
        {
            if (number == 0)
            {
                return false;
            }
            return number % k == 0;
        }
    }
}
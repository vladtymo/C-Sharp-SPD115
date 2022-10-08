using System;
using System.Linq;

namespace _04_arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --------------- Arrays
            int[] numbers = new int[] { 6, 1, 3, 10, 33 };

            Console.WriteLine("Item count: " + numbers.Length);

            Array.Sort(numbers);
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] - {numbers[i]}");
            }

            Array.Fill(numbers, 7);
            foreach (int num in numbers)
            {
                Console.WriteLine("Element: " + num);
            }

            // --------------- Multi-dimentional arrays
            int[,] matrix = new int[3, 4]
            {
                {1, 2, 3, 4 },
                {5, 6, 7, 8 },
                {9, 10, 11, 12 }
            };

            Console.WriteLine("Matrix length: " + matrix.Length);

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
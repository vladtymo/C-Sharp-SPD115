using System;

namespace _02_base_statements
{
    internal class Program
    {
        enum Direction { Left, Right, Up, Down };

        static void Main(string[] args)
        {
            if (5 > 10)
            {
                Console.WriteLine("Bigger!");
            }
            else
            {
                Console.WriteLine("Smaller");
            }

            string result = (4 % 2 == 0) ? "Even" : "Odd";

            Direction dir = Direction.Left;

            switch (dir)
            {
                case Direction.Left:
                    break;
                default:
                    break;
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            while (false) 
            {
                Console.WriteLine("while cycle");
            }
            do
            {
                Console.WriteLine("do while cycle");
            } while (false);
        }
    }
}

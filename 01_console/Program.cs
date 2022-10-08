using System;

namespace c_sharp_first_app
{
    class Program
    {
        static void Main(string[] args)
        {
            // -=-=-=-=-=-=-=-=- Console Input/Output -=-=-=-=-=-=-=-=-

            Console.WriteLine("Hello!"); // with end line
            Console.WriteLine("Hello!"); // without end line

            // snippet: cw + TAB = Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("\n\t\'!!!\'"); // with escape
            Console.WriteLine(@"\n\t\'!!!\'"); // without escape

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Hello, dear " + name + " !!!");
            // interpolation: $"...{expression}..."
            Console.WriteLine($"Hello, dear {name} !!!");

            int a = 5, b = 10;
            Console.WriteLine($"{a} + {b} = {a + b}");

            // parsing: converting from string to type

            Console.Write("Enter current temperature in °C: ");
            float temperature = float.Parse(Console.ReadLine());

            Console.WriteLine($"{temperature}°C = {(temperature * 9/5) + 32}°F");

            // read pressed key
            Console.Write("Press any key: ");

            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.F12)
                Console.WriteLine("F12 - Have a good day!");
        }
    }
}

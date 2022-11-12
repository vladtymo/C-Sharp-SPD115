// ----------- Delegates -----------
// create delegate: delegate return_type Name(parameters...);
using static System.Net.Mime.MediaTypeNames;

delegate void AriphmeticOperation(double a, double b);

delegate int ChangeValue(int value);

internal class Program
{
    static void Test(int a)
    {
        Console.WriteLine($"{a} * {a} = {a * a}");
    }

    // ariphmetic methods
    static void Add(double left, double right) => Console.WriteLine($"{left} + {right} = {left + right}");
    static void Sub(double left, double right) => Console.WriteLine($"{left} - {right} = {left - right}");
    static void Mult(double left, double right) => Console.WriteLine($"{left} * {right} = {left * right}");
    static void Div(double left, double right)
    {
        if (right == 0) Console.WriteLine("Cannot divide by zero!");
        else Console.WriteLine($"{left} / {right} = {left / right}");
    }

    // change array method
    static void ChangeArray(int[] array, ChangeValue algo)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = algo(array[i]);
        }
    }

    // change value methods
    static int Increase(int value) => value + 1;
    static int Decrease(int value) => value - 1;
    static int Randomize(int value) => new Random().Next(Math.Abs(value));    

    static void ShowArray<T>(T[] array, string title)
    {
        Console.Write($"{title}: ");
        foreach (var item in array) Console.Write(item + " ");
        Console.WriteLine();
    }

    // initialize array method
    static void Initialize(int[] array, Func<int, int> init)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = init(i);
        }
    }

    private static void Main(string[] args)
    {
        // ------- set delegate
        AriphmeticOperation operation = Add;
                
        //operation?.Invoke(10, 7);

        //// operation = Test; // error - Test does not match the delegate prototype
        //operation = Mult;
        //operation(10, 7);

        //operation = Div;
        //operation(10, 7);

        // ------- delegate array
        var operations = new AriphmeticOperation[] { Add, Sub, Mult, Div, Add, Sub, Mult, Div, Add, Sub, Mult, Div };

        //Console.Write("Enter operation (1-4): ");
        //int opNum = int.Parse(Console.ReadLine());

        //operations[opNum - 1].Invoke(10, 20);

        // ------- delegate as a method parameter
        int[] numbers = { 5, 2, 7, -30, 0, 9, 12, 33 };

        ShowArray(numbers, "Original array");

        ChangeArray(numbers, Increase);
        ShowArray(numbers, "Changed array");

        // ------- anonymous methods
        //operation = Add;
        //operation = delegate (double a, double b) { Console.WriteLine($"{a} + {b} = {a + b}"); };
        operation = (a, b) => Console.WriteLine($"{a} + {b} = {a + b}");

        //Initialize(numbers, (i) => i * 3);
        //Initialize(numbers, (i) => new Random().Next(100));
        Initialize(numbers, (i) => (int)Math.Pow(2, i));
        ShowArray(numbers, "Initialized array");

        ChangeArray(numbers, (num) => num * num);
        ShowArray(numbers, "Changed array");

        // ------- Sustem Delegates
        // without return type
        Action greeting = () => Console.WriteLine("Hello!");
        Action<double, double> action = Mult;
        greeting();
        action(4, 5);

        // with return type
        Func<string, string> func = (name) => $"Hello, dear {name}!";
        Console.WriteLine(func("Vlad"));
    }
}
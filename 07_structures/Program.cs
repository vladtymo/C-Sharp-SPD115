namespace _07_structures
{
    struct TimeStruct // can not inherite other classes/structures
    {
        public int Seconds { get; set; }
        public int Minutes { get; set; }
        public int Hours { get; set; }

        public TimeStruct(int seconds, int minutes, int hours)
        {
            Seconds = seconds;
            Hours = hours;
            Minutes = minutes;
        }

        public override string ToString()
        {
            return $"Time - {Hours}:{Minutes}:{Seconds}";
        }
    }
    class TimeClass
    {
        public int Seconds { get; set; }
        public int Minutes { get; set; }
        public int Hours { get; set; }

        public TimeClass(int seconds, int minutes, int hours)
        {
            Seconds = seconds;
            Hours = hours;
            Minutes = minutes;
        }

        public override string ToString()
        {
            return $"Time - {Hours}:{Minutes}:{Seconds}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // --------------------- class

            TimeClass timeClass = null;          // empty reference (null)

            timeClass = new TimeClass(35, 7, 2); // allocate memory and create the instance

            Console.WriteLine(timeClass);

            // --------------------- struct

            TimeStruct timeStruct;                 // allocate memory and create the instance

            timeStruct = new TimeStruct(35, 7, 2); // invoke constructor and initialize

            Console.WriteLine(timeStruct);
        }
    }
}
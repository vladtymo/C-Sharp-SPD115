namespace _08_operator_overloading
{
    public class Kettle
    {
        private int currentVolume; // ml

        public string Model { get; set; }
        public string Color { get; set; }
        public int Capacity { get; init; } // [init] allows to assign a value to the property only during object construction
        public int CurrentVolume
        {
            get { return currentVolume; }
            set 
            {
                if (value < 0)
                    currentVolume = 0;
                else if (value > Capacity)
                    currentVolume = Capacity;
                else
                    currentVolume = value;
            }
        }

        public Kettle(string model, string color, int capacity = 0)
        {
            this.Model = model;
            this.Color = color;
            this.Capacity = capacity;
            this.CurrentVolume = 0;
        }

        public bool IsEmpty() => CurrentVolume == 0;
        public void Clear() => CurrentVolume = 0;

        public override string ToString()
        {
            return $"Kettle {Model} {Color} contains {CurrentVolume}ml of {Capacity}ml";
        }

        // -------------- operator overloading --------------
        /* ref out - not allow
           overload template:

                public static return_type operator[symbol](parameters)
                {
                    // code...
                } 
        */

        // [--] and [++] operators must return the result object
        public static Kettle operator++(Kettle kettle)
        {
            kettle.CurrentVolume += 100;
            return kettle;
        }
        public static Kettle operator--(Kettle kettle)
        {
            kettle.CurrentVolume -= 100;
            return kettle;
        }

        public static Kettle operator +(Kettle left, Kettle right)
        {
            Kettle kettle = new(left.Model, left.Color)
            {
                Capacity = left.Capacity + right.Capacity,
                CurrentVolume = left.CurrentVolume + right.CurrentVolume
            };

            return kettle;
        }

        // [>] and [<] operators must be overloaded together
        public static bool operator >(Kettle left, Kettle right)
        {
            return left.Capacity > right.Capacity;
        }
        public static bool operator <(Kettle left, Kettle right)
        {
            return !(left > right);
        }

        // Equals() and GetHashCode() methods are recommended to be overrided 
        // if equality is going to be defined
        public override bool Equals(object? obj)
        {
            return obj is Kettle kettle &&
                   Capacity == kettle.Capacity;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Capacity);
        }

        // [==] and [!=] operators must be overloaded together
        public static bool operator ==(Kettle left, Kettle right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(Kettle left, Kettle right)
        {
            return !(left == right);
        }

        // [true] and [false] operators must be overloaded together
        public static bool operator true(Kettle kettle)
        {
            return !kettle.IsEmpty();
        }
        public static bool operator false(Kettle kettle)
        {
            return kettle.IsEmpty();
        }
        
        public static explicit operator int(Kettle kettle)
        {
            return kettle.CurrentVolume;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Kettle k1 = new Kettle("Phillips", "White", 300);
            Kettle k2 = new Kettle("Tefal", "Red", 3200);

            ++k1;
            --k2;

            Console.WriteLine(k1);
            Console.WriteLine(k2);

            Kettle k3 = k1 + k2;

            Console.WriteLine(k3);

            if (k1 > k2) Console.WriteLine("Kettle 1 bigger than kettle 2!");
            else Console.WriteLine("Kettle 1 not bigger than kettle 2!");

            if (k1 == k2) Console.WriteLine("Kettle 1 is equals kettle 2!");
            else Console.WriteLine("Kettle 1 is not equals kettle 2!");

            //k1.Clear();
            if (k1) Console.WriteLine("Kettle 1 contains some liquid!");
            else Console.WriteLine("Kettle 1 does not contains any liquid!");

            int volume = (int)k1;
            Console.WriteLine($"Kettle 2 current volume: {volume}ml");
            Console.WriteLine($"Kettle 2 current volume: {(int)k2}ml");
        }
    }
}
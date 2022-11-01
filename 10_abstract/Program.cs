namespace _10_abstract
{
    // abstract class - can contains abstract methods
    // you can not create an instance of the abstract class
    abstract class Transport
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Country { get; set; }
        public float Speed { get; set; }

        // abstract methods - does not has a realisation
        public abstract void Start();

        public abstract void Stop();
    }

    class Auto : Transport
    {
        public int Weels { get; set; }

        public override void Start()
        {
            Console.WriteLine($"Start driving on the car with {Speed} km/h");
        }
        public override void Stop()
        {
            Speed = 0;
            Console.WriteLine($"Stop driving with {Speed} km/h");
        }
    }
    class Airplane : Transport
    {
        public float FlyHeight { get; set; }

        public override void Start()
        {
            Console.WriteLine($"Airplane is taking off up to the {FlyHeight} m height...");
        }
        public override void Stop()
        {
            FlyHeight = 0;
            Console.WriteLine($"Airplane is landing!");
        }
    }

    class Ship : Transport
    {
        public bool IsSailOpen { get; set; }

        public override void Start()
        {
            IsSailOpen = true;
            Console.WriteLine($"Ship is sailing off");
        }
        public override void Stop()
        {
            IsSailOpen = false;
            Console.WriteLine($"Ship is sailing up");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Transport[] transports = new Transport[]
            {
                // error with creating the abstract class
                //new Transport()
                //{
                //    Name = "Some transport",
                //    Country = "Israel",
                //    Speed = 23,
                //    Year = 2009
                //},
                new Auto()
                {
                    Name = "Audi A7",
                    Country = "Germany",
                    Speed = 120,
                    Year = 2017,
                    Weels = 4
                },
                new Airplane()
                {
                    Name = "Boeign 777",
                    Country = "England",
                    Speed = 560,
                    Year = 2006,
                    FlyHeight = 2200
                },
                new Ship()
                {
                    Name = "Titanius",
                    Country = "Irland",
                    Speed = 400,
                    Year = 2010,
                    IsSailOpen = true
                }
            };

            foreach (var item in transports)
            {
                Console.WriteLine($"----- [{item.Name}] -----");
                item.Start();
                item.Stop();
            }
        }
    }
}
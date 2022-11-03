namespace _11_interfaces
{
    interface IScreen
    {
        // interface can define methods, properties, events
        // interface member can not has a realisation
        // all interface members have public access

        int BrightnessLevel { get; set; }

        void TurnOn();
        void IncreaseBrightness();
    }

    // Interface implementation: class Name : Interface, Interface2
    class Laptop : IScreen
    {
        public string Proccessor { get; set; }
        public int BrightnessLevel { get; set; }

        public void OpenBrowser()
        {
            Console.WriteLine("Opening Chrome browser...");
        }
        public void TurnOn()
        {
            Console.WriteLine("Laptop is turning on...");
        }
        public void IncreaseBrightness()
        {
            BrightnessLevel += 10;
            Console.WriteLine("Increasing brightness to 65%...");
        }
    }
    class TV : IScreen
    {
        public int Channels { get; set; }
        public int BrightnessLevel { get; set; }

        public void ChangeChannel()
        {
            Console.WriteLine("Changing channel to 8...");
        }
        public void TurnOn()
        {
            Console.WriteLine("TV is turning on and set the first channel...");
        }
        public void IncreaseBrightness()
        {
            Console.WriteLine("Increasing brightness to 80%...");
        }
    }
    class Monitor : IScreen
    {
        public float Frequency { get; set; }
        public int BrightnessLevel { get; set; }

        public void ChangeColorProfile()
        {
            Console.WriteLine("Changing color profile to RGB...");
        }
        public void TurnOn()
        {
            Console.WriteLine("Monitor is turning on...");
        }
        public void IncreaseBrightness()
        {
            Console.WriteLine("Increasing brightness to 100%...");
        }
    }

    class Router
    {
        public int Antenas { get; set; }
        public void TransferData()
        {
            Console.WriteLine("Transfering data between local devices...");
        }
    }

    internal class Program
    {
        public static void ShowVideo(IScreen screen)
        {
            screen.TurnOn();
            screen.IncreaseBrightness();
            Console.WriteLine($"Wathing video with {screen.BrightnessLevel}% of brightness.");
        }
        static void Main(string[] args)
        {
            Laptop laptop = new Laptop();
            TV tv = new TV();
            Monitor monitor = new Monitor();
            Router router = new Router();

            //ShowVideo(router); // error
            ShowVideo(laptop);
            ShowVideo(tv);
            ShowVideo(monitor);

            // interface reference
            //IScreen screen = new IScreen(); // cannot create an interface instance

            // interface array
            IScreen[] screens = new IScreen[]
            {
                monitor, tv, laptop
            };

            screens[1].TurnOn();
        }
    }
}
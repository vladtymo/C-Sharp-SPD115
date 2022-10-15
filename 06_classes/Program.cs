namespace _06_classes
{
    // Access Specificators
    /*
     * private (default for field)
     * protected internal
     * protected 
     * internal - access from assembly (default for classes)
     * public
     */
    public class Door
    {
        // ------------ fields
        private float width;
        private float height;
        private bool isOpen;

        // readonly and const
        public readonly int id; // you can initialize or set the value from constructor
        public const string type = "furniture"; // you can initialize only

        // static fields and methods
        private static int count = 0; // shared for all class instances
        public static int GetDoorCount() => count;

        // public getter & setter
        public void SetWidth(float newWidth)
        {
            if (newWidth > 0) 
                this.width = newWidth;
        }
        public float GetWidth()
        {
            return this.width;
        }

        // ------------ properties
        // snippet: propfull
        public float Height
        {
            get 
            {
                return this.height;
            }
            set 
            {
                if (value > 0)
                    this.height = value;
            }
        }

        // readonly property - you can read the value but not set the value

        //public double GetArea() { return width * height; }
        //public double Area
        //{
        //    get
        //    {
        //        return width * height;
        //    }
        //}
        //public double Area
        //{
        //    get => width * height;
        //}
        public double Area => width * height; // getter only

        // ------------ auto-property - auto generate private field with public property (get & set)
        // snippet: prop

        //private string color;
        //public string Color
        //{
        //    get { return color; }
        //    set { color = value; }
        //}
        public string Color { get; set; }

        // ------------ constructor
        public Door(string color, float width, float height)
        {
            this.id = 1000 + count;
            this.Color = color;
            this.width = width;
            this.height = height;
            this.isOpen = false;

            ++count;
        }

        // ------------ methods
        public void Close()
        {
            this.isOpen = false;
        }
        public void Open()
        {
            this.isOpen = true;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"-------- Door [{id}] --------");
            Console.WriteLine($"Door is {(isOpen ? "opened" : "closed")}!");
            Console.WriteLine($"Door size: {width} x {height}cm");
            Console.WriteLine($"Door color: {Color}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Door door = new Door("Brown", 130, 290);

            door.Open();
            door.ShowInfo();

            door.Color = "Gray";

            door.SetWidth(100);
            door.SetWidth(-5); // ignore
            float w = door.GetWidth();

            door.Height = 240; // set 
            door.Height = -20; // ignore
            float h = door.Height; // get

            Console.WriteLine("-----------------------");
            Console.WriteLine("Width: " + w + "cm");
            Console.WriteLine("Height: " + h + "cm");

            Console.WriteLine($"Door area: {door.Area / 10000}m^2\n");

            for (int i = 0; i < 3; i++)
            {
                Door d = new Door("Test", 90, 250);
                Console.WriteLine("ID - " + d.id);
            }

            // static method invokation
            Console.WriteLine("Door count: " + Door.GetDoorCount());
        }
    }
}
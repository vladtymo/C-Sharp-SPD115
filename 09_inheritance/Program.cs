namespace _09_inheritance
{
    public class Person
    {
        private int id;
        protected int age;
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Country { get; set; }

        public Person() { }
        public Person(string name)
        {
            this.Name = name;
        }
        public void ShowInfo()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Birthdate: " + Birthdate.ToLongDateString());
            Console.WriteLine("Country: " + Country);
        }

        // you can override virtual methods in the derived classes
        public virtual void ShowTypeName()
        {
            Console.WriteLine("My type is class Person!");
        }
    }

    // Derived class can has only one parent class and many interfaces
    // Inheritance template: class Child : Parent_class, Interface1, Interface2 { }
    public class Student : Person
    {
        public float AverageMark { get; set; }
        public string Specialisation { get; set; }

        public Student(string name, float avgMark) : base(name)
        {
            this.AverageMark = avgMark;
        }
        public void ShowBonuses()
        {
            if (AverageMark >= 10) Console.WriteLine("Bouses: 100$");
            else Console.WriteLine("No bonuses!");
        }
        public new void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Average mark: " + AverageMark);
            Console.WriteLine("Specialisation: " + Specialisation);
        }
        public override void ShowTypeName()
        {
            Console.WriteLine("My type is class Student!");
        }
    }

    public class Employee : Person
    {
        public decimal Salary { get; set; }

        public void PayTaxes()
        {
            Console.WriteLine("Paid some taxes!");
        }
        public override void ShowTypeName()
        {
            Console.WriteLine("My type is class Employee!");
        }
    }

    public class Manager : Employee
    {
        public string ManagementArea { get; set; }

        public override void ShowTypeName()
        {
            Console.WriteLine("My type is class Manager!");
        }
    }

    class Program
    {
        private static void ShowAge(Person person)
        {
            // age = current year - birth year 
            int age = DateTime.Now.Year - person.Birthdate.Year;
            Console.WriteLine($"{person.Name} has {age} years old.");
        }

        static void Main(string[] args)
        {
            Person p = new Person()
            {
                Name = "Bob",
                Birthdate = new DateTime(1990, 3, 6),
                Country = "Ukraine"
            };
            p.ShowInfo();

            Student st = new Student("Vova", 8.9F)
            {
                Birthdate = new DateTime(2004, 1, 17),
                Country = "Poland",
                Specialisation = "IT"
            };
            st.ShowInfo();
            st.ShowBonuses();

            Manager m = new Manager()
            {
                Birthdate = new DateTime(1988, 3, 6),
                Name = "Nikolia"
            };
            // manager has all the members of the employee and person classes

            ///////////////// new vs override
            Person person = st;

            Console.WriteLine("----------- [new] vs [override] keywords -----------");
            person.ShowInfo();      // from Person class (new)
            person.ShowTypeName();  // from Student class (override)

            ////////////////// array of the classes which based on Person
            Person[] people = new Person[]
            {
                new Person("Vikrotia"),
                new Student("Oleg", 11.3F),
                new Employee(),
                new Manager()
            };

            foreach (var item in people)
            {
                Console.WriteLine("______________________");
                item.ShowTypeName();
                item.ShowInfo();
            }

            ShowAge(m);
        }
    }
}
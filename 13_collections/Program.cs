namespace _13_collections
{
    class User
    {
        public string login { get; set; }
        public string Password { get; set; }
        public User(string login, string password)
        {
            this.login = login;
            this.Password = password;
        }
        public override string ToString()
        {
            return $"User, login: {login}, password: {new string('*', Password.Length)}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ////////////// List
            List<double> list = new List<double> { 3.6, 5, 7.2, 5.5, 12.3 };

            Console.WriteLine($"List count: {list.Count}");
            Console.WriteLine($"List capacity: {list.Capacity}");

            list[0] = 3.7;
            list.Add(4.4);                          // add to the end
            list.AddRange(new[] { 1.0, 2.5, 3 });
            list.Remove(5.5);                       // remove by value
            list.RemoveAt(0);                       // remove by index
            //list.Clear();                         // remove all elements

            if (list.Contains(5)) Console.WriteLine("List contains element [5]");

            Console.WriteLine($"Index of [5]: {list.IndexOf(5)}");

            list.Reverse();                         // reverse element direction

            foreach (var item in list) Console.Write(item + " ");
            Console.WriteLine();

            ////////////// User List
            List<User> users = new List<User>()
            {
                new User("bob228", "Qwer4343"),
                new User("ririri", "Test1"),
                new User("super_user", "eheag9ae4trtgaeg")
            };

            foreach (var u in users) Console.WriteLine(u);

            ////////////// Stack (LI-FO)
            Stack<string> stack = new Stack<string>();

            stack.Push("Oleg");
            stack.Push("Viktoria");
            stack.Push("Alex");

            Console.WriteLine($"Last: {stack.Peek()}"); // show the last element

            while (stack.Count > 0)
            {
                var item = stack.Pop(); // remove the last element
                Console.Write(item + " ");
            }
            Console.WriteLine();

            ////////////// Queue (FI-FO)
            Queue<string> queue = new Queue<string>();

            queue.Enqueue("Oleg");
            queue.Enqueue("Viktoria");
            queue.Enqueue("Alex");

            Console.WriteLine($"Last: {queue.Peek()}"); // show the last element

            while (queue.Count > 0)
            {
                var item = queue.Dequeue(); // remove the last element
                Console.Write(item + " ");
            }
            Console.WriteLine();

            ////////////// Dictionary
            /* 
                [UA] - Ukraine
                [PL] - Poland
                [IT] - Italy
                [SP] - Spain
            */

            // Key type must have GetHashCode() method realisation
            Dictionary<string, string> countries = new Dictionary<string, string>()
            {
                ["UA"] = "Ukraine",
                ["PL"] = "Poland",
                ["IT"] = "Italy",
                ["SP"] = "Spain"
            };

            countries["IT"] = "Tailand";    // change element value
            countries["CN"] = "China";      // create new element

            countries.Add("CU", "Cuba");
            countries.Remove("SP");

            Console.WriteLine($"Is [SP] key exist? {countries.ContainsKey("SP")}");
            Console.WriteLine($"Is [Tailand] value exist? {countries.ContainsValue("Tailand")}");

            //countries.Clear();

            foreach (var c in countries)
            {
                Console.WriteLine($"{c.Key} - {c.Value}");
            }

            Console.Write("Keys: ");
            foreach (var key in countries.Keys)
            {
                Console.Write(key + " ");
            }
            Console.WriteLine();

            Console.Write("Values: ");
            foreach (var val in countries.Values)
            {
                Console.Write(val + " ");
            }
            Console.WriteLine();
        }
    }
}
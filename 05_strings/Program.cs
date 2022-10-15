namespace _05_strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ---------------- varialt to create a string instance
            string str = null;
            str = "Hello, world!";

            char[] symbols = { 'H', 'e', 'l', 'l', 'o' };
            str = new string(symbols);

            str = new string('#', 10); // ##########

            // ---------------- concatination
            string fname = "Vlad", lname = "Tymo";

            str = fname + " - " + lname;

            Console.WriteLine($"Full name: {fname} {lname}");

            // ---------------- string validation
            Console.Write("Enter a string: ");
            str = Console.ReadLine();

            if (string.IsNullOrEmpty(str)) Console.WriteLine("String is null or empty!");
            if (string.IsNullOrWhiteSpace(str)) Console.WriteLine("String is null or white space!");

            // ---------------- string methods
            Console.WriteLine("Substring: " + str.Substring(0, 3)); // "***......."

            string[] words = str.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("Words found: " + words.Length);
            foreach (var word in words)
            {
                Console.WriteLine($"|{word}|");
            }

            string line = string.Join("-", words);
            Console.WriteLine("Line: " + line);

            Console.WriteLine("Replaced '-' to '/': " + line.Replace('-', '/')); 

            Console.WriteLine("Lowercase: " + str.ToLower());
            Console.WriteLine("Uppercase: " + str.ToUpper());

            Console.Write("Enter your email: ");
            string email = Console.ReadLine()!;
            
            Console.WriteLine($"Original: |{email}|");
            Console.WriteLine($"Trimmed: |{email.Trim()}|");
        }
    }
}
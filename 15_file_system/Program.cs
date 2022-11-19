namespace _15_file_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ------------- Files -------------
            const string filePath = @"test.txt";

            // видаляємо файл, якщо він вже існує
            if (File.Exists(filePath))
                File.Delete(filePath);

            // створюємо новий файл та закриваємо його для подальшої роботи
            File.Create(filePath).Close();
            // записуємо у файл текст
            File.WriteAllText(filePath, "Hello file! Text from C#...");
            // дописуємо у файл текст
            File.AppendAllText(filePath, "\nNew line!");
            // копіюємо файл в іншу директорію
            if (!File.Exists("NewFolder/copy.txt"))
                File.Copy(filePath, "NewFolder/copy.txt");

            // зчитуємо текст з файлу
            string text = File.ReadAllText(filePath);

            Console.Write("File content: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(text);
            Console.ResetColor();

            FileInfo file = new FileInfo(filePath);

            //file.Create();
            //file.MoveTo("NewFolder/copy.txt");
            //file.Delete();
            file.Encrypt(); // зашифрувати файл
            file.Decrypt(); // розшифрувати файл
            
            // перегляд інформації про файл
            Console.WriteLine("File information:" +
                $"Name: {file.Name}\n" +
                $"Creation Time: {file.CreationTime}\n" +
                $"Size (MB): {file.Length / 1024.0 / 1024}\n" +
                $"Last Access: {file.LastAccessTime}");

            Console.WriteLine($"\n{new string('-', 30)}\n");

            // ------------- Directories -------------
            const string dirPath = "NewFolder";

            DirectoryInfo dir = new DirectoryInfo(dirPath);

            // створити папку, якщо вона не існує
            if (dir.Exists)
                Console.WriteLine("Directory is already exist!");
            else
                dir.Create();

            //directory.Delete();
            //directory.MoveTo("new path");

            // перегляд інформації про папку
            Console.WriteLine("Directory information:" +
                $"Name: {dir.Name}\n" +
                $"Creation Time: {dir.CreationTime}\n" +
                $"Last Access: {file.LastAccessTime}");

            // перегляд файлів, які знаходяться в директорії
            //      пошуковий шаблон: * - будь-що
            //      включаючи всі вкладені папки
            FileInfo[] files = dir.GetFiles("*.txt", SearchOption.AllDirectories); 

            Console.WriteLine("Files:");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"\tfile [{i}] - {files[i].Name}");
            }
            Console.ResetColor();

            // видалення файла, який вказав користувач
            Console.Write("Enter file index to delete: ");
            int indexToDelete = int.Parse(Console.ReadLine());

            files[indexToDelete].Delete();
        }
    }
}
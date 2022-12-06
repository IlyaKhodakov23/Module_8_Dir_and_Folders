namespace Task1_Module_8
{
    internal class Program
    {
        static string dirName = @"C:\Users\user\Desktop\IT\OldDir";
        static void Main(string[] args)
        {

            //Console.WriteLine(TimeSpan.FromMinutes(30));
            DeleteOldCatalogs(dirName);
        }

        static void DeleteOldCatalogs(string dir)
        {
            if (Directory.Exists(dir))
            {
                Console.WriteLine("Папки:");
                string[] catalogs = Directory.GetDirectories(dir);
                foreach (string c in catalogs)
                {
                    try
                    {
                        Console.WriteLine(c);
                        Console.WriteLine($"Не использовалась: {TimeSpan.FromMinutes(30)}");
                        //if ("Указать что если файлы не используются больше 30 минут")
                        //{
                        //    Console.WriteLine("Папка будет удалена.");
                        // Удаляем папку рекурсивно
                        //    Directory.Delete(c, true);
                        //}
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                string[] files = Directory.GetFiles(dir);
                foreach (string file in files)
                {
                    try
                    {
                        Console.WriteLine(file);
                        Console.WriteLine($"Не использовался: {TimeSpan.FromMinutes(30)}");
                        if ("Указать что если файлы не используются больше 30 минут")
                        {
                            Console.WriteLine("Файл будет удален.");
                            File.Delete(file);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}
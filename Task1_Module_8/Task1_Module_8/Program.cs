namespace Task1_Module_8
{
    internal class Program
    {
        //Напишите программу, которая чистит нужную нам папку от файлов  и папок, которые не использовались более 30 минут 
        static string dirName = @"C:\Users\user\Desktop\IT\OldDir";
        static void Main(string[] args)
        {
            DeleteOldCatalogs(dirName);
        }

        static void DeleteOldCatalogs(string dir)
        {
            //Создаем объект папки
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            //FileInfo fileInfo = new FileInfo(dir);
            //Если существует
            if (dirInfo.Exists)
            {
                Console.WriteLine("Папки:");
                //Получаем Папки из директории
                DirectoryInfo[] catalogs = dirInfo.GetDirectories();
                //Проходимся по папкам
                foreach (DirectoryInfo c in catalogs)
                {
                    try
                    {
                        //Новый объект папка внутри директории
                        DirectoryInfo dirInfo2 = new DirectoryInfo(c.FullName);
                        Console.WriteLine(c);
                        //Находим время с момента последнего доступа
                        TimeSpan diff = DateTime.Now.Subtract(dirInfo2.LastAccessTime);
                        Console.WriteLine(dirInfo2.LastAccessTime);
                        Console.WriteLine($"Не использовалась: {diff}");
                        //Если более 30 минут то удаляем
                        if (diff > TimeSpan.FromMinutes(30))
                        {
                            Console.WriteLine("Папка будет удалена.");
                            // Удаляем папку рекурсивно
                            dirInfo2.Delete(true);
                        }
                        else Console.WriteLine("Папка менялась менее 30 минут назад");
                    }
                    //Начинаем перехватывать ошибки
                    //DirectoryNotFoundException - директория не найдена
                    catch (DirectoryNotFoundException ex)
                    {
                        Console.WriteLine("Директория не найдена. Ошибка: " + ex.Message);
                    }
                    //UnauthorizedAccessException - отсутствует доступ к файлу или папке
                    catch (UnauthorizedAccessException ex)
                    {
                        Console.WriteLine("Отсутствует доступ. Ошибка: " + ex.Message);
                    }
                    //Во всех остальных случаях
                    catch (Exception ex)
                    {
                        Console.WriteLine("Произошла ошибка. Ошибка: " + ex.Message);
                    }
                }
                //Находим все файлы внутри папки и прохоимся по ним делая аналогичные действия
                FileInfo[] files = dirInfo.GetFiles();
                foreach (FileInfo file in files)
                {
                    try
                    {
                        FileInfo fileInfo1 = new FileInfo(file.FullName);
                        Console.WriteLine(file);
                        TimeSpan diff = DateTime.Now.Subtract(fileInfo1.LastAccessTime);
                        Console.WriteLine(diff);
                        Console.WriteLine($"Не использовался: {diff}");
                        if (diff > TimeSpan.FromMinutes(30))
                        {
                            Console.WriteLine("Файл будет удален.");
                            fileInfo1.Delete();
                        }
                        else Console.WriteLine("Файл менялся менее 30 минут назад");
                    }
                    catch (DirectoryNotFoundException ex)
                    {
                        Console.WriteLine("Директория не найдена. Ошибка: " + ex.Message);
                    }
                    //UnauthorizedAccessException - отсутствует доступ к файлу или папке
                    catch (UnauthorizedAccessException ex)
                    {
                        Console.WriteLine("Отсутствует доступ. Ошибка: " + ex.Message);
                    }
                    //Во всех остальных случаях
                    catch (Exception ex)
                    {
                        Console.WriteLine("Произошла ошибка. Ошибка: " + ex.Message);
                    }
                }
            }
        }
    }
}
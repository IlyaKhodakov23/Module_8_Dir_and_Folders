namespace Task_3_Module_8
{
    internal class Program
    {
        //Доработайте программу из задания 1, используя ваш метод из задания 2.
        //При запуске программа должна:
        //Показать, сколько весит папка до очистки.Использовать метод из задания 2. 
        //Выполнить очистку.
        //Показать сколько файлов удалено и сколько места освобождено.
        //Показать, сколько папка весит после очистки.
        static string dirName = @"C:\Users\user\Desktop\IT\OldDir";
        static void Main(string[] args)
        {
            long FirstSize = CheckSize(dirName);
            Console.WriteLine($"Исходный размер папки: {FirstSize} байт");
            Console.WriteLine("Выполняется очистка...");
            DeleteOldCatalogs(dirName);
            long LastSize = CheckSize(dirName);
            long diff = FirstSize - LastSize;
            Console.WriteLine($"Очистка выполнена, освобождено: {diff} байт");
            Console.WriteLine($"Текущий размер папки: {LastSize} байт");
        }
        static void DeleteOldCatalogs(string dir)
        {
            //Создаем объект папки
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            //Если существует
            if (dirInfo.Exists)
            {
                //Получаем Папки из директории
                DirectoryInfo[] catalogs = dirInfo.GetDirectories();
                //Проходимся по папкам
                foreach (DirectoryInfo c in catalogs)
                {
                    try
                    {
                        //Новый объект папка внутри директории
                        DirectoryInfo dirInfo2 = new DirectoryInfo(c.FullName);
                        //Находим время с момента последнего доступа
                        TimeSpan diff = DateTime.Now.Subtract(dirInfo2.LastAccessTime);
                        //Если более 30 минут то удаляем
                        if (diff > TimeSpan.FromMinutes(30))
                        {
                            // Удаляем папку рекурсивно
                            dirInfo2.Delete(true);
                        }
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
                        TimeSpan diff = DateTime.Now.Subtract(fileInfo1.LastAccessTime);
                        if (diff > TimeSpan.FromMinutes(30))
                        {
                            fileInfo1.Delete();
                        }
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
        static long CheckSize(string dir)
        {
            long size = 0;
            try
            {
                //Создаем объект папка
                DirectoryInfo dirInfo = new DirectoryInfo(dir);
                //Берем список всех файлов и всех папок в директории
                FileInfo[] files = dirInfo.GetFiles();
                DirectoryInfo[] dirs = dirInfo.GetDirectories();
                //если папка существует проходимся по файлам
                if (dirInfo.Exists)
                {
                    foreach (FileInfo file in files)
                    {
                        //Считаем размер всех файлов
                        size = size + file.Length;
                    }
                    //Для всех папок в директории применяем рекурсию и считаем размер файлов в них
                    foreach (DirectoryInfo directoryInfo in dirs)
                    {
                        CheckSize(directoryInfo.FullName);
                    }
                }
                return size;
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Директория не найдена. Ошибка: " + ex.Message);
                return 0;
            }
            //UnauthorizedAccessException - отсутствует доступ к файлу или папке
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Отсутствует доступ. Ошибка: " + ex.Message);
                return 0;
            }
            //Во всех остальных случаях
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка. Ошибка: " + ex.Message);
                return 0;
            }
        }
    }
}
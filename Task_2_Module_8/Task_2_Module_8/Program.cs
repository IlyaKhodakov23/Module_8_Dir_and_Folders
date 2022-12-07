namespace Task_2_Module_8
{
    internal class Program
    {
        //Путь к папке
        static string dirName = @"C:\Users\user\Desktop\IT\OldDir";
        static void Main(string[] args)
        {
            long size = CheckSize(dirName);
            Console.WriteLine(size);
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
                        Console.WriteLine(file.FullName);
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
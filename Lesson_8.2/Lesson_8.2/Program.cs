namespace Lesson_8._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // получим системные диски
            DriveInfo[] drives = DriveInfo.GetDrives();

            // Пробежимся по дискам и выведем их свойства
            //foreach (DriveInfo drive in drives)
            //{
            //    Console.WriteLine($"Название: {drive.Name}");
            //    Console.WriteLine($"Тип: {drive.DriveType}");
            //    if (drive.IsReady)
            //    {
            //        Console.WriteLine($"Объем: {drive.TotalSize}");
            //        Console.WriteLine($"Свободно: {drive.TotalFreeSpace}");
            //        Console.WriteLine($"Метка: {drive.VolumeLabel}");
            //    }
            //}
            // Делаем проход только по дискам которые ФИКС, то есть жесткие
            foreach (DriveInfo drive in drives.Where(d => d.DriveType == DriveType.Fixed))
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем: {drive.TotalSize}");
                    Console.WriteLine($"Свободно: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка: {drive.VolumeLabel}");
                }
            }

            //GetCatalogs();
            //string path = @"C:\Users\user\Desktop\Работа";
            //MoveFolder(path);
        }

        //Задание 8.2.1
        //Напишите метод, который считает количество файлов и папок в корне вашего диска и выводит итоговое количество объектов.
        static void GetCatalogs()
        {
            string dirName = @"C:\Users\user\Desktop\IT"; // Прописываем путь к корневой директории MacOS (для Windows скорее всего тут будет "C:\\")
            if (Directory.Exists(dirName)) // Проверим, что директория существует
            {
                Console.WriteLine("Папки:");
                string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога
                int sumdir = 0;
                foreach (string d in dirs) // Выведем их все
                { 
                    Console.WriteLine(d);
                    sumdir++;
                }
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);// Получим все файлы корневого каталога
                int sumfiles = 0;
                foreach (string s in files) // Выведем их все
                {
                    sumfiles++;
                    Console.WriteLine(s);
                }
                Console.WriteLine("Количество папок: {0}, Количество файлов: {1}", sumdir, sumfiles);
                Console.WriteLine(Directory.GetDirectories(dirName).Length);
                //Directory.CreateDirectory(dirName);
                //Задание 8.2.2
                //Добавьте в метод из задания 8.2.1 создание новой директории в корне вашего диска, а после вновь выведите количество элементов уже после создания нового. 
                //Убедитесь, что их количество увеличилось, либо корректно вывелось сообщение об ошибке(если у вас нет прав на запись).
                //DirectoryInfo directoryInfo = new DirectoryInfo(dirName);
                //try
                //{
                //    DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                //    if (dirInfo.Exists)
                //    {
                //        Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
                //    }

                //    DirectoryInfo newDirectory = new DirectoryInfo(@"/newDirectory");
                //    if (!newDirectory.Exists)
                //        newDirectory.Create();

                //    Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine(e.Message);
                //}
                Directory.CreateDirectory(dirName + @"/newDirectory");
                Console.WriteLine(Directory.GetDirectories(dirName).Length);
                DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                Console.WriteLine($"Название каталога: {dirInfo.Name}");
                Console.WriteLine($"Полное название каталога: {dirInfo.FullName}");
                Console.WriteLine($"Время создания каталога: {dirInfo.CreationTime}");
                Console.WriteLine($"Корневой каталог: {dirInfo.Root}");
                Directory.Delete(dirName + @"/newDirectory");
                Console.WriteLine(Directory.GetDirectories(dirName).Length);

                
            }
        }
        //Задание 8.2.4
        //Создайте на рабочем столе папку testFolder.Напишите метод, с помощью которого можно будет переместить её в корзину.
        static void MoveFolder(string path)
        {
            string Path1 = Path.Combine(path, @"\testFolder");
            DirectoryInfo dirInfo = new DirectoryInfo(Path1);
            //if (dirInfo.Exists)
            //{
            //    dirInfo.Create();
            //}
            dirInfo.Create();
            string newPath = @"C:\Users\user\Desktop\ПО\testFolder";
            if (dirInfo.Exists && !Directory.Exists(newPath))
                dirInfo.MoveTo(newPath);

        }
    }
}
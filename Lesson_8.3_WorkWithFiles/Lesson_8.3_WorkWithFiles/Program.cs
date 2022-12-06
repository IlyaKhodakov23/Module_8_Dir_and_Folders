namespace Lesson_8._3_WorkWithFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string filePath = @"/Users/luft/SkillFactory/Students.txt"; // Укажем путь 
            //if (!File.Exists(filePath)) // Проверим, существует ли файл по данному пути
            //{
            //    //   Если не существует - создаём и записываем в строку
            //    using (StreamWriter sw = File.CreateText(filePath))  // Конструкция Using (будет рассмотрена в последующих юнитах)
            //    {
            //        sw.WriteLine("Олег");
            //        sw.WriteLine("Дмитрий");
            //        sw.WriteLine("Иван");
            //    }
            //}
            //// Откроем файл и прочитаем его содержимое
            //using (StreamReader sr = File.OpenText(filePath))
            //{
            //    string str = "";
            //    while ((str = sr.ReadLine()) != null) // Пока не кончатся строки - считываем из файла по одной и выводим в консоль
            //    {
            //        Console.WriteLine(str);
            //    }
            //}

            //Задание 8.3.1
            //Исходный код программы — ещё один отличный пример текстового файла. 
            //Напишите программу, которая выводит свой собственный исходный код в консоль.
            string filePath = @"C:\Users\user\Desktop\IT\Code\Module_8\Lesson_8.3_WorkWithFiles\Lesson_8.3_WorkWithFiles\Program.cs"; // Укажем путь к файлу программы
            //Задание 8.3.2
            //Сделайте так, чтобы ваша программа из задания 8.3.1 при каждом запуске добавляла в свой исходный код комментарий о времени последнего запуска. 
            var fileInfo = new FileInfo(filePath);
            using (StreamWriter sw = fileInfo.AppendText())
            {
                sw.WriteLine($"//Время запуска: {DateTime.Now}");
            }
            using (StreamReader sr = File.OpenText(filePath))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}//Время запуска: 04.12.2022 13:26:43

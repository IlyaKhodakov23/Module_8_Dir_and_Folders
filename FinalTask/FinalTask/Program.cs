using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    internal class Program
    {
        const string StudentsFile = @"C:\Users\user\Desktop\IT\Code\Module_8\Import\Students.dat";
        //Путь на рабочий стол
        const string Desktop = @"C:\Users\user\Desktop";
        static void Main(string[] args)
        {
            //Создаем папку на рабочем столе
            DirectoryInfo dirInfo = new DirectoryInfo(Desktop);
            if (!dirInfo.Exists)
                dirInfo.Create();
            dirInfo.CreateSubdirectory("Students");
            string newdir = Path.Combine(Desktop, "Students");
            BinaryFormatter formatter = new BinaryFormatter();
            //поток десериализации
            using (FileStream fs = new FileStream(StudentsFile, FileMode.Open))
            {
                try
                {
                    //Почему здесь еще в скобках стьюдент нужно разместить перед форматтером?
                    //Это синтаксис, что мы хотим поместить десериализованный поток в объект студент и соответствующие свойства?
                    Student[] student = (Student[])formatter.Deserialize(fs);
                    Console.WriteLine("Объект десериализован");
                    //Почему здесь тип Student? И без []. Это же класс который мы создали, но после десиарилизации он представляет собой массив
                    foreach (Student st in student)
                    {
                        //Создаем файлы по группам
                        string filePath = Path.Combine(newdir, $"{st.Group}.txt"); // Укажем путь
                        if (!File.Exists(filePath)) // Проверим, существует ли файл по данному пути
                        {
                            //   Если не существует - создаём
                            File.Create(filePath);
                        }
                    }
                    //Теперь пройдемся по каждому файлу и заполним его
                    DirectoryInfo di = new DirectoryInfo(newdir);
                    FileInfo[] files = di.GetFiles();
                    foreach(FileInfo file in files)
                    {
                        //!!!!!!!!!!!Здесь при первом запуске возникает ошибка, что файл занят. Не понимаю что делать.
                        //!!!!!!!!!!!При втором запуске все ок. То есть где-то не закрывается
                        using (StreamWriter sw = File.CreateText(file.FullName))
                        {
                            sw.Write("");
                        }
                        
                        foreach (Student st in student)
                        {
                            if (file.Name == st.Group+".txt")
                            {
                                using (StreamWriter sw = File.AppendText(file.FullName))
                                {
                                    sw.WriteLine($"{st.Name}, {st.DateOfBirth}");
                                }
                            }
                        }
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
    //Класс для десиарилизации
    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Student(string name, string group, DateTime dateOfBirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateOfBirth;
        }
    }

}
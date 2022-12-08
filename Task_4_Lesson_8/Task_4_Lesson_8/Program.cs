namespace Task_4_Lesson_8
{
    internal class Program
    {
        //Путь к бинарнику
        const string StudentsFile = @"C:\Users\user\Desktop\IT\Code\Module_8\Import\Students.dat";
        static void Main(string[] args)
        {
            ReadValues();
        }
        static void ReadValues()
        {
            string Names;
            string Groups;
            DateTime DateOfBirth;
            //Создаем объект BinaryWriter и указываем, куда будет направлен поток данных
            using (BinaryReader reader = new BinaryReader(File.Open(StudentsFile, FileMode.Open)))
            {
                Names = reader.ReadString();
                //Groups = reader.ReadString();
                //DateOfBirth = reader.
            }
            Console.WriteLine("Из файла считано");
            Console.WriteLine(Names);
            //Console.WriteLine(Groups);
        }
    }
}
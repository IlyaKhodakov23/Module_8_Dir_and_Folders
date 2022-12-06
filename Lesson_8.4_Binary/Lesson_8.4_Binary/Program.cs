using System.Runtime.Serialization.Formatters.Binary;

namespace Lesson_8._4_Binary
{
    internal class BinaryExperiment
    {
        const string SettingsFileName = @"C:\\Users\\user\\Desktop\\IT\\Code\\Module_8\\Lesson_8.4_Binary\\BinaryFile.bin";
        static void Main(string[] args)
        {
            // Считываем
            //WriteValues();
            //ReadValues();
            //Создание объекта
            var contact = new Contact("Ilya", 88588660, "ilya@mail.ru");
            Console.WriteLine("Object has created");
            //Сериализация
            BinaryFormatter formatter = new BinaryFormatter();
            using (var stream = new FileStream(@"C:\\Users\\user\\Desktop\\IT\\Code\\Module_8\\Lesson_8.4_Binary\\Contact.bin", FileMode.OpenOrCreate))
            {
                formatter.Serialize(stream, contact);
            }


        }

        static void WriteValues()
        {
            // Создаем объект BinaryWriter и указываем, куда будет направлен поток данных
            using (BinaryWriter writer = new BinaryWriter(File.Open(SettingsFileName, FileMode.Open)))
            {
                // записываем данные в разном формате
                //writer.Write(20.666F);
                writer.Write($"Файл изменен {DateTime.Now} на компьютере c ОС {Environment.OSVersion}");
                //writer.Write(55);
                //writer.Write(false);
            }
        }

        static void ReadValues()
        {
            //float FloatValue;
            string StringValue1;
            string StringValue2;
            //int IntValue;
            //bool BooleanValue;

            if (File.Exists(SettingsFileName))
            {
                // Создаем объект BinaryReader и инициализируем его возвратом метода File.Open.
                using (BinaryReader reader = new BinaryReader(File.Open(SettingsFileName, FileMode.Open)))
                {
                    // Применяем специализированные методы Read для считывания соответствующего типа данных.
                    //FloatValue = reader.ReadSingle();
                    StringValue1 = reader.ReadString();
                    //StringValue2 = reader.ReadString();
                    //IntValue = reader.ReadInt32();
                    //BooleanValue = reader.ReadBoolean();
                }

                Console.WriteLine("Из файла считано:");

                Console.WriteLine(StringValue1);
                //Console.WriteLine(StringValue2);
                //Console.WriteLine("Целое: " + IntValue);
                //Console.WriteLine("Булево значение " + BooleanValue);
            }
        }

        //Задание 8.4.2
        //Запишите в файл из предыдущего задания информацию о доступе к нему с вашей машины.
        //Пример вывода, который должен получиться: 
        //Файл изменен 02.11 14:53 на компьютере Windows 11

        //Задание 8.4.3
        //Дан класс:
        //Доработайте его и сериализуйте в бинарный формат.

        [Serializable]
        class Contact
        {
            public string Name { get; set; }
            public long PhoneNumber { get; set; }
            public string Email { get; set; }

            public Contact(string name, long phoneNumber, string email)
            {
                Name = name;
                PhoneNumber = phoneNumber;
                Email = email;
            }


        }
    }
}
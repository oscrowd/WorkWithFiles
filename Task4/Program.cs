using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace Serialization
{
    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Student(string name, string group, DateTime DoB)
        {
            Name = name;
            Group = group;
            DateOfBirth = DoB;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //const string SettingsFileName = "D:\\test1\\Students.dat";
            // Пишем
            //BinaryData binaryData = new BinaryData();
            //binaryData.WriteValues(SettingsFileName);
            //binaryData.ReadValues(SettingsFileName);
            // сохраняем путь к файлу (допустим, вы его скачали на рабочий стол)
            string filePath = "D:\\test1\\Students.dat";
            BinaryFormatter formatter = new BinaryFormatter();
            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                var newStudent = (Student)formatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {newStudent.Name} --- Группа: {newStudent.Group}");
            }
            Console.ReadLine();

        }

        
    }
}

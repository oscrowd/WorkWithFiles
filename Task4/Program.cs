using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace FinalTask
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
       
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            const string SettingsFileName = "D:\\test1\\Students.dat";
            //BinaryData binaryData = new BinaryData();
            //binaryData.WriteValues(SettingsFileName);
            //binaryData.ReadValues(SettingsFileName);
             

            string filePath = "D:\\test1\\Students.dat";
            BinaryFormatter formatter = new BinaryFormatter();
            //Student studentall = new Student();
            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                Student[] students = (Student[])formatter.Deserialize(fs);
                foreach (Student student in students)
                {
                    Console.WriteLine(student.Name);
                }
                
            }
            Console.ReadLine();

            
            Console.ReadLine();
        }
    }
}
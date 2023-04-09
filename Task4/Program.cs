using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
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
            try
            {
                string filePath = "D:\\test1\\Students.dat";
                Boolean DirEx = false;
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Binder = new PreMergeToMergedDeserializationBinder();
                //Создаем папку на рабочем столе Students, если еще не создана
                Dir dir = new Dir();
                dir.DirPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Students";
                DirEx = dir.DirExist();
                if (DirEx == false)
                {
                    dir.DirCreate();
                }
                //Читаем содержимое и разбираем по файлам
                FileManipulate fileManipulate = new FileManipulate();
                using (var fs = new FileStream(filePath, FileMode.Open))
                {
                    Student[] students = (Student[])formatter.Deserialize(fs);
                    foreach (Student student in students)
                    {
                        Boolean FilEx = false;
                        fileManipulate.FilePath = Path.Combine(dir.DirPath, student.Group + ".txt");
                        FilEx = fileManipulate.FileExist();
                        if (FilEx)
                        {
                            fileManipulate.FileWriteAppend(student.Name + " " + student.Group + " " + student.DateOfBirth);
                        }
                        else
                        {
                            //fileManipulate.FileCreate();
                            fileManipulate.FileWrite(student.Name + " " + student.Group + " " + student.DateOfBirth);
                        }
                        Console.WriteLine(student.Name);
                    }

                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Ошибка - {0}", e.Message);

            }
            finally { 
                Console.ReadLine(); 
            }
        }
    }
    sealed class PreMergeToMergedDeserializationBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            Type typeToDeserialize = null;


            // For each assemblyName/typeName that you want to deserialize to
            // a different type, set typeToDeserialize to the desired type.
            String exeAssembly = Assembly.GetExecutingAssembly().FullName;


            // The following line of code returns the type.
            typeToDeserialize = Type.GetType(String.Format("{0}, {1}",
                typeName, exeAssembly));


            return typeToDeserialize;
        }
    }
}
using System;
using System.IO;


public class FilesAndDir
{
    public string DirPath;
    //{
    //    get
    //    {
    //        return DirPath;
    //    }
    //    set
    //    {
    //        DirPath = value;
    //    }
    //}

    public Boolean DirExist()
    {
        var di = new DirectoryInfo(DirPath);
        return di.Exists;
    }
    public void DelPathAndDir()
    {
        //path = DirPath;
        var di = new DirectoryInfo(DirPath);
        foreach (FileInfo file in di.GetFiles())
        {
            file.Delete(); 
        }
        foreach (DirectoryInfo dir in di.GetDirectories())
        {
            dir.Delete(true);
        }

    }
}

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string DPath = "";
            Boolean DirEx = false;
            FilesAndDir filesAndDir = new FilesAndDir();
            Console.WriteLine("Введите путь к директори:");
            filesAndDir.DirPath = Console.ReadLine();
            DirEx = filesAndDir.DirExist();
            
            if (DirEx)
            {
                try
                {
                    filesAndDir.DelPathAndDir();
                    Console.WriteLine("Удалены папки и файлы в директории {0}", filesAndDir.DirPath);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка удаления {0}", e.Message);
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Такой папки не существует");
                Console.ReadKey();
            }



        }
    }
}

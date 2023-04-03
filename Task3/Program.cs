using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long DS = 0;
            long DSafterDel = 0;
            long DelSize = 0;
            Boolean DirEx = false;
            Dir dir = new Dir();
            Console.WriteLine("Введите путь к директори:");
            dir.DirPath = Console.ReadLine();
            DirEx = dir.DirExist();

            if (DirEx)
            {
                try
                {
                    DS = dir.DirSize(dir.DirPath);
                    Console.WriteLine("Исходный размер папки {0} - {1}", dir.DirPath, DS);
                    dir.DelPathAndDir();
                    DSafterDel = dir.DirSize(dir.DirPath);
                    DelSize = DS - DSafterDel;
                    Console.WriteLine("Освобождено - {0}", DelSize);
                    Console.WriteLine("Текущий размер папки {0} - {1}", dir.DirPath, DSafterDel);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка - {0}", e.Message);
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Папки {0} не существует", dir.DirPath);
                Console.ReadKey();
            }
        }
    }
}

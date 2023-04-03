using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long DS = 0;
            Boolean DirEx = false;
            Dir dir = new Dir();
            Console.WriteLine("Введите путь к директори:");
            dir.DirPath = Console.ReadLine();
            DirEx = dir.DirExist();

            if (DirEx)
            {
                try
                {
                    DS = dir.DirSize();
                    Console.WriteLine("Размер директори {0} - {1}", dir.DirPath, DS);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка определения размера папки  {0} - {1}", dir.DirPath, e.Message);
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

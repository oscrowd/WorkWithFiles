using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Dir
    {
        public string DirPath;
        public Boolean DirExist()
        {
            var di = new DirectoryInfo(DirPath);
            return di.Exists;
        }

        public long DirSize()
        {
            
            var d = new DirectoryInfo(DirPath);
            long size = 0;
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize();
            }
            return size;
        }
    }  
}
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

        public object di()
        {
            var di = new DirectoryInfo(DirPath);
            return di;
        }
        public Boolean DirExist()
        {
            var di = new DirectoryInfo(DirPath);
            return di.Exists;
        }

        public long DirSize(string DPath)
        {
            
            var d = new DirectoryInfo(DPath);
            long size = 0;
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                string DP = di.FullName;
                size += DirSize(DP);
            }
            return size;
        }
    }  
}
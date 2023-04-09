using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask
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

        public void DirCreate() 
        {
            var di = new DirectoryInfo(DirPath);
            di.Create();
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
        public void DelPathAndDir()
        {
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

    public class FileManipulate : Dir
    {
        public string FilePath;
        public Boolean FileExist()
        {
            var fi = new FileInfo(FilePath);
            return fi.Exists;
        }
        public void FileCreate()
        { 
            var fc = new FileInfo(FilePath);
            fc.Create();
            
        }
        public void FileWrite(string fstring)
        {
            var fw = new FileInfo(FilePath);
            using (StreamWriter sw = fw.CreateText())
            {
                sw.WriteLine(fstring);
            }
            
        }
        public void FileWriteAppend(string fstring)
        {
            var fw = new FileInfo(FilePath);
            using (StreamWriter sw = fw.AppendText())
            {
                sw.WriteLine(fstring);
            }

        }
    }
}
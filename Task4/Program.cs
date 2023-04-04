using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string SettingsFileName = "D:\\test1\\Students.dat";
            // Пишем
            BinaryData binaryData = new BinaryData();
            //binaryData.WriteValues(SettingsFileName);
            binaryData.ReadValues(SettingsFileName);
            
        }
    }
}

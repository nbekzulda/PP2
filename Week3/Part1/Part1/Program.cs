using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemInfo[] second = DirectoryInfo.GetFileSystemInfo("C:/Users/acer optane/Desktop/PP2/LABS/Week1");

            for (int i = 0; i < second.Length; i++)
            {
                Console.WriteLine(second[i].);
            }
            Console.ReadKey();
        }


    }
}

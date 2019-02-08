using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void PrintSpaces(int level)
        {
            for (int i = 0; i < level; i++)
                Console.Write("  ");
        }
        static void FD(DirectoryInfo directory, int level)
        {
            FileInfo[] files = directory.GetFiles();
            DirectoryInfo[] directories = directory.GetDirectories();

            foreach (FileInfo file in files)
            {
                PrintSpaces(level);
                Console.WriteLine(file.Name);
            }

            foreach (DirectoryInfo d in directories)
            {
                PrintSpaces(level);
                Console.WriteLine(d.Name);
                FD(d, level + 1);
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo("C:/Users/acer optane/Desktop/PP2labs/Week1");
            FD(d, 0);
            Console.ReadKey();

        }
    }
}

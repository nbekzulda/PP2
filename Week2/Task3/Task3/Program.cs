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
            FileInfo[] files = directory.GetFiles(); //collect files in directory in array
            DirectoryInfo[] directories = directory.GetDirectories(); //collect subdirectories in array

            foreach (FileInfo file in files) // at first out all files in directory
            {
                PrintSpaces(level);
                Console.WriteLine(file.Name);
            }

            foreach (DirectoryInfo d in directories) //then out all subdirectories
            {
                PrintSpaces(level);
                Console.WriteLine(d.Name);
                FD(d, level + 1); //recall function for each subdirectory of main directory, while subdirectories exist
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo("C:/Users/acer optane/Desktop/PP2labs/Week1"); //init new directory from that path
            FD(d, 0);
            Console.ReadKey();

        }
    }
}

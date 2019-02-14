using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Program
    {
        class FarManager 
        {
            int cursor = 0; 
            string path;
            DirectoryInfo directory;
            FileSystemInfo[] fs = new FileSystemInfo[70];
            int begin = 0;
            int end = 10;
            int sz;

            public FarManager(string path) 
            {
                this.path = path;
            }

            public void Up()
            {
                cursor--;
                if (cursor < 0)
                {
                    begin = sz - 10;
                    cursor = sz - 1;
                    end = sz;
                }
                else if (cursor < begin)
                {
                    begin--;
                    end--;
                }

            }

            public void Down() 
            {
                cursor++;

                if (cursor == sz)
                {
                    cursor = 0;
                    begin = 0;
                    end = 10;
                }
                else if (cursor >= end)
                {
                    end++;
                    begin++;
                }
            }

            public void Check_Type(FileSystemInfo f, int active) 
            {

                if (f.GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                if (f.GetType() == typeof(FileInfo))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                if (active == cursor)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
            }

            public void Show()
            {
                Console.BackgroundColor = ConsoleColor.Black; 
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                directory = new DirectoryInfo(path);  
                DirectoryInfo[] di = directory.GetDirectories();
                FileInfo[] fi = directory.GetFiles();
                for (int i = 0; i < di.Length; i++)
                    fs[i] = di[i];
                for (int i = 0; i < fi.Length; i++)
                    fs[i + di.Length] = fi[i];
                sz = di.Length + fi.Length;
                for (int i = begin; i < Math.Min(end, sz); i++) 
                {
                    Check_Type(fs[i], i); //coloring
                    Console.WriteLine("{0}. {1}", i + 1, fs[i].Name); 
                }
            }
            public void Start() //main function to run prog
            {
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                while (consoleKey.Key != ConsoleKey.Escape)
                {
                    Show(); //call function to show list dir
                    consoleKey = Console.ReadKey(); 
                    if (consoleKey.Key == ConsoleKey.DownArrow) 
                        Down();
                    if (consoleKey.Key == ConsoleKey.UpArrow) 
                        Up();
                    if (consoleKey.Key == ConsoleKey.Enter) 
                    {
                        if (fs[cursor].GetType() == typeof(DirectoryInfo)) 
                        {
                            directory = new DirectoryInfo(fs[cursor].FullName);
                            path = fs[cursor].FullName;
                            cursor = 0;
                            begin = 0;
                            end = 10;
                        }
                    }
                    if (consoleKey.Key == ConsoleKey.Backspace)
                    {
                        cursor = 0;
                        directory = directory.Parent;
                        path = directory.FullName;
                    }
                    if (consoleKey.Key == ConsoleKey.D) 
                        File.Delete(fs[cursor].FullName);

                    if (consoleKey.Key == ConsoleKey.O) 
                    {
                        if (fs[cursor].GetType() == typeof(FileInfo))
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Clear();
                            string text = File.ReadAllText(fs[cursor].FullName);
                            Console.WriteLine(text);
                            Console.ReadKey();
                        }
                    }
                    if (consoleKey.Key == ConsoleKey.R) 
                    {
                        Console.WriteLine("Please write new name, to rename {0}", fs[cursor].FullName);
                        string name = Console.ReadLine();

                        if (fs[cursor].GetType() == typeof(FileInfo))
                        {
                            string begin = path + '/' + fs[cursor].Name;
                            string extension = Path.GetExtension(fs[cursor].Name); 
                            string end = path + '/' + name + extension;
                            File.Move(@begin, @end); //replace it
                        }
                        else
                        {
                            DirectoryInfo d = new DirectoryInfo(fs[cursor].FullName);
                            string begin = d.FullName;
                            string end = d.Parent.FullName + '/' + name;
                            Directory.Move(@begin, @end);
                        }
                    }
                }
            }

        }
        static void Main(string[] args)
        {
            string origin = "C:/Users/acer optane/Desktop"; 
            FarManager farManager = new FarManager(origin); 
            farManager.Show(); 
            farManager.Start(); 

        }
    }
}
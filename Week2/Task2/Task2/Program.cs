using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("C:\\input.txt");
            String s = sr.ReadToEnd();
            Console.WriteLine(s);
            //  Console.ReadKey();


            string[] arr = s.Split();


            string ss = "";
            for (int j = 0; j < arr.Length; j++)
            {
                int n = int.Parse(arr[j]);
                bool isPrime = true;
                for (int i = 2; i <= Math.Sqrt(n); i++)
                {
                    if (n % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (n != 1 && isPrime)
                {

                    ss += Convert.ToString(n) + " ";

                }
            }

            StreamWriter sw = new StreamWriter("C:\\output.txt");
            sw.WriteLine(ss);
            sw.Close();
        }
        }
}

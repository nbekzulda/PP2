using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        
        
            public static bool Palindrome(string s)
            {
                for (int i = 0, j = s.Length - 1; i < j; i++, j--) //check the string for palindrome
                if (s[i] != s[j])
                    return false;
                return true;
            }
        
        
        static void Main(string[] args)
        {
            string s;
            s = Console.ReadLine();
            if (Palindrome(s)) // if true write yes
        
            
                Console.WriteLine("Yes");
            
            else // if false write no
                Console.WriteLine("No");
    

                Console.ReadKey();
        }
    }
}

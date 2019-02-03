using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Student A = new Student("Nursultan", "18BD110409"); // Student A's name is Aida with 18BD110266 id 
            Console.WriteLine(A.getname() ); // shows student A's name via getname function
            Console.WriteLine(A.getid());//shows student A's id via getid function
            Console.ReadKey(); // pauses the execution of the program
        }
    }

    public class Student //creating a new public class called Student
    {
        private String name; //variables are private
        private String id;
        private int yearOfStudy;

        public Student( String name, String id) //creating a constructor with two parameters such as name, id. 
        {
            this.name = name;//
            this.id = id;
            this.yearOfStudy = 0; //default value 
        }

        public String getname()// function getname returns  this name which is in contructor Student
        {
            return this.name;
        }

        public String getid()//function getid returns  this id which is in contructor Student
        {
            return this.id;
        }

        public void setname()//function setname changes this name to the new name 
        {
          this.name = name;
        }

        public void setid()//function setid changes this id to the new id 
        {
            this.id = id;
        }


       public void incrementOfYear() //the function increments the yearOfStudy;
        {
            this.yearOfStudy++;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Student : IComparable<Student>
    {
        public String name;
        public int age;
        public String test;
        public int mark;
        public DateTime date;
        public Student()
        {
        }
        public Student(String name, int age, String test, int mark, DateTime date)
        {
            this.name = name;
            this.age = age;
            this.test = test;
            this.mark = mark;
            this.date = date;
        }
        public int CompareTo(Student other)
        {        
            if (this.mark < other.mark)
                return -1;
            else if (this.mark > other.mark)
                return 1;
            else 
                return 0;

        }
    }
}

using System;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();

            binaryTree.AddNotify += Print;
            binaryTree.Add(2);
            binaryTree.Add(3);
            binaryTree.Add(4);
            binaryTree.Add(5);
            binaryTree.Add(2);
            binaryTree.Add(5);
            binaryTree.Remove(3);

            bool test = binaryTree.Contains(2);

            BinaryTree<Student> marks = new BinaryTree<Student>();

            List<Student> students = new List<Student>()
            {
                 new Student("V", 3 ),
                 new Student("Y",  4),
                 new Student("U",  6 ),
                 new Student("G",  1 )
            };


            foreach(var item in students)
            {
                marks.Add(item);
            }

            Console.WriteLine("Students marks:");

            foreach(var item in marks)
            {
                Console.WriteLine(item.name + ":" + item.mark);
            }

            DynamicArray<int> array = new DynamicArray<int>(1, 3, 4, 6, 8);

            array[1] = 44;
            array[6] = 7;


            Console.WriteLine("Array values:");



            foreach(var i in array)
            {
                Console.WriteLine(i);
            }
           
            Console.ReadKey();
        }

        
        static void Print(string message)
        {
            Console.WriteLine(message);
        }
      
    }
}

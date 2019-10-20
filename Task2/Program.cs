using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            binaryTree.Add(2);
            binaryTree.Add(3);
            binaryTree.Add(4);
            binaryTree.Add(5);
            binaryTree.Add(2);
            binaryTree.Add(5);
            binaryTree.Remove(3);

            Student student = new Student() { mark = 3 };
            Student student1 = new Student() { mark = 4 };
            Student student2 = new Student() { mark = 6 };
            Student student3 = new Student() { mark = 1 };
            Test<Student> test = new Test<Student>();
            test.Add(student);
            test.Add(student1);
            test.Add(student2);
            test.Add(student3);

            foreach(var item in binaryTree)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}

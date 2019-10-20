using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Test<T>  where T : IComparable<T>
    {
        private class Node<T> 
        {
            public T value;
            public Node<T> leftChild;
            public Node<T> rightChild;
            public Node(T value)
            {
                this.value = value;
            }

        }

        private Node<T> root;
        public int Count { get; private set; }

        public void Add(T value)
        {
            Node<T> newNode = new Node<T>(value);

            if (root == null)
            {
                root = newNode;
            }
            else
            {
                Node<T> current = root;

                while (true)
                {
                    if (value.CompareTo(current.value) < 0)
                    {
                        if (current.leftChild == null)
                        {
                            current.leftChild = newNode;
                            break;
                        }
                        else
                            current = current.leftChild;
                    }
                    else if (value.CompareTo(value) >=0)
                    {
                        if (current.rightChild == null)
                        {
                            current.rightChild = newNode;
                            break;
                        }
                        else
                            current = current.rightChild;
                    }
                    else
                    {
                        throw new Exception("Додавання нового елементу");
                    }
                }
            }
            Count++;
        }

    }
}

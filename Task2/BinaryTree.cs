using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public delegate void EventDelegate(object sender, EventAdd e);


    public class BinaryTree<T>: IEnumerable<T>, ICloneable where T: IComparable<T>
    {
        private class Node
        {
            public T value;
            public Node leftChild;
            public Node rightChild;
            public Node(T value) 
            {
                this.value = value;
            }
        }

        public BinaryTree(params T[] values)
        {
            foreach(var item in values)
            {
                this.Add(item);
            }
        }

        private Node root;
        public int Count { get; private set; }     

        public event EventDelegate AddNotify = null;

        public void Add (T value)
        {
           Node newNode = new Node(value);

            if (root == null)
            {
                root = newNode;
            }
            else {
                Node current = root;

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
                    else if (value.CompareTo(current.value) >=0)
                    {
                        if (current.rightChild == null)
                        {
                            current.rightChild = newNode;
                            break;
                        }
                        else
                            current = current.rightChild;
                    }
                }
            }
            Count++;
            AddNotify?.Invoke(this, new EventAdd("Add " + value));
        }
        public void Remove(T value)
        {
            Node current = root;

            if (value.CompareTo(root.value)==0)
            {
                while (true)
                {
                    if (root.leftChild == null && root.rightChild == null)
                    {
                        root = null;
                        break;
                    }
                    else if (root.leftChild != null && root.rightChild != null)
                    {
                        current = root.rightChild;
                        while(current.leftChild != null)
                        {
                            if (current.leftChild.leftChild == null)
                            {
                                current.leftChild.leftChild = root.leftChild;
                                current.leftChild.rightChild = root.rightChild;
                                root = current.leftChild;
                                current.leftChild = null;
                                break;
                            }
                            current = current.leftChild;
                        }

                        current.leftChild = root.leftChild;
                        root = current;
                        break;
                    }
                    else
                    {
                        if(root.leftChild != null)
                        {
                            root = root.leftChild;
                            break;
                        }
                        if(root.rightChild !=null)
                        {
                            root = root.rightChild;
                            break;
                        }
                    }
                }
            }
            else
            {
                while (true)
                {

                    if (current.leftChild!=null && value.CompareTo(current.leftChild.value) ==0)
                    {

                        if (current.leftChild.leftChild == null && current.leftChild.rightChild == null)
                        {
                            current.leftChild = null;
                            break;
                        }
                        else if (current.leftChild.leftChild != null && current.leftChild.rightChild != null)
                        {
                            Node newNode = current.leftChild.rightChild;
                            while (newNode.leftChild != null)
                            {
                                if(newNode.leftChild.leftChild != null)
                                {
                                    newNode.leftChild.rightChild = current.leftChild.rightChild;
                                    newNode.leftChild.leftChild = current.leftChild.leftChild;
                                    current.leftChild = newNode.leftChild;
                                    newNode.leftChild = null;
                                    break;
                                }
                                newNode = current.leftChild;
                            }

                            newNode.leftChild = current.leftChild.leftChild;
                            current.leftChild = newNode;
                            break;
                            
                        }
                        else
                        {
                            if (current.leftChild.leftChild != null)
                            {
                                current.leftChild = current.leftChild.leftChild;
                                break;
                            }
                            if (current.leftChild.rightChild != null)
                            {
                                current.leftChild = current.leftChild.rightChild;
                                break;
                            }
                        }
                    }
                    if (current.rightChild != null && value.CompareTo((current.rightChild.value)) == 0)
                    {

                        if (current.rightChild.leftChild == null && current.rightChild.rightChild == null)
                        {
                            current.rightChild = null;
                            break;
                        }
                        else if (current.rightChild.leftChild != null && current.rightChild.rightChild != null)
                        {
                            Node newNode = current.rightChild.rightChild;
                            while (newNode.leftChild != null)
                            {
                                if(current.leftChild.leftChild != null)
                                {
                                    newNode.leftChild.leftChild = current.rightChild.leftChild;
                                    newNode.leftChild.rightChild = current.rightChild.rightChild;
                                    current.rightChild = newNode.leftChild;
                                    newNode.leftChild = null;
                                    break;
                                }
                                newNode = newNode.leftChild;
                            }

                            newNode.leftChild = current.rightChild.leftChild;
                            current.rightChild = newNode;
                            break;
                        }
                        else
                        {
                            if (current.rightChild.leftChild != null)
                            {
                                current.rightChild = current.rightChild.leftChild;
                                break;
                            }
                            if (current.rightChild.rightChild != null)
                            {
                                current = current.rightChild.rightChild;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (current.leftChild != null && value.CompareTo(current.value) <0)
                        {
                            current = current.leftChild;
                        }
                        else if (current.rightChild != null && value.CompareTo(current.value) >0)
                        {
                            current = current.rightChild;
                        }
                    }
                }
            }
            Count--;
        }
        public void Clear()
        {
            root = null;
            Count = 0;
        }
        public bool Contains(T value)
        {
            foreach( var item in this)
            {
                if (item.CompareTo(value) == 0)
                    return true;
            }

            return false;
        }
        public object Clone()
        {
            BinaryTree<T> newTree = new BinaryTree<T>();

            foreach (var item in PreOrder())
            {
                newTree.Add(item);
                Console.WriteLine(item);
            }

            return newTree;
        }

        public T MinValue()
        {
            Node current = root;

            while (current.leftChild != null)
            {
                current = current.leftChild;
            }

            return current.value;
        }

        public T MaxValue()
        {
            Node current = root;

            while (current.rightChild != null)
            {
                current = current.rightChild;
            }

            return current.value;
        }
        public IEnumerable<T> InOrder()
        {
            if (root == null) yield break;

            Stack<Node> stack = new Stack<Node>();
            Node node = root;

            while (stack.Count > 0 || node != null)
            {
                if (node == null)
                {
                    node = stack.Pop();
                    yield return node.value;
                    node = node.rightChild;
                }
                else
                {
                    stack.Push(node);
                    node = node.leftChild;
                }
            }
        }

        public IEnumerable<T> PreOrder()
        {
            if (root == null) yield break;

            var stack = new Stack<Node>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                yield return node.value;
                if (node.rightChild != null) stack.Push(node.rightChild);
                if (node.leftChild != null) stack.Push(node.leftChild);
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return PreOrder().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

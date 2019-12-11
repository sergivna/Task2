using System;
using System.Collections.Generic;
using Task2;
using Xunit;
//using static Task2.BinaryTree<T>;

namespace BinaryTreeTests
{
    public class BinaryTreeTests
    {
        [Fact]
        public void ContainsValue__TrueReturned()
        {
            var tree = new BinaryTree<int>(2);

            var expected = true;

            var result = tree.Contains(2);

            Assert.Equal(result, expected);

        }

        [Fact]
        public void Add_5Element__5Returned()
        {
            var tree = new BinaryTree<int>();
            tree.Add(1);
            tree.Add(2);
            tree.Add(3);
            tree.Add(4);
            tree.Add(5);

            var expected = 5;

            var result = tree.Count;

            Assert.Equal(result, expected);
        }

        [Fact]
        public void Clear_0Returned()
        {
            var tree = new BinaryTree<int>();
            tree.Add(2);
            tree.Add(1);

            var expected = 0;

            tree.Clear();

            var result = tree.Count;

            Assert.Equal(result, expected);
        }

        [Fact]
        public void RemoveValue_FalseReturned()
        {
            var tree = new BinaryTree<int>();
            tree.Add(2);

            var expected = false;

            tree.Remove(2);
            bool result = tree.Contains(2);

            Assert.Equal(result, expected);

        }

        [Fact]
        public void SearshMin_MinReturned()
        {
            var tree = new BinaryTree<int>(1,2,3);
            var expected = 1;

            var result = tree.MinValue();

            Assert.Equal(result, expected);

        }

        [Fact]
        public void SearshMax_MaxReturned()
        {
            var tree = new BinaryTree<int>(1, 2, 3);
            var expected = 3;

            var result = tree.MaxValue();

            Assert.Equal(result, expected);

        }

        [Fact]
        public void NotificationAddElement2_MessageAdd2Returned()
        {
            var array = new BinaryTree<int>();

            string actual = null;

            array.AddNotify += delegate (object sender, EventAdd eventArgs)
            {
               actual  = eventArgs.Info;
            };

            array.Add(2);

            Assert.NotNull(actual);
            Assert.Equal("Add 2", actual);
        }
    }
}

using System;
using Xunit;
using Task2;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;

namespace DynamicArrayTests
{
    public class DynamicArrayTests
    {
        [Fact]
        public void GetElementByIndexLessThenFirst__ShouldThrowArrayException()
        {
            
            var array = new DynamicArray<int>(1, 2, 3, 4);
           
            Assert.Throws<ArrayException>(() => array[0] = 4);
        }

        [Fact]
        public void GetElementByIndexGreatThenFirst_ShouldThrowArrayException()
        {
            var array = new DynamicArray<int>(1, 2, 4, 6);

            Assert.Throws<ArrayException>(() => array[4] = 0);
        }

        [Fact]

        public void GetElementFromArray_ElementReturned()
        {
            var array = new DynamicArray<int>(1, 2, 3, 4);

            var expected = 2;

            var result = array[1];

            Assert.Equal(expected, result);
        }

    }
}

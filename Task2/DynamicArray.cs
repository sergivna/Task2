using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class DynamicArray<T> :IEnumerable<T>
    {
        public T[] value;
        private int offset;
        public int Length
        {
            get
            {
                return value.Length;
            }
            private set {}
        }

        public DynamicArray(int index, int legth)
        {
            offset = index;
            value = new T[legth];
        }

        public DynamicArray(int index, params T[] nums)
        {
            value = new T[nums.Length];
            offset = index;
            for(int i = 0; i<value.Length; i++)
            {
                value[i] = nums[i];
            }

        }
        public T this[int index]
        {
            get
            {
                try
                {
                    return value[index - offset];
                }
                catch(Exception ex)
                {
                    throw new ArrayException(ex.Message);
                }
            }
            set
            {
                if (index < offset || index >  Length -1  + offset)
                    throw new ArrayException("Array indices start with " + offset.ToString());
                //if(index - offset + 1 > this.Length)
                //{
                //    T[] temp = new T[this.Length];
                //    for(int i =0; i< temp.Length; ++i)
                //    {
                //        temp[i] = this.value[i];
                //    }
                //    this.value = new T[index - offset + 1];
                //    for (int i = 0; i < temp.Length; ++i)
                //    {
                //        this.value[i] = temp[i];
                //    }
                //}
                this.value[index - offset] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
           foreach (var item in value)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

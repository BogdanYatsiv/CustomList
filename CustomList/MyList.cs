using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    class MyList<T> : IList<T>
    {
        private T[] arr;
        private int size;
        private int capacity;

        public MyList(int initialCapacity = 8)
        {
            if (initialCapacity < 1) initialCapacity = 1;
            this.capacity = initialCapacity;
            arr = new T[initialCapacity];
        }
        public T this[int index] 
        {
            get 
            {
                ThrowIfIndexOutOfRange(index);
                return arr[index];
            } 
            set
            {
                ThrowIfIndexOutOfRange(index);
                arr[index] = value;
            }
        }

        public int Count => size;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if(size == capacity)
            {
                Resize();
            }

            arr[size] = item;
            size++;
        }

        public void Clear()
        {
            arr = new T[capacity];
            size = 0;
        }

        public bool Contains(T item)
        {
            for(int i = 0; i < size; i++)
            {
                T currentVal = arr[i];
                if (currentVal.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(arr, 0, array, arrayIndex, size);
            //ThrowIfIndexOutOfRange(arrayIndex);
            //int temp = arrayIndex;
            //for(int i = 0; i < size; i++)
            //{
            //    array[temp] = arr[i];
            //    temp++;
            //}
        }
        private IEnumerable<T> GetValues()
        {
            for (int i = 0; i < size; i++)
            {
                yield return arr[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetValues().GetEnumerator();
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < size; i++)
            {
                T currentVal = arr[i];
                if (currentVal.Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            ThrowIfIndexOutOfRange(index);
            if (size == capacity) Resize();

            for(int i = size; i > index; i--)
            {
                arr[i] = arr[i - 1];
            }
            arr[index] = item;
            size++;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < size; i++)
            {
                T currentVal = arr[i];
                if (currentVal.Equals(item))
                {
                    for(int j = i; j < size; j++)
                    {
                        arr[i] = arr[i + 1];
                    }
                    size--;
                    return true;
                }
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            ThrowIfIndexOutOfRange(index);
            arr[index] = default(T);
            size--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void Resize()
        {
            T[] resized = new T[capacity * 2];
            for(int i = 0; i < capacity; i++)
            {
                resized[i] = arr[i];
            }
            arr = resized;
            capacity *= 2;
        }
        private void ThrowIfIndexOutOfRange(int index)
        {
            if (index > size - 1 || index < 0)
            {
                throw new ArgumentOutOfRangeException(string.Format("The current size of the array is {0}", size));
            }
        }
    }
}

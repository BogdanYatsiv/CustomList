using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollections
{
    public class MyList<T> : IList<T>
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

        public int Capacity => capacity;

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
        }
        

        public IEnumerator<T> GetEnumerator()
        {
            return new MyListEnum<T>(this);
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
                        arr[j] = arr[j + 1];
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
            for (int j = index; j < size; j++)
            {
                arr[j] = arr[j + 1];
            }
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

    class MyListEnum<T> : IEnumerator<T>
    {
        private MyList<T> collection;
        private int curIndex;
        private T curItem;
        public MyListEnum(MyList<T> ml)
        {
            collection = ml;
            curIndex = -1;
            curItem = default(T);
        }
        public T Current => curItem;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            if (++curIndex >= collection.Count)
            {
                return false;
            }
            else
            {
                curItem = collection[curIndex];
            }
            return true;
        }

        public void Reset()
        {
            curIndex = -1;
        }
    }
}

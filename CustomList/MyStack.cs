using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollections
{
    class MyStack<T> : IEnumerable<T>
    {
        private T[] data;
        private int size;
        
        public MyStack()
        {
            data = new T[8];
            size = 0;
        }

        public T this[int index]
        {
            get
            {
                ThrowIfIndexOutOfRange(index);
                return data[index];
            }
        }

        public int Count => size;
        public bool IsReadOnly => false;

        public void Push(T item)
        {
            if (size == data.Length) Resize();

            data[size] = item;
            size++;
        }

        public T pop()
        {
            if (size == 0) throw new Exception("Stack is empty!");
            else
            {
                T value = data[size];
                data[size] = default(T);
                size--;

                return value;
            }

        }

        private void Resize()
        {
            T[] resized = new T[data.Length * 2];
            for (int i = 0; i < data.Length; i++)
            {
                resized[i] = data[i];
            }
            data = resized;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyStackEnum<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void ThrowIfIndexOutOfRange(int index)
        {
            if (index > size - 1 || index < 0)
            {
                throw new ArgumentOutOfRangeException(string.Format("The current size of the array is {0}", size));
            }
        }
    }

    class MyStackEnum<T> : IEnumerator<T>
    {
        private MyStack<T> collection;
        private int curIndex;
        private T curItem;
        public MyStackEnum(MyStack<T> ms)
        {
            collection = ms;
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

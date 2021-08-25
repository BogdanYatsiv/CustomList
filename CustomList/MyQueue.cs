using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollections
{
    class MyQueue<T> : IEnumerable<T>
    {
        private T[] data;
        private int size;

        public MyQueue()
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
        public T Dequeue()
        {
            T item = data[size];
            data[size] = default(T);
            size--;
            return item;
        }

        public void Enqueue(T item)
        {
            if (size == data.Length) Resize();

            for(int i = size; i >= 0; i--)
            {
                if (i == 0)
                {
                    data[i] = item;
                    size++;
                }
                data[i] = data[i - 1];
            }
        }

        public void Clear()
        {
            T[] newData = new T[data.Length];
            data = newData;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyQueueEnum<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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
        private void ThrowIfIndexOutOfRange(int index)
        {
            if (index > size - 1 || index < 0)
            {
                throw new ArgumentOutOfRangeException(string.Format("The current size of the array is {0}", size));
            }
        }
    }

    class MyQueueEnum<T> : IEnumerator<T>
    {
        private MyQueue<T> collection;
        private int curIndex;
        private T curItem;
        public MyQueueEnum(MyQueue<T> mq)
        {
            collection = mq;
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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollections
{
    public class ListNode<T>
    {
        internal T value;
        internal ListNode<T> next;

        public T Value => value;

        public ListNode(T v)
        {
            value = v;
            next = null;
        }
    }
    public class MyLinkedList<T> : IList<T>
    {
        internal ListNode<T> head;
        private int size = 0;

        public T this[int index]
        {
            get
            {
                ThrowIfIndexOutOfRange(index);

                if (index == 0) return head.value;
                else
                {
                    int pointer = 0;
                    var pointerNode = head;

                    while (pointer <= index)
                    {
                        if (pointer == index) return pointerNode.value;
                        else
                        {
                            pointerNode = pointerNode.next;
                            pointer++;
                        }
                    }
                }
                return default(T);
            }
            set
            {
                ThrowIfIndexOutOfRange(index);

                if(index == 0)
                {
                    head.value = value;
                    return;
                }
                else
                {
                    int pointer = 0;
                    var pointerNode = head;

                    while (pointer <= index)
                    {
                        if (pointer == index) 
                        {
                            pointerNode.value = value;
                            return;
                        } 
                        else
                        {
                            pointerNode = pointerNode.next;
                            pointer++;
                        }
                    }
                }
            }
        }

        public int Count => size;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            ListNode<T> newNode = new ListNode<T>(item);
            newNode.next = head;
            head = newNode;
            size++;
        }

        public void Clear()
        {
            if (head.next != null)
            {
                head.next = null;
                head.value = default(T);
                size = 0;
            }
        }

        public bool Contains(T item)
        {
            if (head.value.Equals(item)) return true;

            ListNode<T> temp = head.next;

            while (temp != null)
            {
                if (temp.value.Equals(item)) return true;
                temp = temp.next;
            }

            return false;
        }
        public T[] toArr()
        {
            T[] arr = new T[size];
            int index = 0;
            ListNode<T> temp = head;

            while (temp != null)
            {
                arr[index] = temp.value;
                index++;
                temp = temp.next;
            }
            return arr;
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(this.toArr(), 0, array, arrayIndex, size);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyLinkedListEnum<T>(this);
        }

        public int IndexOf(T item)
        {
            if (head.value.Equals(item)) return 0;

            int index = 1;
            ListNode<T> temp = head.next;

            while (temp != null)
            {
                if (temp.value.Equals(item)) return index;
                else
                {
                    index++;
                    temp = temp.next;
                }
            }

            return -1;
        }

        public ListNode<T> GetNode(int index)
        {
            ThrowIfIndexOutOfRange(index);

            if (index == 0) return head;

            int iter = 1;
            ListNode<T> temp = head.next;

            while (iter <= index)
            {
                if (iter == index) return temp;
                else
                {
                    temp = temp.next;
                    iter++;
                }
            }
            //fix lust return
            return head;
        }

        public void Insert(int index, T item)
        {
            ThrowIfIndexOutOfRange(index);

            ListNode<T> newNode = new ListNode<T>(item);

            if (index == 0)
            {
                newNode.next = head;
                head = newNode;
                size++;
            }
            else 
            {
                ListNode<T> temp = head.next;
                ListNode<T> prev = head;
                int iter = 1;

                while (temp != null)
                {
                    if (iter == index )
                    {
                        newNode.next = temp;
                        prev.next = newNode;
                        size++;
                        return;
                    }
                    iter++;
                    prev = temp;
                    temp = temp.next;
                }
            }
        }

        public bool Remove(T item)
        {
            ListNode<T> temp = head.next;
            ListNode<T> prev = head;

            while (temp != null)
            {
                if (temp.value.Equals(item))
                {
                    prev.next = temp.next;
                    size--;
                    return true;
                }
                temp = temp.next;
                prev = prev.next;
            }

            return false;
        }
        public void RemoveAt(int index)
        {
            ThrowIfIndexOutOfRange(index);

            if(index == 0)
            {
                head = head.next;
                size--;
                return;
            }

            ListNode<T> temp = head.next;
            ListNode<T> prev = head;
            int iter = 1;

            while (temp != null)
            {
                if (iter == index)
                {
                    prev.next = temp.next;
                    size--;
                    return;
                }
                temp = temp.next;
                prev = prev.next;
                iter++;
            }
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

    class MyLinkedListEnum<T> : IEnumerator<T>
    {
        private MyLinkedList<T> collection;
        private int curIndex;
        private T curItem;

        public MyLinkedListEnum(MyLinkedList<T> mll)
        {
            collection = mll;
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

using System;
using System.Collections.Generic;

namespace CustomCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> l = new MyList<int>();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            Console.WriteLine("MyList");
            Console.WriteLine(l.Contains(1));
            Console.WriteLine(l.Count + "\n");

            foreach (var v in l)
            {
                Console.WriteLine(v);
            }

            l.Clear();
            Console.WriteLine("\n" + l.Count + "\n");

            MyLinkedList<int> linked = new MyLinkedList<int>();
            linked.Add(1);
            linked.Add(2);
            linked.Add(3);
            Console.WriteLine("MyLinkedList");
            Console.WriteLine(linked.Contains(2));
            Console.WriteLine(linked.Count + "\n");

            foreach(var v in linked)
            {
                Console.WriteLine(v);
            }

            linked.Clear();
            Console.WriteLine("\n" + linked.Count + "\n");

            MyStack<int> stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine("MyStack");
            Console.WriteLine(stack.Count + "\n");

            foreach(var v in stack)
            {
                Console.WriteLine(v);
            }

            Console.WriteLine("\n");
            Console.WriteLine(stack.pop());
            Console.WriteLine(stack.pop());
            Console.WriteLine(stack.pop());
            
            try
            {
                stack.pop();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("\n" + stack.Count + "\n");

            MyQueue<int> q = new MyQueue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            Console.WriteLine("MyQueue");
            Console.WriteLine(q.Count + "\n");

            foreach(var v in q)
            {
                Console.Write(v + " ");
            }
            Console.WriteLine("\n");
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());

            try
            {
                Console.WriteLine(q.Dequeue());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("\n" + q.Count + "\n");
        }
    }
}

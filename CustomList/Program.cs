using System;
using System.Collections.Generic;

namespace CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MyList<int> l = new MyList<int>();

            l.Add(1);
            l.Add(2);
            l.Add(3);

            foreach(var v in l)
            {
                Console.WriteLine(v);
            }
        }
    }
}

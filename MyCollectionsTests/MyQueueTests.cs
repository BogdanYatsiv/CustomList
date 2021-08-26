using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomCollections;
using Xunit;

namespace MyCollectionsTests
{
    public class MyQueueTests
    {
        [Fact]
        public void initTest()
        {
            MyQueue<int> q = new();

            Assert.NotNull(q);
        }

        [Fact]
        public void indexingGetTest()
        {
            MyQueue<int> q = new();

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);

            Assert.Equal(3, q[0]);
            Assert.Equal(2, q[1]);
            Assert.Equal(1, q[2]);
        }

        [Fact]
        public void falseIndexingGetTest()
        {
            MyQueue<int> q = new();

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);

            Assert.Throws<ArgumentOutOfRangeException>(() => q[5]);
            Assert.Throws<ArgumentOutOfRangeException>(() => q[-1]);
        }

        [Fact]
        public void countTest()
        {
            MyQueue<int> q = new();

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);

            Assert.Equal(3, q.Count);
        }

        [Fact]
        public void enqueueTest()
        {
            MyQueue<int> q = new();
            int[] arr = new int[3];
            int[] testArr = { 3, 2, 1 };

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            for(int i = 0; i < 3; i++)
            {
                arr[i] = q[i];
            }

            Assert.Contains(1, q);
            Assert.Contains(2, q);
            Assert.Contains(3, q);
            Assert.Equal(testArr, arr);
        }

        [Fact]
        public void dequeueTest()
        {
            MyQueue<int> q = new();
            int[] arr = new int[3];
            int[] testArr = { 1, 2, 3 };

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            for (int i = 0; i < 3; i++)
            {
                arr[i] = q.Dequeue();
            }

            Assert.Empty(q);
            Assert.Equal(testArr, arr);
        }

        [Fact]
        public void emptyDequeueTest()
        {
            MyQueue<int> q = new();

            Assert.Throws<Exception>(() => q.Dequeue());
        }

        [Fact]
        public void clearTest()
        {
            MyQueue<int> q = new();

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Clear();

            Assert.Empty(q);
        }
    }
}

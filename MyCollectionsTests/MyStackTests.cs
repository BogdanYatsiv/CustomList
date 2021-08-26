using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomCollections;
using Xunit;

namespace MyCollectionsTests
{
    public class MyStackTests
    {
        [Fact]
        public void initTest()
        {
            MyStack<int> s = new();

            Assert.NotNull(s);
        }

        [Fact]
        public void indexingGetTest()
        {
            MyStack<int> s = new();

            s.Push(1);
            s.Push(2);
            s.Push(3);

            Assert.Equal(1, s[0]);
            Assert.Equal(2, s[1]);
            Assert.Equal(3, s[2]);
        }

        [Fact]
        public void falseIndexingGetTest()
        {
            MyStack<int> s = new();

            s.Push(1);
            s.Push(2);
            s.Push(3);

            Assert.Throws<ArgumentOutOfRangeException>(()=>s[5]);
            Assert.Throws<ArgumentOutOfRangeException>(() => s[-1]);
        }

        [Fact]
        public void countTest()
        {
            MyStack<int> s = new();

            s.Push(1);
            s.Push(2);
            s.Push(3);

            Assert.Equal(3, s.Count);
        }

        [Fact]
        public void pushTest()
        {
            MyStack<int> s = new();
            int[] arr = new int[3];
            int[] testArr = { 1, 2, 3 };

            s.Push(1);
            s.Push(2);
            s.Push(3);
            for(int i = 0; i < s.Count; i++)
            {
                arr[i] = s[i];
            }

            Assert.Contains(1, s);
            Assert.Contains(2, s);
            Assert.Contains(3, s);
            Assert.Equal(arr, testArr);
        }

        [Fact]
        public void popTest()
        {
            MyStack<int> s = new();
            int[] arr = new int[3];
            int[] testArr = { 3, 2, 1 };

            s.Push(1);
            s.Push(2);
            s.Push(3);
            for (int i = 0; i < 3; i++)
            {
                arr[i] = s.pop();
            }

            Assert.Empty(s);
            Assert.Equal(testArr, arr);
        }

        [Fact]
        public void falsePopTest()
        {
            MyStack<int> s = new();

            Assert.Throws<Exception>(() => s.pop());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomCollections;
using Xunit;

namespace MyCollectionsTests
{
    public class MyLinkedListTests
    {
        [Fact]
        public void initTest()
        {
            MyLinkedList<int> l = new();

            Assert.Equal(0, l.Count);
        }

        [Fact]
        public void indexingGetTest()
        {
            MyLinkedList<int> l = new();

            l.Add(1);
            l.Add(2);
            l.Add(3);

            Assert.Equal(3, l[0]);
            Assert.Equal(2, l[1]);
            Assert.Equal(1, l[2]);
        }

        [Fact]
        public void falseIndexingGetTest()
        {
            MyLinkedList<int> l = new();

            l.Add(1);
            l.Add(2);
            l.Add(3);

            Assert.Throws<ArgumentOutOfRangeException>(() => l[-1]);
            Assert.Throws<ArgumentOutOfRangeException>(() => l[5]);
        }

        [Fact]
        public void indexingSetTest()
        {
            MyLinkedList<int> l = new();

            l.Add(1);
            l.Add(2);
            l.Add(3);
            l[0] = 4;
            l[1] = 5;
            l[2] = 6;

            Assert.Contains(4, l);
            Assert.Contains(5, l);
            Assert.Contains(6, l);
        }

        [Fact]
        public void falseIndexingSetTest()
        {
            MyLinkedList<int> l = new();

            l.Add(1);
            l.Add(2);
            l.Add(3);

            Assert.Throws<ArgumentOutOfRangeException>(() => l[-1] = 0);
            Assert.Throws<ArgumentOutOfRangeException>(() => l[5] = 0);
        }

        [Fact]
        public void addTest()
        {
            MyLinkedList<int> l = new();

            l.Add(1);
            l.Add(2);
            l.Add(3);

            Assert.Contains(1, l);
            Assert.Contains(2, l);
            Assert.Contains(3, l);
        }

        [Fact]
        public void sizeTest()
        {
            MyLinkedList<int> l = new();

            l.Add(1);
            l.Add(2);
            l.Add(3);

            Assert.Equal(3, l.Count);
        }

        [Fact]
        public void clearTest()
        {
            MyLinkedList<int> l = new();

            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Clear();

            Assert.DoesNotContain(1, l);
            Assert.DoesNotContain(2, l);
            Assert.DoesNotContain(3, l);
        }

        [Fact]
        public void containsTest()
        {
            MyLinkedList<int> l = new();

            l.Add(1);
            l.Add(2);
            l.Add(3);

            Assert.True(l.Contains(1));
            Assert.True(l.Contains(2));
            Assert.True(l.Contains(3));
        }

        [Fact]
        public void notContainsTest()
        {
            MyLinkedList<int> l = new();

            l.Add(1);
            l.Add(2);
            l.Add(3);

            Assert.False(l.Contains(4));
        }

        [Fact]
        public void toArrTest()
        {
            MyLinkedList<int> l = new();
            int[] arr = { 3, 2, 1 };
            int[] testArr = new int[3];

            l.Add(1);
            l.Add(2);
            l.Add(3);
            testArr = l.toArr();

            Assert.Equal(arr, testArr);
        }

        [Fact]
        public void copyToTest()
        {
            MyLinkedList<int> l = new();
            int[] arr = { 3, 2, 1 };
            int[] testArr = new int[3];

            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.CopyTo(testArr, 0);

            Assert.Equal(arr, testArr);
        }

        [Fact]
        public void indexOfTest()
        {
            MyLinkedList<int> l = new();

            l.Add(1);
            l.Add(2);
            l.Add(3);

            Assert.Equal(0, l.IndexOf(3));
            Assert.Equal(1, l.IndexOf(2));
            Assert.Equal(2, l.IndexOf(1));
        }

        [Fact]
        public void falseIndexOfTest()
        {
            MyLinkedList<int> l = new();

            l.Add(1);
            l.Add(2);
            l.Add(3);

            Assert.Equal(-1, l.IndexOf(4));
        }

        [Fact]
        public void getNodeTest()
        {
            MyLinkedList<int> l = new();

            l.Add(1);
            l.Add(2);
            l.Add(3);
            var node = l.GetNode(0);
            var secondNode = l.GetNode(1);

            Assert.Contains(node.Value, l);
            Assert.Contains(secondNode.Value, l);
        }

        [Fact]
        public void falseGetNodeTest()
        {
            MyLinkedList<int> l = new();

            l.Add(1);
            l.Add(2);
            l.Add(3);

            Assert.Throws<ArgumentOutOfRangeException>(() => l.GetNode(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => l.GetNode(5));
        }

        [Fact]
        public void insertHeadTest()
        {
            MyLinkedList<int> l = new();
            int[] arr = { 4, 3, 2, 1 };
            int[] testArr = new int[4];

            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Insert(0, 4);
            testArr = l.toArr();

            Assert.Contains(4, l);
            Assert.Equal(arr, testArr);
        }

        [Fact]
        public void insertLustTest()
        {
            MyLinkedList<int> l = new();
            int[] arr = { 3, 2, 4, 1 };
            int[] testArr = new int[4];

            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Insert(2, 4);
            testArr = l.toArr();

            Assert.Contains(4, l);
            Assert.Equal(arr, testArr);
        }

        [Fact]
        public void insertTest()
        {
            MyLinkedList<int> l = new();
            int[] arr = { 3, 4, 2, 1 };
            int[] testArr = new int[4];

            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Insert(1, 4);
            testArr = l.toArr();

            Assert.Contains(4, l);
            Assert.Equal(arr, testArr);
        }

        [Fact]
        public void falseInsertTest()
        {
            MyLinkedList<int> l = new();

            l.Add(1);
            l.Add(2);
            l.Add(3);

            Assert.Throws<ArgumentOutOfRangeException>(() => l.Insert(-1, 4));
            Assert.Throws<ArgumentOutOfRangeException>(() => l.Insert(5, 4));
        }

        [Fact]
        public void removeTest()
        {
            MyLinkedList<int> l = new();

            l.Add(1);
            l.Add(2);
            l.Add(3);
            bool removed = l.Remove(2);

            Assert.DoesNotContain(2, l);
            Assert.True(removed);
        }

        [Fact]
        public void falseRemoveTest()
        {
            MyLinkedList<int> l = new();

            l.Add(1);
            l.Add(2);
            l.Add(3);
            bool removed = l.Remove(4);

            Assert.DoesNotContain(4, l);
            Assert.False(removed);
        }

        [Fact]
        public void headRemoveAtTest()
        {
            MyLinkedList<int> l = new();

            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.RemoveAt(0);

            Assert.DoesNotContain(3, l);
        }

        [Fact]
        public void lustRemoveAtTest()
        {
            MyLinkedList<int> l = new();

            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.RemoveAt(2);

            Assert.DoesNotContain(1, l);
        }

        [Fact]
        public void RemoveAtTest()
        {
            MyLinkedList<int> l = new();

            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.RemoveAt(1);

            Assert.DoesNotContain(2, l);
        }
    }
}

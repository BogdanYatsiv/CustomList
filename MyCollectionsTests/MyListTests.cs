using CustomCollections;
using System;
using Xunit;

namespace MyCollectionsTests
{
    public class MyListTests
    {
        [Fact]
        public void initiationTest()
        {
            MyList<int> l = new MyList<int>();

            Assert.Equal(8, l.Capacity);
        }

        [Fact]
        public void resizeTest()
        {
            MyList<int> l = new MyList<int>();

            for(int i = 0; i < 10; i++)
            {
                l.Add(i);
            }

            Assert.Equal(16, l.Capacity);
        }

        [Fact]
        public void addTest()
        {
            MyList<int> l = new MyList<int>();

            for (int i = 0; i < 10; i++)
            {
                l.Add(i);
            }

            Assert.Contains(0, l);
            Assert.Contains(1, l);
            Assert.Contains(2, l);
            Assert.Contains(3, l);
            Assert.Contains(9, l);
        }

        [Fact]
        public void setByIndexTest()
        {
            MyList<int> l = new MyList<int>();

            for (int i = 0; i < 5; i++)
            {
                l.Add(i);
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => l[10] = 11);
        }

        [Fact]
        public void getByIndexTest()
        {
            MyList<int> l = new MyList<int>();

            for (int i = 0; i < 5; i++)
            {
                l.Add(i);
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => l[10]);
        }

        [Fact]
        public void indexingTest()
        {
            MyList<int> l = new MyList<int>();

            for (int i = 0; i < 10; i++)
            {
                l.Add(i);
            }

            Assert.Equal(5, l[5]);
        }

        [Fact]
        public void sizeTest()
        {
            MyList<int> l = new MyList<int>();

            for (int i = 0; i < 5; i++)
            {
                l.Add(i);
            }

            Assert.Equal(5, l.Count);
        }

        [Fact]
        public void clearTest()
        {
            MyList<int> l = new MyList<int>();

            for (int i = 0; i < 5; i++)
            {
                l.Add(i);
            }

            l.Clear();

            Assert.Empty(l);
        }

        [Fact]
        public void containsTest()
        {
            MyList<int> l = new MyList<int>();

            for (int i = 0; i < 5; i++)
            {
                l.Add(i);
            }

            Assert.True(l.Contains(2));
        }

        [Fact]
        public void notContainsTest()
        {
            MyList<int> l = new MyList<int>();

            for (int i = 0; i < 5; i++)
            {
                l.Add(i);
            }

            Assert.False(l.Contains(6));
        }

        [Fact]
        public void copyToTest()
        {
            MyList<int> l = new MyList<int>();
            int[] arr = { 0, 1, 2, 3, 4 };
            int[] testArr = new int[5];

            for (int i = 0; i < 5; i++)
            {
                l.Add(i);
            }
            l.CopyTo(testArr, 0);

            Assert.Equal(arr, testArr);
        }

        [Fact]
        public void indexOfTest()
        {
            MyList<int> l = new MyList<int>();
            int index;
            int gotIndex;

            for (int i = 0; i < 5; i++)
            {
                l.Add(i);
            }
            index = l[3];
            gotIndex = l.IndexOf(3);

            Assert.Equal(index,gotIndex);
        }

        [Fact]
        public void indexOfNotExistingTest()
        {
            MyList<int> l = new MyList<int>();
            int gotIndex;

            for (int i = 0; i < 5; i++)
            {
                l.Add(i);
            }
            
            gotIndex = l.IndexOf(6);

            Assert.Equal(-1, gotIndex);
        }

        [Fact]
        public void insertTest()
        {
            MyList<int> l = new MyList<int>();
            int[] arr = { 0, 1, 6, 2, 3, 4 };
            int[] testArr = new int[6];

            for (int i = 0; i < 5; i++)
            {
                l.Add(i);
            }
            l.Insert(2, 6);
            l.CopyTo(testArr, 0);


            Assert.Equal(arr, testArr);
        }

        [Fact]
        public void removeTest()
        {
            MyList<int> l = new MyList<int>();
            int[] arr = { 1, 2, 3, 4 };
            int[] testArr = new int[4];

            for (int i = 0; i < 5; i++)
            {
                l.Add(i);
            }
            bool removed = l.Remove(0);
            l.CopyTo(testArr, 0);


            Assert.Equal(arr, testArr);
            Assert.True(removed);
        }

        [Fact]
        public void notRemoveTest()
        {
            MyList<int> l = new MyList<int>();
            int[] arr = { 0, 1, 2, 3, 4 };
            int[] testArr = new int[5];

            for (int i = 0; i < 5; i++)
            {
                l.Add(i);
            }
            bool removed = l.Remove(6);
            l.CopyTo(testArr, 0);

            Assert.Equal(arr, testArr);
            Assert.False(removed);
        }

        [Fact]
        public void removeAtTest()
        {
            MyList<int> l = new MyList<int>();
            int[] arr = { 0, 1, 3, 4 };
            int[] testArr = new int[4];

            for (int i = 0; i < 5; i++)
            {
                l.Add(i);
            }
            l.RemoveAt(2);
            l.CopyTo(testArr, 0);

            Assert.Equal(arr, testArr);
        }

        [Fact]
        public void notRemoveAtTest()
        {
            MyList<int> l = new MyList<int>();

            for (int i = 0; i < 5; i++)
            {
                l.Add(i);
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => l.RemoveAt(-1));
        }
    }
}

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
    }
}

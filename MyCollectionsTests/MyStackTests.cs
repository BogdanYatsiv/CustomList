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

            Assert.Equal(0, s.Count);
        }
    }
}

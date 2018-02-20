using System;
using Xunit;

namespace WebServer.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True(5 * 5 == 25);
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(25, 25);
        }
    }
}

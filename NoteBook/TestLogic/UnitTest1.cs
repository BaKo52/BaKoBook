using System;
using Xunit;
using Logic;

namespace TestLogic
{
    public class UnitTest1
    {
        [Fact]
        public void TestPedagogicalElement()
        {
            PedagogicalElement pe = new PedagogicalElement();

            Assert.Throws<Exception>(() =>
            {
                pe.Coef = -1;
            });
        }
    }
}

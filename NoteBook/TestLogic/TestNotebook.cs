using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Logic;

namespace TestLogic
{
    public class TestNotebook
    {
        [Fact]
        public void TestListUnits()
        {
            Notebook nb = new Notebook();
            Unit[] u = nb.ListUnits();
            Console.WriteLine(u);
            Assert.NotNull(u);
            Assert.Empty(u);
        }
    }
}

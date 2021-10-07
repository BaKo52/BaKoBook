using System;
using Xunit;
using Logic;

namespace TestLogic
{
    public class UnitTest1
    {
        /// <summary>
        /// Teste la classe PedagogicalElement
        /// </summary>
        [Fact]
        public void TestPedagogicalElement()
        {
            PedagogicalElement pe = new PedagogicalElement();

            Assert.Throws<Exception>(() =>
            {
                pe.Coef = -1;
            });
        }

        /// <summary>
        /// Teste la fonction qui liste les modules
        /// </summary>
        [Fact]
        public void TestListModules()
        {
            Unit u = new Unit();

            u.Name = "test";
            u.Coef = 2;

            Assert.Empty(u.ListModules());
        }
    }
}

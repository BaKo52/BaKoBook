using System;
using Xunit;
using Logic;

namespace TestLogic
{
    public class TestUnit
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
            Assert.NotNull(u.ListModules());
        }

        /// <summary>
        /// Teste la fonction qui ajoute les modules
        /// </summary>
        [Fact]
        public void TestAddModules()
        {
            Unit u = new Unit();
            Module m = new Module();

            u.AddModules(m);

            Module[] mArray = {m};

            Assert.Equal(mArray, u.ListModules());
        }

        /// <summary>
        /// Teste la fonction qui enlève un module
        /// </summary>
        [Fact]
        public void TestRemoveModules()
        {
            Unit u = new Unit();
            Module m1 = new Module();
            Module m2 = new Module();

            //on reteste l'ajout
            u.AddModules(m1);
            u.AddModules(m2);
            Module[] mArray = { m1, m2 };
            Assert.Equal(mArray, u.ListModules());

            //on teste le remove
            u.RemoveModule(m2);
            Module[] mArray1 = { m1 };
            Assert.Equal(mArray1, u.ListModules());
            u.RemoveModule(m1);
            Assert.Empty(u.ListModules());
        }
    }
}

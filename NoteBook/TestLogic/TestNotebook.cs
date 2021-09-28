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
            Assert.NotNull(u);
            Assert.Empty(u);
        }

        /// <summary>
        /// Méthode testant si l'unit est bien ajouté et testant la fonction indiquant si l'unit à déja été rentré
        /// </summary>
        [Fact]
        public void TestAddUnit()
        {
            Notebook nb = new Notebook();
            Unit u = new Unit();

            u.Name = "Test";
            u.Coef = 3;

            nb.AddUnit(u);
            Unit[] unit = nb.ListUnits();

            Assert.Single(unit);
            Assert.Equal(unit[0], u);

            try
            {
                nb.AddUnit(u);
            }
            catch (Exception e)
            {
                Assert.Equal("Cette unité est déjà dans votre agenda !", e.Message);
            }
        }
    }
}

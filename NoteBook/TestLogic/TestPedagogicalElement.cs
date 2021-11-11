using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Logic;

namespace TestLogic
{
    /// <summary>
    /// Classe testant la classe PedagogicalElement
    /// </summary>
    public class TestPedagogicalElement
    {
        /// <summary>
        /// Fonction testant la méthode Equals(Object obj) de PedagogicalElement
        /// </summary>
        [Fact]
        public void TestEqual()
        {
            //on créé le premier PedagogicalElement
            PedagogicalElement pe1 = new PedagogicalElement();
            pe1.Coef = 3;
            pe1.Name = "test";

            //on créé le second
            PedagogicalElement pe2 = new PedagogicalElement();
            pe2.Coef = 3;
            pe2.Name = "test";

            //normalement pe1 et pe2 sont égaux
            Assert.True(pe1.Equals(pe2));

            //changeons un argument afin de les différencier
            pe2.Name = "différent";

            //on devrait avoir false
            Assert.False(pe1.Equals(pe2));
        }

        /// <summary>
        /// Fonction testant les contraintes de la classe PedagogicalElement
        /// </summary>
        [Fact]
        public void TestContrainte()
        {
            //on créé un PedagogicalElement
            PedagogicalElement pe = new PedagogicalElement();

            //il n'existe une contrainte que sur le coefficient
            Assert.Throws<Exception>(() => { pe.Coef = -1; });
        }

        /// <summary>
        /// Fonction testant la fonction ToString() de la classe PedagogicalElement
        /// </summary>
        [Fact]
        public void TestToString()
        {
            //on créé un PedagogicalElement avec des données
            PedagogicalElement pe = new PedagogicalElement();
            pe.Coef = 3;
            pe.Name = "test";

            //on vérifie que le résultat est celui qui est attendu
            Assert.Equal("test(3)", pe.ToString());
        }
    }
}

using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestLogic
{
    /// <summary>
    /// Classe testant la classe AvgScore
    /// </summary>
    public class TestAvgScore
    {
        /// <summary>
        /// Classe testant le constructeur de la classe AvgScore
        /// </summary>
        [Fact]
        public void TestConstructeur()
        {
            float f = 10;
            PedagogicalElement pe = new PedagogicalElement();
            AvgScore avgs = new AvgScore(f, pe);

            Assert.Throws<ArgumentNullException>(() => { avgs = new AvgScore(f, null); });

            Assert.Equal(f, avgs.Average);
        }

        /// <summary>
        /// méthode test les contraintes sur la variable average
        /// </summary>
        [Fact]
        public void TestAverageContrainte()
        {
            float f = 10;
            PedagogicalElement pe = new PedagogicalElement();
            AvgScore avgs = new AvgScore(f, pe);

            f = -1;
            Assert.Throws<ArgumentException>(() => { avgs.Average = f; });

            f = 21;
            Assert.Throws<ArgumentException>(() => { avgs.Average = f; });

            f = 10;
            avgs.Average = f;
        }

        

        /// <summary>
        /// Méthode testant la fonction ToString de la classe AvgScore
        /// </summary>
        [Fact]
        public void TestToString()
        {
            float f = 10;
            Module m = new Module();
            m.Name = "Test";
            m.Coef = 4;
            AvgScore avgs = new AvgScore(f, m);

            Assert.Equal(m.ToString() + ": " + avgs.Average, avgs.ToString());
        }
    }
}

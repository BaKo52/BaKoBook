using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Logic;

namespace TestLogic
{
    /// <summary>
    /// Classe testant la classe Module
    /// </summary>
    public class TestModule
    {
        /// <summary>
        /// Fonction test la fonction ComputeAverage
        /// </summary>
        [Fact]
        public void TestComputeAverage()
        {
            Notebook n = new Notebook();
            Module m = new Module();

            Assert.Null(m.ComputeAverage(n.ListExam()));

            Exam e1 = new Exam();
            e1.Coef = 2;
            e1.Note = 20;
            e1.Module = m;

            n.AddExam(e1);

            Exam e2 = new Exam();
            e2.Coef = 4.2f;
            e2.Note = 10;
            e2.Module = m;

            n.AddExam(e2);

            //après calcul on devrait avoir 13,23 comme résultat
            AvgScore expect = new AvgScore(13.23f, m);
            AvgScore actual = m.ComputeAverage(n.ListExam());

            Assert.Equal(expect.Average, actual.Average);
            Assert.Equal(expect.PedagoElement, actual.PedagoElement);

        }
    }
}

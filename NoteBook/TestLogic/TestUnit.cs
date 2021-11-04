using System;
using Xunit;
using Logic;
using System.Collections.Generic;

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

        [Fact]
        public void TestComputeAverages()
        {
            //On crée une Unit et deux modules
            Notebook n = new Notebook();
            Unit u = new Unit();
            Module m1 = new Module();
            m1.Coef = 2;
            Module m2 = new Module();
            m2.Coef = 3;

            //on crée deux exams pour le m1 et deux pour m2
            Exam e1 = new Exam();
            e1.Coef = 1;
            e1.Note = 20;
            e1.Module = m1;
            Exam e2 = new Exam();
            e2.Coef = 4;
            e2.Note = 3;
            e2.Module = m1;
            Exam e3 = new Exam();
            e3.Coef = 2;
            e3.Note = 20;
            e3.Module = m2;
            Exam e4 = new Exam();
            e4.Coef = 1;
            e4.Note = 13;
            e4.Module = m2;

            //on ajoute les examens au notebook
            n.AddExam(e1);
            n.AddExam(e2);
            n.AddExam(e3);
            n.AddExam(e4);

            //On ajoute les modules à l'unité
            u.AddModules(m1);
            u.AddModules(m2);

            //On ajoute l'unité au notebook
            n.AddUnit(u);

            //On crée le résultat attendu en calculant les valeurs
            List<AvgScore> listAvgs = new List<AvgScore>();

            //moyenne de m1 = 6,4
            listAvgs.Add(new AvgScore(6.4f, m1));
            //moyenne de m2 = 17,67
            listAvgs.Add(new AvgScore(17.67f, m2));

            AvgScore[] listAvgsExpected = listAvgs.ToArray();
            AvgScore[] listAvgsActual = u.ComputeAverages(n.ListExam());

            for (int i = 0; i < listAvgs.Count; i++)
            {
                Assert.Equal(listAvgsExpected[i].Average, listAvgsActual[i].Average);
                Assert.Equal(listAvgsExpected[i].PedagoElement, listAvgsActual[i].PedagoElement);
            }
        }
    }
}

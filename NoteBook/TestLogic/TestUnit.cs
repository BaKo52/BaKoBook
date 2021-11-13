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

            //on vérifie que sans examen ComputeAverages est vide
            Assert.Empty(u.ComputeAverages(n.ListExam()));

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

        /// <summary>
        /// Fonction testant la fonction Equals de la classe Unit
        /// </summary>
        [Fact]
        public void TestEquals()
        {
            #region création des variables
            //On crée deux Unit identiques et deux modules par Unit
            Unit u1 = new Unit();
            Module m11 = new Module();
            m11.Coef = 2;
            Module m12 = new Module();
            m12.Coef = 3;

            Unit u2 = new Unit();
            Module m21 = new Module();
            m21.Coef = 2;
            Module m22 = new Module();
            m22.Coef = 3;

            //on crée deux exams pour le mx1 et deux pour mx2 et cela pour chaque unit
            Exam e11 = new Exam();
            e11.Coef = 1;
            e11.Note = 20;
            e11.Module = m11;
            Exam e12 = new Exam();
            e12.Coef = 4;
            e12.Note = 3;
            e12.Module = m11;
            Exam e13 = new Exam();
            e13.Coef = 2;
            e13.Note = 20;
            e13.Module = m12;
            Exam e14 = new Exam();
            e14.Coef = 1;
            e14.Note = 13;
            e14.Module = m12;

            Exam e21 = new Exam();
            e21.Coef = 1;
            e21.Note = 20;
            e21.Module = m21;
            Exam e22 = new Exam();
            e22.Coef = 4;
            e22.Note = 3;
            e22.Module = m21;
            Exam e23 = new Exam();
            e23.Coef = 2;
            e23.Note = 20;
            e23.Module = m22;
            Exam e24 = new Exam();
            e24.Coef = 1;
            e24.Note = 13;
            e24.Module = m22;

            //On ajoute les modules aux unitées
            u1.AddModules(m11);
            u1.AddModules(m12);

            u2.AddModules(m21);
            u2.AddModules(m22);
            #endregion

            //devrait retourner vrai
            Assert.True(u1.Equals(u2));

            //modifions maintenant l'une des deux unit afin de les différencier pour cela créons un nouveau module et ajoutons le à l'Unit numéro 1 (u1)
            Module intrus = new Module();
            intrus.Coef = 2;
            intrus.Name = "Intrus";
            u1.AddModules(intrus);

            Assert.False(u1.Equals(u2));
        }
    }
}

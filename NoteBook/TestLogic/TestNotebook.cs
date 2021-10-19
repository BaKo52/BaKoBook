using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Logic;

namespace TestLogic
{
    public class TestNotebook
    {
        /// <summary>
        /// Teste la fonction qui liste les unités
        /// </summary>
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

        /// <summary>
        /// Teste la fonction qui enlève une unité
        /// </summary>
        [Fact]
        public void TestRemoveUnit()
        {
            Notebook nb = new Notebook();
            Unit u = new Unit();

            u.Name = "Test";
            u.Coef = 3;

            nb.AddUnit(u);
            Unit[] unit = nb.ListUnits();
            Assert.Single(unit);
            Assert.Equal(unit[0], u);

            nb.RemoveUnit(u);

            Assert.Empty(nb.ListUnits());
        }
    
        /// <summary>
        /// Teste si l'ajout d'un examen se fait correctement
        /// </summary>
        [Fact]
        public void TestAddExam()
        {
            Notebook nb = new Notebook();
            Exam e = new Exam();

            nb.AddExam(e);

            Assert.Single(nb.ListExam(), e);
        }

        /// <summary>
        /// Teste si la liste des modules se créé correctement
        /// </summary>
        [Fact]
        public void TestListModules()
        {
            //on créé un notebook
            Notebook nb = new Notebook();

            //on créé 4 unit
            Unit u1 = new Unit();
            u1.Name = "1";
            Unit u2 = new Unit();
            u2.Name = "2";
            Unit u3 = new Unit();
            u3.Name = "3";
            Unit u4 = new Unit();
            u4.Name = "4";

            //on créé 8 modules (2 par units);
            Module u1m1 = new Module();
            Module u1m2 = new Module();
            Module u2m1 = new Module();
            Module u2m2 = new Module();
            Module u3m1 = new Module();
            Module u3m2 = new Module();
            Module u4m1 = new Module();
            Module u4m2 = new Module();

            //on ajoute les modules aux units
            u1.AddModules(u1m1);
            u1.AddModules(u1m2);
            u2.AddModules(u2m1);
            u2.AddModules(u2m2);
            u3.AddModules(u3m1);
            u3.AddModules(u3m2);
            u4.AddModules(u4m1);
            u4.AddModules(u4m2);

            //on ajoute les units au notebook
            nb.AddUnit(u1);
            nb.AddUnit(u2);
            nb.AddUnit(u3);
            nb.AddUnit(u4);

            //on créé le résultat attendu
            Module[] m = { u1m1, u1m2, u2m1, u2m2, u3m1, u3m2, u4m1, u4m2 };

            //on compare l'attendu avec le réel
            Assert.Equal(m, nb.ListModules());
        }

        /// <summary>
        /// Teste si la liste des exams se créé correctement
        /// </summary>
        [Fact]
        public void TestListExam()
        {
            //on créé un notebook
            Notebook nb = new Notebook();

            //on créé 8 exams
            Exam e1 = new Exam();
            Exam e2 = new Exam();
            Exam e3 = new Exam();
            Exam e4 = new Exam();
            Exam e5 = new Exam();
            Exam e6 = new Exam();
            Exam e7 = new Exam();
            Exam e8 = new Exam();

            //on ajoute les Exams aux units
            nb.AddExam(e1);
            nb.AddExam(e2);
            nb.AddExam(e3);
            nb.AddExam(e4);
            nb.AddExam(e5);
            nb.AddExam(e6);
            nb.AddExam(e7);
            nb.AddExam(e8);

            //on créé le résultat attendu
            Exam[] e = { e1, e2, e3, e4, e5, e6, e7, e8 };

            //on compare l'attendu avec le réel
            Assert.Equal(e, nb.ListExam());
        }
    }
}

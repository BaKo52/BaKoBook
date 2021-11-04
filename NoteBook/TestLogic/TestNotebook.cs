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

        /// <summary>
        /// Fonction testant la fonction ComputeScores
        /// </summary>
        [Fact]
        public void TestComputeScores()
        {
            //On crée deux Unit et deux modules par Unit
            Notebook n = new Notebook();
            
            Unit u1 = new Unit();
            u1.Name = "Unité 1";
            u1.Coef = 11;

            Unit u2 = new Unit();
            u2.Name = "Unité 2";
            u2.Coef = 22;

            Module m1 = new Module();
            m1.Coef = 1;
            m1.Name = "Module 1";

            Module m2 = new Module();
            m2.Coef = 2;
            m2.Name = "Module 2";

            Module m3 = new Module();
            m3.Coef = 3;
            m3.Name = "Module 3";

            Module m4 = new Module();
            m4.Coef = 4;
            m4.Name = "Module 4";

            //création du PedagogicalElement représentant la moyenne générale
            PedagogicalElement mg = new PedagogicalElement();
            mg.Name = "Moyenne générale";
            mg.Coef = 1;

            //on crée deux exams par module
            //remplis avec des valeurs légales et aléatoires
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
            Exam e5 = new Exam();
            e5.Coef = 43;
            e5.Note = 16;
            e5.Module = m3;
            Exam e6 = new Exam();
            e6.Coef = 0.5f;
            e6.Note = 18;
            e6.Module = m3;
            Exam e7 = new Exam();
            e7.Coef = 6;
            e7.Note = 3;
            e7.Module = m4;
            Exam e8 = new Exam();
            e8.Coef = 4;
            e8.Note = 1;
            e8.Module = m4;

            //on ajoute les examens au notebook
            n.AddExam(e1);
            n.AddExam(e2);
            n.AddExam(e3);
            n.AddExam(e4);
            n.AddExam(e5);
            n.AddExam(e6);
            n.AddExam(e7);
            n.AddExam(e8);

            //On ajoute les modules à l'unité
            u1.AddModules(m1);
            u1.AddModules(m2);
            u2.AddModules(m3);
            u2.AddModules(m4);

            //On ajoute les unitées au notebook
            n.AddUnit(u1);
            n.AddUnit(u2);

            //On crée le résultat attendu en calculant les valeurs
            List<AvgScore> listAvgs = new List<AvgScore>();

            //moyenne de u1 = 13,91
            listAvgs.Add(new AvgScore(13.91f, u1));
            //moyenne de u2 = 8,12
            listAvgs.Add(new AvgScore(8.12f, u2));
            //moyenne générale = 10,05
            listAvgs.Add(new AvgScore(10.05f, mg));

            AvgScore[] listAvgsExpected = listAvgs.ToArray();
            AvgScore[] listAvgsActual = n.ComputeScores();

            //on teste la moyenne et l'élémeent pédagogique lié pour chaque objet
            for (int i = 0; i < listAvgs.Count - 1; i++)
            {
                Assert.Equal(listAvgsExpected[i].Average, listAvgsActual[i].Average);

                //ici on compare les ToString des éléments pédagogiques sinon le test ne marche pas pour la moyenne générale
                //du fait que, de base, il n'existe pas de PedagogicalElement auquel on peut associer la moyenne générale
                //on doit donc le créer dans notre fonction ComputeScores
                //or on doit donc en créer un dans notre test pour le résultat attendu
                //celui-ci sera différent d'un point de vue mémoire mais identique d'un point de vue logique
                Assert.Equal(listAvgsExpected[i].PedagoElement.ToString(), listAvgsActual[i].PedagoElement.ToString());
            }
        }
    }
}

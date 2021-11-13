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
            Notebook note = new Notebook();

            //on vérifie que sans examen ComputeScores est vide
            Assert.Empty(note.ComputeScores());

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
            note.AddExam(e1);
            note.AddExam(e2);
            note.AddExam(e3);
            note.AddExam(e4);
            note.AddExam(e5);
            note.AddExam(e6);
            note.AddExam(e7);
            note.AddExam(e8);

            //On ajoute les modules à l'unité
            u1.AddModules(m1);
            u1.AddModules(m2);
            u2.AddModules(m3);
            u2.AddModules(m4);

            //On ajoute les unitées au notebook
            note.AddUnit(u1);
            note.AddUnit(u2);

            //On crée le résultat attendu en calculant les valeurs
            List<AvgScore> listAvgs = new List<AvgScore>();

            //moyenne de u1 = 13,91
            listAvgs.Add(new AvgScore(13.91f, u1));
            //moyenne de u2 = 8,12
            listAvgs.Add(new AvgScore(8.12f, u2));
            //moyenne générale = 10,05
            listAvgs.Add(new AvgScore(10.05f, mg));

            AvgScore[] listAvgsExpected = listAvgs.ToArray();
            AvgScore[] listAvgsActual = note.ComputeScores();

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

        /// <summary>
        /// Fonction testant la fonctio Equals
        /// </summary>
        [Fact]
        public void TestEquals()
        {
            #region création des variables pour le premier Notebook
            //On crée deux Unit et deux modules par Unit
            Notebook n1 = new Notebook();

            Unit u11 = new Unit();
            u11.Name = "Unité 1";
            u11.Coef = 11;

            Unit u12 = new Unit();
            u12.Name = "Unité 2";
            u12.Coef = 22;

            Module m11 = new Module();
            m11.Coef = 1;
            m11.Name = "Module 1";

            Module m12 = new Module();
            m12.Coef = 2;
            m12.Name = "Module 2";

            Module m13 = new Module();
            m13.Coef = 3;
            m13.Name = "Module 3";

            Module m14 = new Module();
            m14.Coef = 4;
            m14.Name = "Module 4";

            //on crée deux exams par module
            //remplis avec des valeurs légales et aléatoires
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
            Exam e15 = new Exam();
            e15.Coef = 43;
            e15.Note = 16;
            e15.Module = m13;
            Exam e16 = new Exam();
            e16.Coef = 0.5f;
            e16.Note = 18;
            e16.Module = m13;
            Exam e17 = new Exam();
            e17.Coef = 6;
            e17.Note = 3;
            e17.Module = m14;
            Exam e18 = new Exam();
            e18.Coef = 4;
            e18.Note = 1;
            e18.Module = m14;

            //on ajoute les examens au notebook
            n1.AddExam(e11);
            n1.AddExam(e12);
            n1.AddExam(e13);
            n1.AddExam(e14);
            n1.AddExam(e15);
            n1.AddExam(e16);
            n1.AddExam(e17);
            n1.AddExam(e18);

            //On ajoute les modules aux unités
            u11.AddModules(m11);
            u11.AddModules(m12);
            u12.AddModules(m13);
            u12.AddModules(m14);

            //On ajoute les unités au notebook
            n1.AddUnit(u11);
            n1.AddUnit(u12);
            #endregion

            #region création des variables pour le second Notebook
            //On crée deux Unit et deux modules par Unit
            Notebook n2 = new Notebook();

            Unit u21 = new Unit();
            u21.Name = "Unité 1";
            u21.Coef = 11;

            Unit u22 = new Unit();
            u22.Name = "Unité 2";
            u22.Coef = 22;

            Module m21 = new Module();
            m21.Coef = 1;
            m21.Name = "Module 1";

            Module m22 = new Module();
            m22.Coef = 2;
            m22.Name = "Module 2";

            Module m23 = new Module();
            m23.Coef = 3;
            m23.Name = "Module 3";

            Module m24 = new Module();
            m24.Coef = 4;
            m24.Name = "Module 4";

            //on crée deux exams par module
            //remplis avec des valeurs légales et aléatoires
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
            Exam e25 = new Exam();
            e25.Coef = 43;
            e25.Note = 16;
            e25.Module = m23;
            Exam e26 = new Exam();
            e26.Coef = 0.5f;
            e26.Note = 18;
            e26.Module = m23;
            Exam e27 = new Exam();
            e27.Coef = 6;
            e27.Note = 3;
            e27.Module = m24;
            Exam e28 = new Exam();
            e28.Coef = 4;
            e28.Note = 1;
            e28.Module = m24;

            //on ajoute les examens au notebook
            n2.AddExam(e21);
            n2.AddExam(e22);
            n2.AddExam(e23);
            n2.AddExam(e24);
            n2.AddExam(e25);
            n2.AddExam(e26);
            n2.AddExam(e27);
            n2.AddExam(e28);

            //On ajoute les modules à l'unité
            u21.AddModules(m21);
            u21.AddModules(m22);
            u22.AddModules(m23);
            u22.AddModules(m24);

            //On ajoute les unitées au notebook
            n2.AddUnit(u21);
            n2.AddUnit(u22);
            #endregion

            //retournes vrai car les deux Notebook sont identiques
            Assert.True(n1.Equals(n2));

            //on modifie un notebook pour les différencier (ici on va tester en ajoutant une unité et ensuite un examen)
            Unit u = new Unit();
            n1.AddUnit(u);

            //retourne faux car les deux notebook sont différents
            Assert.False(n1.Equals(n2));

            //on enlève l'unité
            n1.RemoveUnit(u);

            //on reteste que les deux notebook soit bien toujours identique
            Assert.True(n1.Equals(n2));

            //on ajoute un examen afin de différencier sur les examens
            n1.AddExam(new Exam());

            //retournes faux car n1 a un examen de plus
            Assert.False(n1.Equals(n2));
        }
    }
}

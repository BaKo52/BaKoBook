using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Logic;

namespace TestLogic
{
    /// <summary>
    /// Classe testant la classe Exam
    /// </summary>
    public class TestExam
    {
        /// <summary>
        /// Test la contrainte sur le module de l'examen
        /// </summary>
        [Fact]
        public void TestContrainteModule()
        {
            Exam e = new Exam();

            Assert.Throws<Exception>(() => { e.Module = null; });

            //throw une exception si faux
            e.Module = new Module();
        }

        /// <summary>
        /// Test les contraintes sur le coef de l'examen
        /// </summary>
        [Fact]
        public void TestContrainteCoef()
        {
            Exam e = new Exam();

            Assert.Equal(1, e.Coef);

            Assert.Throws<Exception>(() => { e.Coef = -1; });
            Assert.Throws<Exception>(() => { e.Coef = 0; });

            //throw une exception si faux
            e.Coef = 1;
        }

        /// <summary>
        /// Test les contraintes sur la note de l'examen
        /// </summary>
        [Fact]
        public void TestContrainteNote()
        {
            Exam e = new Exam();

            Assert.Equal(0, e.Note);

            Assert.Throws<Exception>(() => { e.Note = 21; });
            Assert.Throws<Exception>(() => { e.Note = -1; });

            //throw une exception si faux
            e.Note = 0;
            e.Note = 20;
        }

        /// <summary>
        /// Test les contraintes sur la date par défaut de l'examen
        /// </summary>
        [Fact]
        public void TestContrainteDate()
        {
            Exam e = new Exam();

            Assert.Equal(DateTime.Now.ToShortDateString(), e.DateExam.ToShortDateString());

            //throw une exception si faux
            e.DateExam = DateTime.Now;
        }

        
        /// <summary>
        /// Test les contraintes sur la valeur par défaut de IsAbsent de l'examen
        /// </summary>
        [Fact]
        public void TestContrainteIsAbsent()
        {
            Exam e = new Exam();

            Assert.True(e.IsAbsent);

            //throw une exception si faux
            e.IsAbsent = true;
            e.IsAbsent = false;
        }

        /// <summary>
        /// Fonction testant la fonction Equals de la classe Exam
        /// </summary>
        [Fact]
        public void TestEquals()
        {
            // on créé les deux Exams ainsi que le module contenant les deux exams;
            Module m = new Module();

            Exam e1 = new Exam();
            e1.Coef = 2;
            e1.IsAbsent = false;
            e1.DateExam = new DateTime(2021, 11, 12);
            e1.Module = m;
            e1.Note = 20;
            e1.Teacher = "Resin";

            Exam e2 = new Exam();
            e2.Coef = 2;
            e2.IsAbsent = false;
            e2.DateExam = new DateTime(2021, 11, 12);
            e2.Module = m;
            e2.Note = 20;
            e2.Teacher = "Resin";

            //retourne vrai car les deux examens sont identiques
            Assert.True(e1.Equals(e2));

            //modifions un examen afin de les différencier
            e2.Note = 2;

            //retourne faux car un des deux exams est différent
            Assert.False(e1.Equals(e2));
        }
    }
}

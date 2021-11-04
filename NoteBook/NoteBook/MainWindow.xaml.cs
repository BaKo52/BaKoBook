using IHM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Logic;

namespace NoteBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Constructeur de la fenêtre principale
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.note = new Notebook();

            //Unités, modules et examens réalisés pour la démo de l'application
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

            //on crée deux exams par module
            //remplis avec des valeurs légales et aléatoires
            Exam e1 = new Exam();
            e1.Coef = 1;
            e1.Note = 20;
            e1.Module = m1;
            e1.Teacher = "Brost";
            Exam e2 = new Exam();
            e2.Coef = 4;
            e2.Note = 3;
            e2.Module = m1;
            e2.Teacher = "Simonet";
            Exam e3 = new Exam();
            e3.Coef = 2;
            e3.Note = 20;
            e3.Module = m2;
            e3.Teacher = "Serier";
            Exam e4 = new Exam();
            e4.Coef = 1;
            e4.Note = 13;
            e4.Module = m2;
            e4.Teacher = "Guidet";
            Exam e5 = new Exam();
            e5.Coef = 43;
            e5.Note = 16;
            e5.Module = m3;
            e5.Teacher = "Rampacek";
            Exam e6 = new Exam();
            e6.Coef = 0.5f;
            e6.Note = 18;
            e6.Module = m3;
            e6.Teacher = "Resin";
            Exam e7 = new Exam();
            e7.Coef = 6;
            e7.Note = 3;
            e7.Module = m4;
            e7.Teacher = "Cherifi";
            Exam e8 = new Exam();
            e8.Coef = 4;
            e8.Note = 1;
            e8.Module = m4;
            e8.Teacher = "Tupinier";

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
        }

        /// <summary>
        /// Attribut indiquand l'agenda de l'élève
        /// </summary>
        private Logic.Notebook note;

        /// <summary>
        /// Méthode permettant de modifier les unités
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoEditUnits(object sender, RoutedEventArgs e)
        {
            EditUnitsWindow second = new EditUnitsWindow(note);
            second.Show();
        }

        /// <summary>
        /// méthode permettant de rentrer un examen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterExam(object sender, RoutedEventArgs e)
        {
            EditExamWindow exam = new EditExamWindow(note);
            exam.Show();
        }

        /// <summary>
        /// Fonction listant les examens passés par l'élève
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListExamsWindow(object sender, RoutedEventArgs e)
        {
            ListExamsWindow second = new ListExamsWindow(this.note);
            second.Show();
        }
    }
}

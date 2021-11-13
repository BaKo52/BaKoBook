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
using Storage;

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

            storage = new JsonStorage("data.json");
            note = storage.Load();

            /*
            //on créé un notebook
            note = new Notebook();

            //on créé 4 unit
            Unit u1 = new Unit();
            u1.Name = "Unit 1";
            u1.Coef = 1;
            Unit u2 = new Unit();
            u2.Name = "Unit 2";
            u2.Coef = 2;
            Unit u3 = new Unit();
            u3.Name = "Unit 3";
            u3.Coef = 3;
            Unit u4 = new Unit();
            u4.Name = "Unit 4";
            u4.Coef = 4;

            //on créé 8 modules (2 par units);
            Module u1m1 = new Module();
            u1m1.Coef = 11;
            u1m1.Name = "Unit 1 Module 1";
            Module u1m2 = new Module();
            u1m2.Coef = 12;
            u1m2.Name = "Unit 1 Module 2";
            Module u2m1 = new Module();
            u2m1.Coef = 21;
            u2m1.Name = "Unit 2 Module 1";
            Module u2m2 = new Module();
            u2m2.Coef = 22;
            u2m2.Name = "Unit 2 Module 2";
            Module u3m1 = new Module();
            u3m1.Coef = 31;
            u3m1.Name = "Unit 3 Module 1";
            Module u3m2 = new Module();
            u3m2.Coef = 32;
            u3m2.Name = "Unit 3 Module 2";
            Module u4m1 = new Module();
            u4m1.Coef = 41;
            u4m1.Name = "Unit 4 Module 1";
            Module u4m2 = new Module();
            u4m2.Coef = 42;
            u4m2.Name = "Unit 4 Module 2";
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
            note.AddUnit(u1);
            note.AddUnit(u2);
            note.AddUnit(u3);
            note.AddUnit(u4);

            Exam e1 = new Exam();
            e1.Coef = 2;
            e1.IsAbsent = false;
            e1.DateExam = new DateTime(2021, 11, 12);
            e1.Module = u3m2;
            e1.Note = 20;
            e1.Teacher = "Resin";

            Exam e2 = new Exam();
            e2.Coef = 2;
            e2.IsAbsent = false;
            e2.DateExam = new DateTime(2021, 11, 12);
            e2.Module = u1m1;
            e2.Note = 20;
            e2.Teacher = "Resin";

            note.AddExam(e1);
            note.AddExam(e2);
            */
        }

        /// <summary>
        /// Attribut indiquant l'agenda de l'élève
        /// </summary>
        private Logic.Notebook note;

        /// <summary>
        /// Attribut gérant le stockage des données
        /// </summary>
        private IStorage storage;

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
        private void GoCreateExam(object sender, RoutedEventArgs e)
        {
            EditExamWindow exam = new EditExamWindow(note);
            exam.Show();
        }

        /// <summary>
        /// Fonction listant les examens passés par l'élève
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoListExams(object sender, RoutedEventArgs e)
        {
            ListExamsWindow second = new ListExamsWindow(this.note);
            second.Show();
        }

        /// <summary>
        /// Fonction appelé lors de la fermeture du programme (ici la sauvegarde des données)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onClose(object sender, EventArgs e)
        {
            storage.Save(note);
        }
    }
}

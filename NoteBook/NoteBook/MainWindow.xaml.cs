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

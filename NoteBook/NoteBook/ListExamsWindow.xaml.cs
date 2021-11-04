using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Logic;

namespace IHM
{
    /// <summary>
    /// Logique d'interaction pour ListExamsWindow.xaml
    /// </summary>
    public partial class ListExamsWindow : Window
    {
        private Notebook note;

        /// <summary>
        /// Constructeur de la fenêtre
        /// </summary>
        /// <param name="nb"></param>
        public ListExamsWindow(Notebook nb)
        {
            InitializeComponent();

            note = nb;
            DrawExams();
        }

        /// <summary>
        /// Ferme la fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Méthode dessinant les examens dans la fenêtre
        /// </summary>
        private void DrawExams()
        {
            exams.Items.Clear();
            foreach (Exam e in note.ListExam())
            {
                exams.Items.Add(e);
            }

            scores.Items.Clear();
            foreach (AvgScore avg in note.ComputeScores())
            {
                scores.Items.Add(avg);
            }
        }
    }
}

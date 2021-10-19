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
    /// Logique d'interaction pour EditExamWindow.xaml
    /// </summary>
    public partial class EditExamWindow : Window
    {
        /// <summary>
        /// Attribut représentant l'agenda de l'élève (ses unités, ses exams, ses modules ...)
        /// </summary>
        private Notebook noteb;

        /// <summary>
        /// Attribut représentant l'examen qu'est en train de modifier l'utilisateur
        /// </summary>
        private Exam exam;

        /// <summary>
        /// Constructeur de la fenêtre d'IHM
        /// </summary>
        /// <param name="nb">notebook de l'élève</param>
        public EditExamWindow(Notebook nb)
        {
            InitializeComponent();

            noteb = nb;
            exam = new Exam();
            this.noteBox.Text = exam.Note.ToString();
            this.datePicker.SelectedDate = exam.DateExam;
            this.isAbsentBox.IsChecked = exam.IsAbsent;
            this.coefBox.Text = exam.Coef.ToString();
            drawModules();
        }

        public void drawModules()
        {
            foreach (Module m in noteb.ListModules()){
                moduleBox.Items.Add(m);
            }
        }

        /// <summary>
        /// Méthode validant le contenu des champs et les rentrant dans l'exam
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Validate(object sender, RoutedEventArgs e)
        {
            exam.Coef = (float)Convert.ToDouble(coefBox.Text);
            exam.DateExam = Convert.ToDateTime(this.datePicker.SelectedDate);
            exam.IsAbsent = Convert.ToBoolean(this.isAbsentBox.IsChecked);
            exam.Module = (Module)this.moduleBox.SelectedItem;
            exam.Note = (float)Convert.ToDouble(this.noteBox.Text);
            exam.Teacher = this.teacherBox.Text;

            noteb.AddExam(exam);
            Close();
        }

        /// <summary>
        /// Fonction fermant la fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}

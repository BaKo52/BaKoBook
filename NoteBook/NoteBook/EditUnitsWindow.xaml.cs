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
    /// Logique d'interaction pour EditUnitsWindow.xaml
    /// </summary>
    public partial class EditUnitsWindow : Window
    {
        /// <summary>
        /// Constructeur de la fenêtre EditUnitsWindow
        /// </summary>
        /// <param name="nb"></param>
        public EditUnitsWindow(Logic.Notebook nb)
        {
            this.note = nb;
            InitializeComponent();
            DrawUnits();
        }

        /// <summary>
        /// Attribut représentant l'agenda de l'élève afin de pouvoir accéder à ces données dans cette fenêtre
        /// </summary>
        private Logic.Notebook note;

        /// <summary>
        /// Méthode affichant la liste des unités dans le tableau
        /// </summary>
        private void DrawUnits()
        {
            var list = note.ListUnits();
            listBox.Items.Clear();
            foreach (var item in list)
                listBox.Items.Add(item);
        }
    }
}

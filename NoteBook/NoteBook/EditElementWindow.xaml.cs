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
    /// Logique d'interaction pour EditElementWindow.xaml
    /// </summary>
    public partial class EditElementWindow : Window
    {
        /// <summary>
        /// Constructeur de la classe EditElementWindow
        /// </summary>
        public EditElementWindow(PedagogicalElement elt)
        {
            InitializeComponent();
            element = elt;
            name.Text = elt.Name;
            coef.Text = elt.Coef.ToString();
        }

        /// <summary>
        /// Attribut représentant l'élément pédagogique en cours de modification
        /// </summary>
        PedagogicalElement element;
        
        /// <summary>
        /// Méthode effectué lors du click sur le bouton validate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Validate(object sender, RoutedEventArgs e)
        {
            try
            {
                element.Name = name.Text;
                element.Coef = (float)Convert.ToDouble(coef.Text);
                DialogResult = true;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}

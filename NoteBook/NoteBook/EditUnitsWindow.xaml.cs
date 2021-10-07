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
            listBoxUnit.Items.Clear();
            foreach (var item in list)
                listBoxUnit.Items.Add(item);
        }

        /// <summary>
        /// Méthode ouvrant une nouvelle fenêtre permettant l'édition de l'unité
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditUnit(object sender, MouseButtonEventArgs e)
        {
            if (listBoxUnit.SelectedItem is Unit u)
            {
                EditElementWindow third = new EditElementWindow(u);
                if (third.ShowDialog() == true)
                {
                    DrawUnits();
                }
            }
        }

        /// <summary>
        /// Méthode ajoutant une unité à la liste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUnit(object sender, RoutedEventArgs e)
        {
            try
            {
                Unit newUnit = new Unit();
                EditElementWindow third = new EditElementWindow(newUnit);
                if (third.ShowDialog() == true)
                {
                    note.AddUnit(newUnit);
                    DrawUnits();
                }
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// Evenement du bouton enlevant l'unité sélectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveUnit(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listBoxUnit.SelectedItem is Unit unit)
                {
                    note.RemoveUnit(unit);
                    DrawUnits();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// Méthode dessinant les modules dans la listBox
        /// </summary>
        private void DrawModules()
        {
            if(listBoxUnit.SelectedItem is Unit unit)
            {
                var list = unit.ListModules();
                listBoxModules.Items.Clear();
                foreach (Module m in list)
                    listBoxModules.Items.Add(m);
            }
            else
            {
                listBoxModules.Items.Clear();
            }
        }

        /// <summary>
        /// Fonction mettant à jour l'affichage en fonction de l'unité sélectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectUnit(object sender, SelectionChangedEventArgs e)
        {
            DrawModules();
        }

        /// <summary>
        /// Fonction ajoutant un module
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddModule(object sender, RoutedEventArgs e)
        {
            try
            {
                Module newModule = new Module();
                EditElementWindow third = new EditElementWindow(newModule);
                if (third.ShowDialog() == true)
                {
                    if(this.listBoxUnit.SelectedItem is Unit unit)
                    {
                        unit.AddModules(newModule);
                        DrawModules();
                    }
                }
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }
        }

        /// <summary>
        /// Fonction retirant un module
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveModule(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listBoxModules.SelectedItem is Module m && listBoxUnit.SelectedItem is Unit u)
                {
                    u.RemoveModule(m);
                    DrawModules();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}

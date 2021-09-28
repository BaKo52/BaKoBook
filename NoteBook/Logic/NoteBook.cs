using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Classe représentant l'agenda de l'éléve.
    /// La classe principale qui regroupe tout
    /// </summary>
    public class Notebook
    {
        /// <summary>
        /// COnstructeur de la classe Notebook
        /// </summary>
        public Notebook()
        {
            this.exams = new List<Exam>();
            this.units = new List<Unit>();
        }

        /// <summary>
        /// Liste des examens passé par l'élève
        /// </summary>
        private List<Exam> exams;
        /// <summary>
        /// Setter de l'attribut exams
        /// </summary>
        public List<Exam> Exams
        {
            set
            {
                this.exams = value;
            }
        }

        /// <summary>
        /// Liste des unités de l'élève
        /// </summary>
        private List<Unit> units;

        /// <summary>
        /// Getter de l'attribut units
        /// </summary>
        public List<Unit> Units
        {
            get => units;
        }

        /// <summary>
        /// Méthode retournant la liste des unités sous forme de tableau
        /// </summary>
        /// <returns>La liste des unités</returns>
        public Unit[] ListUnits()
        {
            return this.Units.ToArray();
        }

        /// <summary>
        /// Méthode ajoutant une unité dans la liste des unités de l'agenda
        /// Elle teste si une unité du même nom est déjà présente
        /// Si c'est le cas elle throw une exception
        /// </summary>
        /// <param name="u">Unité à ajouter à la liste</param>
        public void AddUnit(Unit u)
        {
            bool isALreadyIn = false;

            foreach (Unit item in units)
                if(item.Name == u.Name)
                {
                    isALreadyIn = true;
                }

            if (!isALreadyIn)
            {
                this.Units.Add(u);
            }
            else
            {
                throw new Exception("Cette unité est déjà dans votre agenda !");
            }
        }

        public void RemoveUnit(Unit u)
        {
            this.units.Remove(u);
        }
    }
}

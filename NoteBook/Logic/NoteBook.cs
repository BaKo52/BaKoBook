using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Classe représentant l'agenda de l'éléve.
    /// La classe principale qui regroupe tout
    /// </summary>
    public class NoteBook
    {
        public NoteBook()
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
        /// Setter et getter de l'attribut units
        /// </summary>
        public List<Unit> Units
        {
            get => units;
            set
            {
                this.units = value;
            }
        }

        /// <summary>
        /// Méthode retournant la liste des unités sous forme de tableau
        /// </summary>
        /// <returns>La liste des unités</returns>
        public Unit[] ListUnits()
        {
            return this.Units.ToArray();
        }
    }
}

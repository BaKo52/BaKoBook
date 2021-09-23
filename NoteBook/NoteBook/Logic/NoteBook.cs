using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Classe représentant l'agenda de l'éléve.
    /// La classe principale qui regroupe tout
    /// </summary>
    class NoteBook
    {
        /// <summary>
        /// Liste des examens passé par l'élève
        /// </summary>
        private List<Exam> exams;
        /// <summary>
        /// Setter et geter de l'attribut exams
        /// </summary>
        public List<Exam> Exams
        {
            get => exams;
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
    }
}

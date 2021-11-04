using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Classe représentant la moyenne d'un élément pédagogique
    /// </summary>
    public class AvgScore
    {
        /// <summary>
        /// Elément pédagogique que représente la moyenn
        /// </summary>
        private PedagogicalElement pe;
        public PedagogicalElement PedagoElement {
            get => pe;
        }
        
        /// <summary>
        /// Variable contenant la moyenn
        /// </summary>
        private float average;

        public float Average
        {
            get => average;
            set { if (value < 0 || value > 20) { throw new ArgumentException(); } else { average = value; } }
        }

        /// <summary>
        /// Constructeur de la classe AvgScore
        /// </summary>
        /// <param name="average">paramètre pour la moyenne</param>
        /// <param name="pe">paramètre de l'élément pédagogique</param>
        public AvgScore(float average, PedagogicalElement pe)
        {
            this.pe = pe ?? throw new ArgumentNullException(nameof(pe));
            this.Average = average;
        }

        /// <summary>
        /// Fonction ToString() de la classe
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        { 
            return pe + ": " + average;
        }
    }
}

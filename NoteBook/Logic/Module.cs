using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Classe représentant les modules
    /// </summary>
    public class Module : PedagogicalElement
    {
        /// <summary>
        /// Méthode calculant la moyenne d'un module
        /// </summary>
        /// <param name="exams">Liste des examens</param>
        /// <returns>Renvoie null si le module n'a pas d'examen. Renvoie un AvgScore si une moyenne peut-être calculé</returns>
        public AvgScore ComputeAverage(Exam[] exams)
        {
            AvgScore avgs = null;
            double avg = 0;
            double total = 0;

            foreach (Exam e in exams)
            {
                if (e.Module == this)
                {
                    avg += e.Coef * e.Note;
                    total += e.Coef;
                }
            }

            if (total != 0)
            {
                avg /= total;
                avg = Math.Round(avg, 2);
                avgs = new AvgScore((float)(avg), this);
            }

            return avgs;
        }
    }
}

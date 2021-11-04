using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Classe représentant les unités
    /// </summary>
    public class Unit : PedagogicalElement
    {
        /// <summary>
        /// Liste des modules de l'unité
        /// </summary>
        private List<Module> modules = new List<Module>();
        
        /// <summary>
        /// Setter et getter de la liste des modules
        /// </summary>
        public List<Module> Modules
        {
            set
            {
                this.modules = value;
            }
        }

        /// <summary>
        /// Liste les modules de l'unité
        /// </summary>
        /// <returns>Un array contenant tout les modules de l'unité</returns>
        public Module[] ListModules()
        {
            return this.modules.ToArray();
        }

        /// <summary>
        /// Fonction ajoutant un module à la liste des modules
        /// </summary>
        /// <param name="m">Module à ajouter</param>
        public void AddModules(Module m)
        {
            this.modules.Add(m);
        }

        /// <summary>
        /// Fonction supprimant un module de l'unité
        /// </summary>
        /// <param name="m">Module à supprimer</param>
        public void RemoveModule(Module m)
        {
            this.modules.Remove(m);
        }

        /// <summary>
        /// Fonction retournant les moyennes des modules de l'unité
        /// </summary>
        /// <param name="exams">Liste des examens</param>
        /// <returns>Un tableau contenant les moyennes des modules de l'unité</returns>
        public AvgScore[] ComputeAverages(Exam[] exams)
        {
            List<AvgScore> listAvgs = new List<AvgScore>();

            foreach (Module m in modules)
            {
                listAvgs.Add(m.ComputeAverage(exams));
            }

            return listAvgs.ToArray();
        }
    }
}

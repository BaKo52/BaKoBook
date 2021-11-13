using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Classe représentant les unités
    /// </summary>
    [DataContract]
    public class Unit : PedagogicalElement
    {
        /// <summary>
        /// Liste des modules de l'unité
        /// </summary>
        [DataMember]
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
            modules.Remove(m);
        }

        /// <summary>
        /// Fonction retournant les moyennes des modules de l'unité
        /// </summary>
        /// <param name="exams">Liste des examens</param>
        /// <returns>Un tableau contenant les moyennes des modules de l'unité</returns>
        public AvgScore[] ComputeAverages(Exam[] exams)
        {
            List<AvgScore> listAvgs = new List<AvgScore>();
            AvgScore avg = null;

            foreach (Module m in modules)
            {
                avg = m.ComputeAverage(exams);

                if (avg != null)
                {
                    listAvgs.Add(avg);
                }
            }

            return listAvgs.ToArray();
        }

        public override bool Equals(object obj)
        {
            bool b = false;

            //on vérifier que le type de l'objet est le bon et que le nombre de module correspond
            if (obj is Unit unit && unit.ListModules().Length == ListModules().Length)
            {
                //on vérifie d'abord les attributs de hérités de PedagogicalElement
                b = unit.Coef == Coef && unit.Name == Name;

                //on vérifie ensuite les modules
                Module[] arrayM = unit.ListModules();

                Module m = null;

                for (int i = 0; i < modules.Count; i++)
                {
                    m = modules[i];
                    b &= m.Equals(arrayM[i]);
                }
            }

            return b;
        }
    }
}

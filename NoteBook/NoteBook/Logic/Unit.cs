using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Classe représentant les unités
    /// </summary>
    class Unit:PedagogicalElement
    {
        /// <summary>
        /// Liste des modules de l'unité
        /// </summary>
        private List<Module> modules;
        /// <summary>
        /// Setter et getter de la liste des modules
        /// </summary>
        public List<Module> Modules
        {
            set
            {
                this.modules = value;
            }

            get => modules;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Interface implémentant la fonctionnalité de persistance des données
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Méthode chargeant les données
        /// </summary>
        /// <returns>Un objet de type Notebook contenant les données chargées</returns>
        public Notebook Load();

        /// <summary>
        /// Méthode sauvegardant les données d'un Notebook passés en paramètre
        /// </summary>
        /// <param name="n">Le notebook devant être sauvegardé</param>
        public void Save(Notebook n);
    }
}

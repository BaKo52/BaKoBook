using System;
using System.Runtime.Serialization;

namespace Logic
{
    /// <summary>
    /// Classe parent représentant les modules et les unités
    /// </summary>
    [DataContract]
    public class PedagogicalElement
    {
        /// <summary>
        /// Nom de l'élément pédagogique
        /// </summary>
        [DataMember]
        private String name;
        /// <summary>
        /// Setter et Getter de l'attribut name
        /// </summary>
        public String Name
        {
            get => name;
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// Coefficient de l'élément pédagogique
        /// Doit être supérieur à 0
        /// </summary>
        [DataMember]
        private float coef;
        /// <summary>
        /// Setter et Getter de l'attribut coef
        /// </summary>
        public float Coef
        {
            get => coef;

            set
            {
                if (value <= 0) throw new Exception("The coef must be > 0");
                coef = value;
            }
        }

        public override String ToString()
        {
            return this.name + '(' + this.coef + ')';
        }

        public override bool Equals(object obj)
        {
            return obj is PedagogicalElement element &&
                Coef == element.Coef &&
                Name == element.Name;
        }
    }
}

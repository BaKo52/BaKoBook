using System;
using Logic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Storage
{
    /// <summary>
    /// Classe implémentant la persistance des données sous forme de fichier JSON
    /// </summary>
    public class JsonStorage : IStorage
    {
        /// <summary>
        /// Attribut indiquant le chemin de sauvegarde des données
        /// </summary>
        private String filename;

        /// <summary>
        /// Constructeur sans argument de la classe JsonStorage (en privé afin de devoir obligatoirement spécifier une valeur pour filename)
        /// </summary>
        private JsonStorage() { }

        /// <summary>
        /// Constructeur de la classe JsonStorage précisant une valeur pour le fichier de stockage
        /// </summary>
        /// <param name="name"></param>
        public JsonStorage(String name)
        {
            filename = name;
        }

        /// <summary>
        /// Fonction chargeant une sauvegarde
        /// </summary>
        /// <returns>Notebook qui a été chargé depuis la sauvegarde</returns>
        public Notebook Load()
        {
            Notebook n;

            FileStream fichier = new FileStream(filename, FileMode.Open);

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Notebook));

            n = ser.ReadObject(fichier) as Notebook;

            fichier.Close();

            return n;
        }

        /// <summary>
        /// Fonction créant une sauvegarde
        /// </summary>
        /// <param name="n">Notebook a sauvegarder</param>
        public void Save(Notebook n)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Notebook));

            FileStream fichier = new FileStream(filename, FileMode.Create);

            ser.WriteObject(fichier, n);
            fichier.Close();
        }
    }
}

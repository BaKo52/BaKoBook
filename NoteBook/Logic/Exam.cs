using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Classe représenant un examens
    /// </summary>
    [DataContract]
    public class Exam
    {
        /// <summary>
        /// Professeur passant l'exament
        /// </summary>
        [DataMember]
        private String teacher;
        /// <summary>
        /// Getter et setter de l'attribut teacher;
        /// </summary>
        public String Teacher
        {
            get => teacher;
            set
            {
                this.teacher = value;
            }
        }

        /// <summary>
        /// Date et heure de l'examen
        /// </summary>
        [DataMember]
        private DateTime dateExam = DateTime.Now;
        /// <summary>
        /// Getter et setter de l'attribut dateExam
        /// </summary>
        public DateTime DateExam
        {
            get => dateExam;
            set
            {
                this.dateExam = value;
            }
        }

        /// <summary>
        /// Coefficient de l'examen
        /// </summary>
        [DataMember]
        private float coef = 1;
        /// <summary>
        /// Setter et getter de l'attribut coef
        /// </summary>
        public float Coef
        {
            get => coef;
            set
            {
                if (value > 0) coef = value;
                else throw new Exception("Le coef doit être strictement supérieur à 0");
            }
        }

        /// <summary>
        /// Attribut indiquant si l'élève était absent à cet examen
        /// </summary>
        [DataMember]
        private Boolean isAbsent = true;
        /// <summary>
        /// Getter et setter de l'attribut isAbsent
        /// </summary>
        public Boolean IsAbsent
        {
            get => isAbsent;
            set
            {
                this.isAbsent = value;
            }
        }

        /// <summary>
        /// Attribut indiquant la note qu'a obtenu l'étudiant à cet exament
        /// </summary>
        [DataMember]
        private float note = 0;
        /// <summary>
        /// Getter et setter de l'attribut note
        /// </summary>
        public float Note
        {
            get => note;
            set
            {
                if (value <= 20 && value >= 0) note = value;
                else throw new Exception("La note doit être comprise entre 0 et 20.");
            }
        }

        /// <summary>
        /// Module auquel l'exam appartient
        /// </summary>
        [DataMember]
        private Module module;
        /// <summary>
        /// Getter et Setter de l'attribut
        /// </summary>
        public Module Module
        {
            get => module;
            set
            {
                if (value != null) module = value;
                else throw new Exception("Le module ne doit pas être nul !");
            }
        }
    }
}

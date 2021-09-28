using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Classe représenant un examens
    /// </summary>
    public class Exam
    {
        /// <summary>
        /// Professeur passant l'exament
        /// </summary>
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
        private DateTime dateExam;
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
        private float coef;
        /// <summary>
        /// Setter et getter de l'attribut coef
        /// </summary>
        public float Coef
        {
            get => coef;
            set
            {
                this.coef = value;
            }
        }

        /// <summary>
        /// Attribut indiquant si l'élève était absent à cet examen
        /// </summary>
        private Boolean isAbsent;
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
        private float note;
        /// <summary>
        /// Getter et setter de l'attribut note
        /// </summary>
        public float Note
        {
            get => note;
            set
            {
                this.note = value;
            }
        }

        /// <summary>
        /// Module auquel l'exam appartient
        /// </summary>
        private Module module;
        /// <summary>
        /// Getter et Setter de l'attribut
        /// </summary>
        public Module Module
        {
            get => module;
            set
            {
                this.module = value;
            }
        }
    }
}

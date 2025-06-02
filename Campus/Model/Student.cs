
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Campus.Model
{

    public class Student : Person
    {
        public required string IdStudent_code { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
        public string IdSchool_code { get; set; } = string.Empty;
        public School? School { get; set; }

        // Costruttore vuoto (per serializzazione)
        public Student() : base(string.Empty, string.Empty, string.Empty)
        {
        }

        // Costruttore principale completo
        public Student(
            string fiscalCode,
            string name,
            string surname,
            string idStudent_code,
            string idSchool_code,
            List<Course>? courses = null)
            : base(fiscalCode, name, surname)
        {
            IdStudent_code = idStudent_code;
            IdSchool_code = idSchool_code;
            Courses = courses ?? new List<Course>();
        }

        // Costruttore semplificato (senza scuola)
        public Student(
            string fiscalCode,
            string name,
            string surname,
            string idStudent_code,
            List<Course>? courses = null)
            : this(fiscalCode, name, surname, idStudent_code, string.Empty, courses)
        {
        }
    }
}


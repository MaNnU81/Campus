    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    namespace Campus.Model
    {

        public  class Teacher : Person
        {
            public required string IdTeacher_code { get; set; }
            public string Subject { get; set; } = "Unassigned"; // Valore di default
            public List<Course> Courses { get; set; } = new List<Course>();
            public string IdSchool_code { get; set; } = string.Empty;
            public School? School { get; set; }

            // Costruttore vuoto
            public Teacher() : base(string.Empty, string.Empty, string.Empty)
            {
            }

            // Costruttore principale
            public Teacher(
                string fiscalCode,
                string name,
                string surname,
                string idTeacher_code,
                string subject = "Unassigned",
                string idSchool_code = "")
                : base(fiscalCode, name, surname)
            {
                IdTeacher_code = idTeacher_code;
                Subject = subject;
                IdSchool_code = idSchool_code;
            }

            // Costruttore completo (opzionale)
            public Teacher(
                string fiscalCode,
                string name,
                string surname,
                string idTeacher_code,
                string subject,
                List<Course>? courses,
                School? school)
                : this(fiscalCode, name, surname, idTeacher_code, subject)
            {
                Courses = courses ?? new List<Course>();
                School = school;
            }
        }
    }

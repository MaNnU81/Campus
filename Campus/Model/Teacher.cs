using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campus.Model
{
    internal class Teacher : Person
    {
        public string IdTeacher_code { get; set; }
        public string Subject { get; set; }
        public List<Course> Courses { get; set; }


        public Teacher(string fiscalCode, string name, string surname, string idTeacher_code, string subject, List<Course> courses)
            : base(fiscalCode, name, surname)
        {
            IdTeacher_code = idTeacher_code;
            Subject = subject;
            Courses = courses;
        }

        public Teacher(string subject, List<Course>? courses) : base(fiscalCode, name, surname)
        {
            Subject = subject;
            Courses = courses ?? new List<Course>();
        }
    }




}

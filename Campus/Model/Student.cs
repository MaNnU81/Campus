using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Campus.Model
{
    internal class Student : Person
    {
        public string IdStudent_code { get; set; }

        public List<Course> Courses { get; set; }

        public Student(string fiscalCode, string name, string surname,  string idStudent_code, List<Course>? courses) : base(fiscalCode, name, surname)
        {
            IdStudent_code = idStudent_code;
            Courses = courses ?? new List<Course>();
        }
    }
  
}

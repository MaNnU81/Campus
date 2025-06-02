using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Campus.Model
{
    public class School
    {
        public required string IdSchool_code { get; set; }
        public required string SiteName { get; set; }
        public string? Address { get; set; }

        public List<Student>? Students { get; set; }
        public List<Teacher>? Teachers { get; set; }

        // Costruttore principale
        public School(string idSchool_code, string siteName, string? address, List<Student>? students, List<Teacher>? teachers)
        {
            IdSchool_code = idSchool_code;
            SiteName = siteName;
            Address = address;
            Students = students ?? new List<Student>();
            Teachers = teachers ?? new List<Teacher>();
        }

        // Costruttore vuoto
        public School()
        {
            Students = new List<Student>();
            Teachers = new List<Teacher>();
        }

        // Costruttore alternativo
        public School(string idSchool_code, string siteName, string? address, List<Teacher> teachers, List<Student> students)
            : this(idSchool_code, siteName, address, students, teachers)
        {
        }

        internal List<Student> GetStudents()
        {
            return Students ?? new List<Student>();
        }

        internal List<Teacher> GetTeachers()
        {
            return Teachers ?? new List<Teacher>();
        }

        internal List<Course> GetCoursesByTeacherId(string teacherId)
        {
            if (Teachers == null) return new List<Course>();

            foreach (var teacher in Teachers)
            {
                if (teacher.IdTeacher_code == teacherId)
                {
                    return teacher.Courses ?? new List<Course>();
                }
            }
            return new List<Course>();
        }

        internal List<Course> GetCoursesByStudentId(string studentId)
        {
            if (Students == null) return new List<Course>();

            foreach (var student in Students)
            {
                if (student.IdStudent_code == studentId)
                {
                    return student.Courses ?? new List<Course>();
                }
            }
            return new List<Course>();
        }
    }
}
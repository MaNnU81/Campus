using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Campus.Model
{
    internal class School
    {
        public string IdSchool_code { get; set; }
        public string SiteName { get; set; }
        public string Address { get; set; }




        public List<Student>? Students { get; set; }
        public List<Teacher>? Teachers { get; set; }
     

      
        public School(string idSchool_code, string siteName, string address, List<Student>? students, List<Teacher>? teachers)
        {
            IdSchool_code = idSchool_code;
            SiteName = siteName;
            Address = address;
            Students = students ?? new List<Student>();
            Teachers = teachers ?? new List<Teacher>();
            
        }


        public School()
        {
        }

        public School(string idSchool_code, string siteName, string address, List<Teacher> teachers, List<Student> students)
        {
            IdSchool_code = idSchool_code;
            SiteName = siteName;
            Address = address;
            Teachers = teachers;
            Students = students;
        }

        internal List<Student> GetStudents()
        {
            return Students;
        }

        internal List<Teacher> GetTeachers()
        {
            return Teachers;
        }


        

        internal List<Course> GetCoursesByTeacherId(string idSchool_code)
        {
     foreach (var teacher in Teachers)
            {
                if (teacher.IdTeacher_code == idSchool_code)
                {
                    return teacher.Courses;
                }
            }
            return new List<Course>();
        }

        internal List<Course> GetCoursesByStudentId(string IdStudent_code)
        {
         foreach (var student in Students)
            {
                if (student.IdStudent_code == IdStudent_code)
                {
                    return student.Courses;
                }
            }
            return new List<Course>();
        }




    }
}

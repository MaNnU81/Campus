using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Campus.Model
{
    internal class School
    {
        public string IdSchool_code { get; set; }
        public string SiteName { get; set; }
        public string Address { get; set; }




        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Course> Courses { get; set; }

        public School(string idSchool_code, string siteName, string address, List<Student>? students, List<Teacher>? teachers, List<Course>? courses)
        {
            IdSchool_code = idSchool_code;
            SiteName = siteName;
            Address = address;
            Students = students ?? new List<Student>();
            Teachers = teachers ?? new List<Teacher>();
            Courses = courses ?? new List<Course>();
        }

        public GetAllTeachers(List<Teacher> teachers)
        {
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"ID: {teacher.IdTeacher_code}, Teacher: {teacher.Name} {teacher.Surname}, Subject: {teacher.Subject}");
            }
        }

        public GetAllStudents(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($" ID: {student.IdStudent_code}, Student: {student.Name} {student.Surname}");
            }
        }

        public GetAllCourses(List<Course> courses)
        {
            var courses = new List<Course>();


            foreach (var course in courses)
            {
                Console.WriteLine($" ID: {course.IdCourse_code}, Course: {course.Course_Name}");
            }

            courses.Add(course);
        }

        public GetAllCourseByIdTeacher(List<Course> courses, string idTeacher)
        {
            var coursesByTeacher = courses.Where(c => c.IdTeacher_code == idTeacher).ToList();
            if (coursesByTeacher.Count > 0)
            {
                foreach (var course in coursesByTeacher)
                {
                    Console.WriteLine($"ID: {course.IdCourse_code}, Course: {course.Course_Name}");
                }
            }
            else
            {
                Console.WriteLine("No courses found for this teacher.");
            }
        }


        public GetAllCourseByIdStudent(List<Course> courses, string idStudent)
        {
            var coursesByStudent = courses.Where(c => c.Students.Any(s => s.IdStudent_code == idStudent)).ToList();
            if (coursesByStudent.Count > 0)
            {
                foreach (var course in coursesByStudent)
                {
                    Console.WriteLine($"ID: {course.IdCourse_code}, Course: {course.Course_Name}");
                }
            }
            else
            {
                Console.WriteLine("No courses found for this student.");
            }
        }

    }
}

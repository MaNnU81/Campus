//using System;
//using System.Collections.Generic;
//using System.Dynamic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Campus.Model;

//namespace Campus
//{
//    internal class Metodi
//    {
//        public Metodi() { }

//        public GetAllTeachers(List<Teacher> teachers)
//        {
//            foreach (var teacher in teachers)
//            {
//                Console.WriteLine($"ID: {teacher.IdTeacher_code}, Teacher: {teacher.Name} {teacher.Surname}, Subject: {teacher.Subject}");
//            }
//        }

//        public GetAllStudents(List<Student> students)
//        {
//            foreach (var student in students)
//            {
//                Console.WriteLine($" ID: {student.IdStudent_code}, Student: {student.Name} {student.Surname}");
//            }
//        }

//        public GetAllCourses(List<Course> courses)
//        {
//            foreach (var course in courses)
//            {
//                Console.WriteLine($" ID: {course.IdCourse_code}, Course: {course.Course_Name}");
//            }
//        }

//        public GetAllCourseByIdTeacher(List<Course> courses, string idTeacher)
//        {
//            var coursesByTeacher = courses.Where(c => c.IdTeacher_code == idTeacher).ToList();
//            if (coursesByTeacher.Count > 0)
//            {
//                foreach (var course in coursesByTeacher)
//                {
//                    Console.WriteLine($"ID: {course.IdCourse_code}, Course: {course.Course_Name}");
//                }
//            }
//            else
//            {
//                Console.WriteLine("No courses found for this teacher.");
//            }
//        }


//        public GetAllCourseByIdStudent(List<Course> courses, string idStudent)
//        {
//            var coursesByStudent = courses.Where(c => c.Students.Any(s => s.IdStudent_code == idStudent)).ToList();
//            if (coursesByStudent.Count > 0)
//            {
//                foreach (var course in coursesByStudent)
//                {
//                    Console.WriteLine($"ID: {course.IdCourse_code}, Course: {course.Course_Name}");
//                }
//            }
//            else
//            {
//                Console.WriteLine("No courses found for this student.");
//            }
//        }

//    }
//}

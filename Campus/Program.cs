using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Campus.Model;

namespace Campus
{
    internal class Program
    {
        static void Main(string[] args)
        {


            var student1 = new Student("kn12345678901", "Kevin", "Napoli", "S001", new List<Course>());
            var student2 = new Student("jr23456789012", "Jessicah", "Roma", "S002", new List<Course>());



            var teacher1 = new Teacher("ab12345678901", "Alessandro", "Bianchi", "T001", "Mathematics", new List<Course>());
            var teacher2 = new Teacher("cv23456789012", "Claudia", "Verdi", "T002", "Physics", new List<Course>());



            var course1 = new Course("C001", "Math 101", 30, "Basic Mathematics", "T001", teacher1, new List<Student>());
            var course2 = new Course("C002", "Physics 101", 25, "Basic Physics", "T002", teacher2, new List<Student>());
            var course3 = new Course("C003", "Chemistry 101", 20, "Basic Chemistry", "T001", teacher1, new List<Student>());
            var course4 = new Course("C004", "Biology 101", 15, "Basic Biology", "T002", teacher2, new List<Student>());


            // **Aggiungi i corsi agli insegnanti**
            teacher1.Courses.Add(course1);
            teacher1.Courses.Add(course3);
            teacher2.Courses.Add(course2);
            teacher2.Courses.Add(course4);

            // **Aggiungi gli studenti ai corsi (e viceversa)**
            course1.Students.Add(student1); // Kevin in Math 101
            course2.Students.Add(student1); // Kevin in Physics 101
            course1.Students.Add(student2); // Jessicah in Math 101

            // **Aggiungi i corsi agli studenti**
            student1.Courses.Add(course1);
            student1.Courses.Add(course2);
            student2.Courses.Add(course1);


            var school = new School("S001", "Axia University", "123 Main St", new List<Teacher> { teacher1, teacher2 }, new List<Student> { student1, student2 });




            //var courses = school.GetCourses();

            ////////////// GET STUDENTS //////////////
            var students = school.GetStudents();
            Console.WriteLine("Students at " + school.SiteName + ":");
            foreach (var student in students)
            {
                Console.WriteLine($"- {student.Name} {student.Surname} (ID: {student.IdStudent_code}, CF: {student.FiscalCode})");
            }


            ////////////// GET TEACHER //////////////
            var teachers = school.GetTeachers();
            Console.WriteLine("Teachers at " + school.SiteName + ":");
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"- {teacher.Name} {teacher.Surname} (ID: {teacher.IdTeacher_code}, CF: {teacher.FiscalCode})");
            }


            ////////////// GET COURSE BY ID TEACHER //////////////
            Console.WriteLine("\nCorsi tenuti dal prof. T001 (Alessandro Bianchi):");
            var alessandrosCourses = school.GetCoursesByTeacherId("T001"); 
            foreach (var course in alessandrosCourses)
            {
                Console.WriteLine($"- {course.Course_Name} (ID: {course.IdCourse_code})");
            }

            ////////////// GET COURSE BY ID STUDENT //////////////
            Console.WriteLine("\nCorsi seguiti dallo studente S001 (Kevin Napoli):");
            var kevinsCourses = school.GetCoursesByStudentId("S001"); 
            foreach (var course in kevinsCourses)
            {
                Console.WriteLine($"- {course.Course_Name} (Teacher: {course.Teacher?.Name})");
            }


            ////////////// END //////////////








            //    var context = new CampusContext();
            //    var schools = context.Schools
            //       .Include(school => school.Teachers)
            //       .Include(school => school.Students)
            //       .ToList();

            //    foreach (var item in schools)
            //    {
            //        Console.WriteLine($"school: {item.Name}");
            //        foreach (var teacher in school.Teachers)
            //        {
            //            Console.WriteLine($"teacher: {teacher.Name}");
            //        }
            //        foreach (var student in school.Students)
            //        {
            //            Console.WriteLine($"student: {student.Name}");
            //        }
            //    }



        }
    }
}

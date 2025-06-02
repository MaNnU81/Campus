using System;
using System.Collections.Generic;
using System.Linq;
using Campus.Model;

namespace Campus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Inizializzazione dati
            var student1 = new Student
            {
                FiscalCode = "kn12345678901",
                Name = "Kevin",
                Surname = "Napoli",
                IdStudent_code = "S001",
                Courses = new List<Course>()
            };

            var student2 = new Student
            {
                FiscalCode = "jr23456789012",
                Name = "Jessicah",
                Surname = "Roma",
                IdStudent_code = "S002",
                Courses = new List<Course>()
            };

            // Stessa cosa per gli insegnanti:
            var teacher1 = new Teacher
            {
                FiscalCode = "ab12345678901",
                Name = "Alessandro",
                Surname = "Bianchi",
                IdTeacher_code = "T001",
                Subject = "Mathematics",
                Courses = new List<Course>()
            };
            var teacher2 = new Teacher
            {
                FiscalCode = "cf12345678901",
                Name = "Roberta",
                Surname = "Franceschini",
                IdTeacher_code = "T002",
                Subject = "Mathematics",
                Courses = new List<Course>()
            };


            // Creazione corsi (versione semplificata senza Teacher/Students nel costruttore)
            var course1 = new Course
            {
                IdCourse_code = "C001",
                Course_Name = "Math 101",
                MaxCapacity = 30,
                Description = "Basic Mathematics",
                IdTeacher_code = "T001"
            };

            var course2 = new Course
            {
                IdCourse_code = "C002",
                Course_Name = "Physics 101",
                MaxCapacity = 25,
                Description = "Basic Physics",
                IdTeacher_code = "T002"
            };

            var course3 = new Course
            {
                IdCourse_code = "C003",
                Course_Name = "Chemistry 101",
                MaxCapacity = 20,
                Description = "Basic Chemistry",
                IdTeacher_code = "T001"
            };

            var course4 = new Course
            {
                IdCourse_code = "C004",
                Course_Name = "Biology 101",
                MaxCapacity = 15,
                Description = "Basic Biology",
                IdTeacher_code = "T002"
            };

            // Assegnazione corsi (solo da Teacher/Student verso Course)
            teacher1.Courses.Add(course1);
            teacher1.Courses.Add(course3);
            teacher2.Courses.Add(course2);
            teacher2.Courses.Add(course4);

            // Iscrizione studenti (solo aggiunta da parte dello studente)
            student1.Courses.Add(course1); 
            student1.Courses.Add(course2); 
            student2.Courses.Add(course1);

            // Creazione scuola
            var school = new School
            {
                IdSchool_code = "SCH001",
                SiteName = "Axia University",
                Address = "123 Main St",
                Teachers = new List<Teacher> { teacher1, teacher2 },
                Students = new List<Student> { student1, student2 }
            };

            // Stampa studenti
            Console.WriteLine("Students at " + school.SiteName + ":");
            foreach (var student in school.GetStudents())
            {
                Console.WriteLine($"- {student.Name} {student.Surname} (ID: {student.IdStudent_code})");
            }

            // Stampa insegnanti
            Console.WriteLine("\nTeachers at " + school.SiteName + ":");
            foreach (var teacher in school.GetTeachers())
            {
                Console.WriteLine($"- {teacher.Name} {teacher.Surname} (ID: {teacher.IdTeacher_code})");
            }

            // Corsi per insegnante 
            Console.WriteLine("\nCorsi tenuti dal prof. T001 (Alessandro Bianchi):");
            foreach (var course in school.GetCoursesByTeacherId("T001"))
            {
                Console.WriteLine($"- {course.Course_Name} (ID: {course.IdCourse_code})");
            }

            // Corsi per studente (con ricerca docente tramite ID)
            Console.WriteLine("\nCorsi seguiti dallo studente S001 (Kevin Napoli):");
            foreach (var course in school.GetCoursesByStudentId("S001"))
            {
                var teacher = school.GetTeachers().FirstOrDefault(t => t.IdTeacher_code == course.IdTeacher_code);
                Console.WriteLine($"- {course.Course_Name} (Docente: {teacher?.Name} {teacher?.Surname})");
            }


        }
    }
}
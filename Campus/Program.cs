using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Campus.Model;

namespace Campus
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var students = new List<Student>
            {
                new Student("kn12345678901", "Kevin", "Napoli", "S001", new List<Course>()),
                new Student("jr23456789012", "Jessicah", "Roma", "S002", new List<Course>())
            };

            var teachers = new List<Teacher>
            {
                new Teacher("ab12345678901", "Alessandro", "Bianchi", "T001", "Mathematics", new List < Course >()),
                new Teacher("cv23456789012", "Claudia", "Verdi", "T002", "Physics", new List<Course>())
            };

            var courses = new List<Course>
            {
                new Course("C001", "Math 101", 30, "Basic Mathematics", "T001", teachers[0], new List<Student>()),
                new Course("C002", "Physics 101", 25, "Basic Physics", "T002", teachers[1], new List<Student>()),
                new Course("C003", "Chemistry 101", 20, "Basic Chemistry", "T001", teachers[0], new List<Student>()),
                new Course("C004", "Biology 101", 15, "Basic Biology", "T002", teachers[1], new List<Student>())
            };


            var school = new School("S001", "Axia University", "123 Main St", students, teachers, courses);

            var teachers = school.GetAllTeachers();


        }
    }
}

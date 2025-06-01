namespace Campus.Model
{
    internal class Course
    {
        public string IdCourse_code { get; set; }

        public string Course_Name { get; set; }

        public int MaxCapacity { get; set; }

        public string? Description { get; set; }

        public string IdTeacher_code { get; set; }
        public Teacher? Teacher { get; set; }
        public List<Student>? Students { get; set; }

        public Course()
        {
        }

        public Course(
         string idCourse_code,
         string course_Name,
         int maxCapacity,
         string? description,
         string idTeacher_code,
         Teacher? teacher,
         List<Student>? students)
        {
            IdCourse_code = idCourse_code;
            Course_Name = course_Name;
            MaxCapacity = maxCapacity;
            Description = description;
            IdTeacher_code = idTeacher_code;
            Teacher = teacher;
            Students = students ?? new List<Student>();
        }
    }
}
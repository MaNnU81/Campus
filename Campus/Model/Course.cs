namespace Campus.Model
{

        public class Course
        {
            public required string IdCourse_code { get; set; }
            public required string Course_Name { get; set; }
            public int MaxCapacity { get; set; }
            public string? Description { get; set; }
            public string IdTeacher_code { get; set; } = string.Empty; // Inizializzato qui

            // Costruttore vuoto (per serializzazione/reflection)
            public Course()
            {
                // Tutto già inizializzato sopra
            }

            // Costruttore principale con valori di default
            public Course(
                string idCourse_code,
                string course_Name,
                int maxCapacity = 0,
                string? description = null,
                string idTeacher_code = "")
            {
                IdCourse_code = idCourse_code;
                Course_Name = course_Name;
                MaxCapacity = maxCapacity;
                Description = description;
                IdTeacher_code = idTeacher_code;
            }
        }
    }

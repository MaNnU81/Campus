using Campus.Model;
using Microsoft.EntityFrameworkCore;

namespace Campus
{
    public class CampusContext : DbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=CampusDB;Username=postgres;Password=Diva");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definizione delle PRIMARY KEY per tutte le entità
            modelBuilder.Entity<School>().HasKey(s => s.IdSchool_code);
            modelBuilder.Entity<Student>().HasKey(s => s.IdStudent_code);
            modelBuilder.Entity<Teacher>().HasKey(t => t.IdTeacher_code);
            modelBuilder.Entity<Course>().HasKey(c => c.IdCourse_code);

            // Configurazione delle relazioni 1-a-Molti
            modelBuilder.Entity<School>()
                .HasMany(s => s.Teachers)
                .WithOne(t => t.School)
                .HasForeignKey(t => t.IdSchool_code)
                .OnDelete(DeleteBehavior.Cascade);  // Elimina i teacher se viene eliminata la scuola

            modelBuilder.Entity<School>()
                .HasMany(s => s.Students)
                .WithOne(s => s.School)
                .HasForeignKey(s => s.IdSchool_code)
                .OnDelete(DeleteBehavior.Cascade);  // Elimina gli studenti se viene eliminata la scuola

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Courses)
                .WithOne()
                .HasForeignKey(c => c.IdTeacher_code)
                .OnDelete(DeleteBehavior.Restrict);  // Impedisce l'eliminazione se ci sono corsi associati

            // Configurazione della relazione Many-to-Many
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "StudentCourses",
                    j => j.HasOne<Course>().WithMany().HasForeignKey("CourseId"),
                    j => j.HasOne<Student>().WithMany().HasForeignKey("StudentId"),
                    j => j.ToTable("StudentCourses"));

            // Configurazioni aggiuntive consigliate
            modelBuilder.Entity<School>()
                .Property(s => s.IdSchool_code)
                .HasMaxLength(10);  // Lunghezza massima per i codici

            modelBuilder.Entity<Course>()
                .Property(c => c.IdCourse_code)
                .HasMaxLength(10);
        }
    }
}
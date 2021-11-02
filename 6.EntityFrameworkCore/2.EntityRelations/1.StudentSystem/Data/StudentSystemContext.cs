using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }
        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {

        }


        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Homework> HomeworkSubmissions { get; set; }

        public virtual DbSet<Resource> Resources { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-7T0FTBC\SQLEXPRESS;Database=StudentSystem;Integrated Security=True");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentCourse>(x =>
            {
                x.HasKey(x => new
                {
                    x.CourseId,
                    x.StudentId
                });
            });
            modelBuilder.Entity<Student>(x =>
            {
                x.Property(x => x.Name).IsUnicode(true);
                x.Property(x => x.PhoneNumber).IsUnicode(false);
            });
            modelBuilder.Entity<Course>(x =>
            {
                x.Property(x => x.Name).IsUnicode(true);
                x.Property(x => x.Description).IsUnicode(true);
            });
            modelBuilder.Entity<Resource>(x =>
            {
                x.Property(x => x.Name).IsUnicode(true);
                x.Property(x => x.Url).IsUnicode(false);
            });
            modelBuilder.Entity<Homework>(x =>
            {
                x.ToTable("HomeworkSubmissions");
                x.Property(x => x.Content).IsUnicode(false);
            });

        }

    }
}

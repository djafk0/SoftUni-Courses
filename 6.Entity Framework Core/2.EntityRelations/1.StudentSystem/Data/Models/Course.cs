using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
            HomeworkSubmissions = new HashSet<Homework>();
            Resources = new HashSet<Resource>();
            StudentsEnrolled = new HashSet<StudentCourse>();
        }
        [Key]
        public int CourseId { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public ICollection<Homework> HomeworkSubmissions { get; set; }
               
        public ICollection<Resource> Resources { get; set; }
               
        public ICollection<StudentCourse> StudentsEnrolled { get; set; }
    }
}

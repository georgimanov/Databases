namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private ICollection<Student> students;

        private ICollection<Resource> resources;
        
        public Course()
        {
            this.students = new HashSet<Student>();
            this.resources = new HashSet<Resource>();
        }

        public int Id { get; set; }

        // [Required]
        // [MinLength(5)]
        // [MaxLength(500)]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                this.students = value;
            }
        }

        public virtual ICollection<Resource> Resources
        {
            get
            {
                return this.resources;
            }
            set
            {
                this.resources = value;
            }
        }
    }
}

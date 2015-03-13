namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        private ICollection<Course> courses;

        public int Id { get; set; }
        
        // [Required]
        // [MinLength(6)]
        // [MaxLength(100)]
        public string FullName { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public DateTime RegistrationDate { get; set; }
        
        public DateTime Birthday { get; set; }
        
        public virtual ICollection<Course> Courses
        {
            get
            {
                return this.courses;
            }
            set
            {
                this.courses = value;
            }
        }

        public Student()
        {
            this.courses = new HashSet<Course>();
        }
    } 
}

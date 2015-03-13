namespace StudentSystem.Data
{
    using System.Data.Entity;
    
    using StudentSystem.Models;

    public class StudentSystemDbContext : DbContext
    {
        public StudentSystemDbContext(string nameOrConnectionString = "Student System")
            : base(nameOrConnectionString)
        {
        }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<Resource> Resources { get; set; }

        public virtual IDbSet<Homework> Homework { get; set; }

        
    }
}

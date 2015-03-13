namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Homework
    {
        public int Id { get; set; }

        // [Required]
        public byte[] Content { get; set; }
        
        public ContentType Type { get; set; }
        
        public DateTime SubmittedOn { get; set; }
        
        public int StudentId { get; set; }
        
        public virtual Student Student { get; set; }
    }
}

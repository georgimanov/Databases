namespace StudentSystem.Models
{
    public class Resource
    {
        public int Id { get; set; }

        // [Required]
        public string Name { get; set; }
        
        public ResourceType Type { get; set; }
        
        public string Link { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }       
    }
}

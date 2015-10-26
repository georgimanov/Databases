namespace SocialNetwork.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        private ICollection<UserProfile> users;

        public Image()
        {
            this.users = new HashSet<UserProfile>();
        }

        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [MaxLength(4)]
        public string FileExtension { get; set; }

        public virtual ICollection<UserProfile> Users
        {
            get { return this.users; }
            set { this.users = value; }
        } 
    }
}

namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        private ICollection<UserProfile> users;
        public Post()
        {
            this.users = new HashSet<UserProfile>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        public string Content { get; set; }

        public DateTime PostingDate { get; set; }

        public virtual ICollection<UserProfile> TaggedUsers
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}

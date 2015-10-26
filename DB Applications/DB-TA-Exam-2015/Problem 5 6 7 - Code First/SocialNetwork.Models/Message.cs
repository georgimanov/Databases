namespace SocialNetwork.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Message
    {
        public int Id { get; set; }

        public int FriendshipId { get; set; }

        public virtual Friendship Friendship { get; set; }

        public int AuthorId { get; set; }

        public virtual UserProfile Author { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime Send { get; set; }

        public DateTime? Seen { get; set; }
    }
}

namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Friendship
    {
        private ICollection<Message> messages;

        public Friendship()
        {
            this.Approved = false;
            this.messages = new HashSet<Message>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int FirstUserId { get; set; }

        [ForeignKey("FirstUserId")]
        public virtual UserProfile FirstUser { get; set; }

        [Required]
        public int SecondUserId { get; set; }

        [ForeignKey("SecondUserId")]
        public virtual UserProfile SecondUser { get; set; }

        public bool Approved { get; set; }

        public DateTime? ApprovedOn { get; set; }

        public virtual ICollection<Message> Messages
        {
            get { return this.messages; }
            set { this.messages = value; }
        }
    }
}

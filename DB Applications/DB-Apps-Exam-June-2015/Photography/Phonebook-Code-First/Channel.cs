using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phonebook_Code_First
{
    using System.ComponentModel.DataAnnotations;

    public class Channel
    {
        public Channel()
        {
            this.ChannelMessages = new HashSet<ChannelMessage>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<ChannelMessage> ChannelMessages { get; set; }

        public virtual ICollection<User> Users { get; set; } 
    }
}

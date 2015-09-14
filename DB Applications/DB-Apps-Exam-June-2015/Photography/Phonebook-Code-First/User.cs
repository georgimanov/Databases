using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phonebook_Code_First
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Channels = new HashSet<Channel>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        public string Fullname { get; set; }

        public string Phonenumber { get; set; }

        public virtual ICollection<Channel> Channels { get; set; } 

    }
}

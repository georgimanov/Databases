using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook_Code_First
{
    using System.ComponentModel.DataAnnotations;

    //content, datetime and holds channel and user.

    public class ChannelMessage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime Datetime { get; set; }

        public int ChannelId { get; set; }

        public Channel Channel { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }


  
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook_Code_First
{
    using System.ComponentModel.DataAnnotations;

    public class UserMessage
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime Datetime { get; set; }

        public virtual User Recepient { get; set; }

        public virtual User Sender { get; set; }
    }
}

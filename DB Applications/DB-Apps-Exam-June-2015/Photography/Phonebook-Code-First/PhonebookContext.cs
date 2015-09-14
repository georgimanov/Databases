using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook_Code_First
{
    using System.Data.Entity;

    public class PhonebookContext : DbContext
    {
        public PhonebookContext()
            : base("PhonebookContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Channel> Channels  { get; set; }

        public virtual DbSet<ChannelMessage> ChannelMessages { get; set; }

        public virtual DbSet<UserMessage> UserMessages { get; set; }
    }
}

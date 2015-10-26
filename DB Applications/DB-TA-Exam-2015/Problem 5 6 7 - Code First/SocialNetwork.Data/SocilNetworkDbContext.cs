namespace SocialNetwork.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using SocialNetwork.Models;

    public class SocilNetworkDbContext : DbContext
    {
        public SocilNetworkDbContext()
            : base("SocialNetworkSystem")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public virtual IDbSet<Friendship> Friendships { get; set; }

        public virtual IDbSet<Message> Messages { get; set; }
        
        public virtual IDbSet<Post> Posts { get; set; }

        public virtual IDbSet<UserProfile> Users { get; set; }
    }
}

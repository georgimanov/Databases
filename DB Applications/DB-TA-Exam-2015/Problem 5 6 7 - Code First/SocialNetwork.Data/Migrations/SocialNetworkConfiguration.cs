namespace SocialNetwork.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class SocialNetworkConfiguration : DbMigrationsConfiguration<SocialNetwork.Data.SocilNetworkDbContext>
    {
        public SocialNetworkConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SocialNetwork.Data.SocilNetworkDbContext context)
        {
        }
    }
}

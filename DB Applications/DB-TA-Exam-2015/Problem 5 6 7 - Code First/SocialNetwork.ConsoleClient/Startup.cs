namespace SocialNetwork.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using SocialNetwork.Data;
    using SocialNetwork.Data.Migrations;

    public class Startup
    {
        public static void Main()
        {
            // Problem 5
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SocilNetworkDbContext, SocialNetworkConfiguration>());
            var db = new SocilNetworkDbContext();
            var result = db.Users.Count();
            Console.WriteLine(result);

            // Problem 6 - Friendships
            // XmlImporter.ImportFriendship();
            
            // Problem 6 - Posts
            XmlImporter.ImportPosts();
        }
    }
}

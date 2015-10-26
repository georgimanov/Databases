namespace SocialNetwork.ConsoleClient
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    using SocialNetwork.ConsoleClient.Models;
    using SocialNetwork.Data;
    using SocialNetwork.Models;
    using SocialNetwork.ConsoleClient.PostModels;

    public static class XmlImporter
    {
        public static void ImportFriendship()
        {
            var xmlQueries = Directory
                .GetFiles(Directory.GetCurrentDirectory() + "/XmlFiles/")
                .Where(f => f.EndsWith(".xml") && f.Contains("Friendships"))
                .Select(File.ReadAllText)
                .FirstOrDefault();

            var stringReader = new StringReader(xmlQueries);

            var serializer = (Friendships)new XmlSerializer(typeof(Friendships)).Deserialize(stringReader);

            Console.WriteLine("Adding friendships");

            var db = new SocilNetworkDbContext();

            var usersAlreadyInDb = db.Users.ToList();
            var addedUsers = usersAlreadyInDb.ToDictionary(user => user.UserName);

            var addedFriendships = 0;
            foreach (var friendship in serializer.Friendship)
            {
                if (!addedUsers.ContainsKey(friendship.FirstUser.Username))
                {
                    var firstUser = new UserProfile()
                    {
                        UserName = friendship.FirstUser.Username,
                        FirstName = friendship.FirstUser.LastName,
                        LastName = friendship.FirstUser.LastName,
                        RegistrationDate = friendship.FirstUser.RegisteredOn,
                    };

                    if (friendship.FirstUser.Images.Any())
                    {
                        foreach (var image in friendship.FirstUser.Images)
                        {
                            firstUser.Images.Add(new Image()
                            {
                                FileExtension = image.FileExtension,
                                ImageUrl = image.ImageUrl
                            });
                        }
                    }

                    addedUsers.Add(friendship.FirstUser.Username, firstUser);

                    db.Users.Add(firstUser);
                    db.SaveChanges();
                }

                if (!addedUsers.ContainsKey(friendship.SecondUser.Username))
                {
                    var secondUser = new UserProfile()
                    {
                        UserName = friendship.SecondUser.Username,
                        FirstName = friendship.SecondUser.LastName,
                        LastName = friendship.SecondUser.LastName,
                        RegistrationDate = friendship.SecondUser.RegisteredOn,
                    };

                    if (friendship.SecondUser.Images.Any())
                    {
                        foreach (var image in friendship.SecondUser.Images)
                        {
                            secondUser.Images.Add(new Image()
                            {
                                FileExtension = image.FileExtension,
                                ImageUrl = image.ImageUrl
                            });
                        }
                    }

                    addedUsers.Add(friendship.SecondUser.Username, secondUser);
                    db.Users.Add(secondUser);
                    db.SaveChanges();
                }

                var friendshipToAdd = new Friendship()
                {
                    Approved = friendship.Approved,
                    FirstUserId = addedUsers[friendship.FirstUser.Username].Id,
                    SecondUserId = addedUsers[friendship.SecondUser.Username].Id,
                    ApprovedOn = friendship.Approved ? friendship.FriendsSince : null,
                };

                foreach (var message in friendship.Messages)
                {
                    friendshipToAdd.Messages.Add(new Message()
                    {
                        Send = message.SentOn,
                        Seen = (message.SeenOn != null) ? message.SentOn : (DateTime?) null,
                        Content = message.Content,
                        AuthorId = addedUsers[message.Author].Id
                    });
                }

                db.Friendships.Add(friendshipToAdd);

                addedFriendships++;
                if (addedFriendships % 10 == 0)
                {
                    Console.Write(".");
                    db.SaveChanges();
                    db.Dispose();
                    db = new SocilNetworkDbContext();

                }

            }

            db.SaveChanges();
        }
        public static void ImportPosts()
        {
            var xmlQueries = Directory
                .GetFiles(Directory.GetCurrentDirectory() + "/XmlFiles/")
                .Where(f => f.EndsWith(".xml") && f.Contains("Posts-Test"))
                .Select(File.ReadAllText)
                .FirstOrDefault();

            var stringReader = new StringReader(xmlQueries);

            var serializer = (Posts)new XmlSerializer(typeof(Posts)).Deserialize(stringReader);

            Console.WriteLine("Adding posts");

            var db = new SocilNetworkDbContext();

            var usersAlreadyInDb = db.Users.ToList();
            var addedPosts = 0;
            foreach (var post in serializer.Post)
            {
                var postToAdd = new Post()
                {
                    Content = post.Content,
                    PostingDate = post.PostedOn,
                };

                var users = post.Users.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (users.Any())
                {
                    foreach (var user in users)
                    {
                        postToAdd.TaggedUsers.Add(usersAlreadyInDb.FirstOrDefault(u=>u.UserName == user));
                    }
                }

                db.Posts.Add(postToAdd);

                addedPosts++;
                if (addedPosts % 100 == 0)
                {
                    Console.Write(".");
                    db.SaveChanges();
                    db.Dispose();
                    db = new SocilNetworkDbContext();

                }
            }

            db.SaveChanges();
        }
    }
}

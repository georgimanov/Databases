namespace Phonebook_Code_First.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Phonebook_Code_First.PhonebookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PhonebookContext context)
        {
            if (!context.Users.Any())
            {

                var vGeorgiev = new User() { Username = "VGeorgiev", Fullname = "Vladimir Georgiev", Phonenumber = "0894545454" };
                var nakov = new User() { Username = "Nakov", Fullname = "Svetlin Nakov", Phonenumber = "0897878787" };
                var ache = new User() { Username = "Ache", Fullname = "Angel Georgiev", Phonenumber = "0897121212" };
                var alex = new User() { Username = "Alex", Fullname = "Alexandra Svilarova", Phonenumber = "0894151417" };
                var petya = new User() { Username = "Petya", Fullname = "Petya Grozdarska", Phonenumber = "0895464646" };

                context.Users.Add(vGeorgiev);
                context.Users.Add(nakov);
                context.Users.Add(ache);
                context.Users.Add(alex);
                context.Users.Add(petya);

                context.SaveChanges();

                var malinki = new Channel() { Name = "Malinki" };
                var softUni = new Channel() { Name = "SoftUni" };
                var admins = new Channel() { Name = "Admins" };
                var programmers = new Channel() { Name = "Programmers" };
                var geeks = new Channel() { Name = "Geeks" };

                context.Channels.Add(malinki);
                context.Channels.Add(softUni);
                context.Channels.Add(admins);
                context.Channels.Add(programmers);
                context.Channels.Add(geeks);

                context.SaveChanges();

                var now = DateTime.Now;

                var message1 = new ChannelMessage()
                {
                    ChannelId = malinki.Id,
                    Content = "Hey dudes, are you ready for tonight?",
                    Datetime = now,
                    UserId = petya.Id
                };

                var message2 = new ChannelMessage()
                {
                    ChannelId = malinki.Id,
                    Content = "Hey Petya, this is the SoftUni chat.",
                    Datetime = now,
                    UserId = vGeorgiev.Id
                };

                var message3 = new ChannelMessage()
                {
                    ChannelId = malinki.Id,
                    Content = "Hahaha, we are ready!",
                    Datetime = now,
                    UserId = nakov.Id
                };

                var message4 = new ChannelMessage()
                {
                    ChannelId = malinki.Id,
                    Content = "Oh my god. I mean for drinking beers!",
                    Datetime = now,
                    UserId = petya.Id
                };

                var message5 = new ChannelMessage()
                {
                    ChannelId = malinki.Id,
                    Content = "We are sure!",
                    Datetime = now,
                    UserId = vGeorgiev.Id
                };

                malinki.ChannelMessages.Add(message1);
                malinki.ChannelMessages.Add(message2);
                malinki.ChannelMessages.Add(message3);
                malinki.ChannelMessages.Add(message4);
                malinki.ChannelMessages.Add(message5);

                context.SaveChanges();
            }
        }
    }
}

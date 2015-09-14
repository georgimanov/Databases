using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook_Code_First
{
    using System.Data.Entity;
    using Migrations;

    class PhonebookCodeFirst
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhonebookContext, Configuration>());

            var context = new PhonebookContext();

            var channelsQuery = context.Channels.Select(ch => new
            {
                ChannelName = ch.Name,
                Messages = ch.ChannelMessages.Select(m => new
                {
                    Content = m.Content,
                    Datetime = m.Datetime,
                    User = m.User.Username
                })
            });


            foreach (var channel in channelsQuery)
            {
                Console.WriteLine(channel.ChannelName);
                Console.WriteLine("-- Messages: --");
                foreach (var message in channel.Messages)
                {
                    Console.WriteLine("Content: {0}, DateTime: {1}, User: {2}",
                        message.Content, message.Datetime, message.User);
                }

                Console.WriteLine();
            }
        }
    }
}

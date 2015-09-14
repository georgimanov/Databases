using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import_UserMessages_From_JSON
{
    using System.IO;
    using System.Web.Script.Serialization;
    using Phonebook_Code_First;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new PhonebookContext();

            var json = File.ReadAllText(@"..\..\messages.json");
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var messages = ser.Deserialize<MessageDto[]>(json);

            foreach (var messageDto in messages)
            {
                bool messagePassedValidation = true;
                List<string> errorMessages = new List<string>();
                
                if (string.IsNullOrEmpty(messageDto.Content))
                {
                    messagePassedValidation = false;
                    errorMessages.Add("Content is required");
                }

                if (string.IsNullOrEmpty(messageDto.Datetime))
                {
                    messagePassedValidation = false;
                    errorMessages.Add("Datetime is required");
                }

                if (string.IsNullOrEmpty(messageDto.Recipient))
                {
                    messagePassedValidation = false;
                    errorMessages.Add("Recipient is required");
                }

                if (string.IsNullOrEmpty(messageDto.Sender))
                {
                    messagePassedValidation = false;
                    errorMessages.Add("Sender is required");
                }

                if (messagePassedValidation)
                {
                    var userMessage = new UserMessage();

                    userMessage.Content = messageDto.Content;
                    userMessage.Datetime = DateTime.Parse(messageDto.Datetime);
                    userMessage.Sender = context.Users.FirstOrDefault(u => u.Username == messageDto.Sender);
                    userMessage.Recepient = context.Users.FirstOrDefault(u => u.Username == messageDto.Recipient);

                    context.UserMessages.Add(userMessage);
                    context.SaveChanges();

                    Console.WriteLine(@"Message ""{0}"" imported", messageDto.Content);
                }
                else
                {
                    // Print all messages
                    foreach (var errorMessage in errorMessages)
                    {
                        Console.WriteLine("Error {0}", errorMessage);
                    }

                    // Print last message
                    Console.WriteLine("Error {0}", errorMessages[errorMessages.Count - 1]);
                }
            }
        }
    }
}

namespace SocialNetwork.ConsoleClient.Models
{
    using System;
    using System.Xml.Serialization;

    [XmlType(AnonymousType = true)]
    public class FriendshipsFriendshipMessage
    {
        public string Author { get; set; }

        public string Content { get; set; }

        public DateTime SentOn { get; set; }

        [XmlElement(IsNullable = true)]
        public DateTime? SeenOn { get; set; }
    }
}

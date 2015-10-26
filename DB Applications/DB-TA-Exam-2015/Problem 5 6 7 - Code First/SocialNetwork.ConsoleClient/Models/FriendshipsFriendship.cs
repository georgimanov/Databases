namespace SocialNetwork.ConsoleClient.Models
{
    using System;
    using System.Xml.Serialization;

    [XmlType(AnonymousType = true)]
    public class FriendshipsFriendship
    {
        [XmlElement(IsNullable = true)]
        public DateTime? FriendsSince { get; set; }

        public FriendshipsFriendshipUser FirstUser { get; set; }

        public FriendshipsFriendshipUser SecondUser { get; set; }

        [XmlArrayItem("Message", IsNullable = false)]
        public FriendshipsFriendshipMessage[] Messages { get; set; }

        [XmlAttribute]
        public bool Approved { get; set; }
    }
}

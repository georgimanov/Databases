﻿namespace SocialNetwork.ConsoleClient.Models
{
    using System.Xml.Serialization;

    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Friendships
    {
        [XmlElement("Friendship")]
        public FriendshipsFriendship[] Friendship { get; set; }
    }

}

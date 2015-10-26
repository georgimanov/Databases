namespace SocialNetwork.ConsoleClient.Models
{
    using System;
    using System.Xml.Serialization;

    [XmlType(AnonymousType = true)]
    public class FriendshipsFriendshipUser
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime RegisteredOn { get; set; }

        [XmlArrayItem("Image", IsNullable = false)]
        public FriendshipsFriendshipFirstUserImage[] Images { get; set; }
    }
}

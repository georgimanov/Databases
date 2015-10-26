namespace SocialNetwork.ConsoleClient.Models
{
    using System.Xml.Serialization;

    [XmlType(AnonymousType = true)]
    public class FriendshipsFriendshipSecondUserImage
    {
        public string ImageUrl { get; set; }

        public string FileExtension { get; set; }
    }
}

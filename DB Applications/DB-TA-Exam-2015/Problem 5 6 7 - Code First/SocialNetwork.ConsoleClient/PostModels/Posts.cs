namespace SocialNetwork.ConsoleClient.PostModels
{
    using System.Xml.Serialization;

    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Posts
    {
        [XmlElement("Post")]
        public PostsPost[] Post { get; set; }
    }
}

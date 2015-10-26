namespace SocialNetwork.ConsoleClient.PostModels
{
    using System;
    using System.Xml.Serialization;

    [XmlType(AnonymousType = true)]
    public class PostsPost
    {
        public string Content { get; set; }

        public DateTime PostedOn { get; set; }

        public string Users { get; set; }
    }
}

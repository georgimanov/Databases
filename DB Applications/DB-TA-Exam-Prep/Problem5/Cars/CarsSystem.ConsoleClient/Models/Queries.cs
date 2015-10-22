namespace CarsSystem.ConsoleClient.Models
{
    using System.Xml.Serialization;

    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Queries
    {
        [XmlElement("Query")]
        public QueriesQuery[] Query { get; set; }
    }
}
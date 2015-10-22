namespace CarsSystem.ConsoleClient.Models
{
    using System.Xml.Serialization;

    [XmlType(AnonymousType = true)]
    public class QueriesQueryWhereClause
    {
        [XmlAttribute]
        public string PropertyName { get; set; }

        [XmlAttribute]
        public string Type { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}

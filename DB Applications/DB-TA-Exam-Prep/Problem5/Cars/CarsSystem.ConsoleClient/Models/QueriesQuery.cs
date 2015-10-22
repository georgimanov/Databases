namespace CarsSystem.ConsoleClient.Models
{
    using System.Xml.Serialization;

    [XmlType(AnonymousType = true)]
    public class QueriesQuery
    {
        public string OrderBy { get; set; }

        [XmlArrayItem("WhereClause", IsNullable = false)]
        public QueriesQueryWhereClause[] WhereClauses { get; set; }

        [XmlAttribute]
        public string OutputFileName { get; set; }
    }
}

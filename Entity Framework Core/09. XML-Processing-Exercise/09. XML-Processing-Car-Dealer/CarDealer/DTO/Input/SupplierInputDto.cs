namespace CarDealer.DTO.Input
{
    using System.Xml.Serialization;

    [XmlType("Supplier")]
    public class SupplierInputDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("isImporter")]
        public bool IsImporter { get; set; }
    }
}


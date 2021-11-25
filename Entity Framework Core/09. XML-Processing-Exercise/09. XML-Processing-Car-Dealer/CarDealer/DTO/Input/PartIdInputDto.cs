namespace CarDealer.DTO.Input
{
    using System.Xml.Serialization;

    [XmlType("partId")]
    public class PartIdInputDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}

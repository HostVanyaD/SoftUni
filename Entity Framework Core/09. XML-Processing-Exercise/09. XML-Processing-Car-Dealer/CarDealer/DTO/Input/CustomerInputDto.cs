namespace CarDealer.DTO.Input
{
    using System.Xml.Serialization;

    [XmlType("Customer")]
    public class CustomerInputDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("birthDate")]
        public string BirthDate { get; set; } //DateTime???

        [XmlElement("isYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}

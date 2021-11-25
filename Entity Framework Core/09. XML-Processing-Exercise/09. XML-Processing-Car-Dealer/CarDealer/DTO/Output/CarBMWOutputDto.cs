namespace CarDealer.DTO.Output
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class CarBMWOutputDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}

namespace CarDealer.DTO.Input
{
    using System.Xml.Serialization;

    [XmlType("Car")]
    public class CarInputDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TraveledDistance { get; set; }

        [XmlArray("parts")]
        public PartIdInputDto[] Parts { get; set; }
    }
}

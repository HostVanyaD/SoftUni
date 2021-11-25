namespace CarDealer.DTO.Output
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class CarWithPartsOutputDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public PartOfCarOutputDto[] Parts { get; set; }
    }

    [XmlType("part")]
    public class PartOfCarOutputDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}

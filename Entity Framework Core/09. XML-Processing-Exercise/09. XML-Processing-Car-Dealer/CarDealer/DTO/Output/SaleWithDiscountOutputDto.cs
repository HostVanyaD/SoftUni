namespace CarDealer.DTO.Output
{
    using System.Xml.Serialization;

    [XmlType("sale")]
    public class SaleWithDiscountOutputDto
    {
        [XmlElement("car")]
        public CarWithDiscountOutputDto Car { get; set; }

        [XmlElement("discount")]
        public decimal Discount { get; set; }

        [XmlElement("customer-name")]
        public string CustomerName { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
        
        [XmlElement("price-with-discount")]
        public decimal PriceWithDiscount { get; set; }
    }

    public class CarWithDiscountOutputDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}

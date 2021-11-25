namespace CarDealer.DTO.Output
{
    using System.Xml.Serialization;

    [XmlType("customer")]
    public class CustomerWithTotalSalesOutputDto
    {
        [XmlAttribute("full-name")]
        public string FullName { get; set; }
        
        [XmlAttribute("bought-cars")]
        public int BoughtCars { get; set; }
        
        [XmlAttribute("spent-money")]
        public decimal SpentMoney { get; set; }

    }
}

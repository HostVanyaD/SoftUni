namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    public class UsersCountOutput
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public OutputUserDto[] Users { get; set; }
    }

    [XmlType("User")]
    public class OutputUserDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlElement("SoldProducts")]
        public OutputProductCountDto SoldProduct { get; set; }
    }

    public class OutputProductCountDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public OuputProductDto[] Products { get; set; }
    }

    [XmlType("Product")]
    public class OuputProductDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}

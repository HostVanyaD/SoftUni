namespace ProductShop.Dtos.Export
{
    using System.Linq;
    using System.Xml.Serialization;

    [XmlType("SoldProducts")]
    public class SoldProductsOutputModel
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlElement("products")]
        public UserProductOutputModel[] SoldProducts { get; set; }
    }
}

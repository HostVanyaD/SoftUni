namespace ProductShop.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlType("CategoryProduct")]
    public class CategoryProductInputModel
    {
        public int CategoryId { get; set; }

        public int ProductId { get; set; }
    }
}

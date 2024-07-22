namespace ECommerce.Catalog.Entities
{
    public class ProductImages
    {
        public string ProductImagesId { get; set; }
        public string Images1 { get; set; }
        public string Images2 { get; set; }
        public string Images3 { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}

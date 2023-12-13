namespace ecommerce_web_api.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set;}
        public Category? Category { get; set; }

    }
}

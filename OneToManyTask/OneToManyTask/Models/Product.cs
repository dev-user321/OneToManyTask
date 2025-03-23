namespace OneToManyTask.Models
{
    public class Product : BaseEntity
    {
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public List<ProductImage> Images { get; set; }
    }
}

namespace OneToManyTask.Models
{
    public class ProductImage : BaseEntity
    {
        public int ProductId { get; set; }
        public string ImageLink { get; set; }
        public bool IsMain { get; set; }
    }
}

namespace OneToManyTask.Models
{
    public class FlowerExpert : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; } 
        public List<Expert> Experts { get; set; }
    }
}

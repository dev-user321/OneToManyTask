namespace OneToManyTask.Models
{
    public class Valentine : BaseEntity
    {
        public string ImgUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public List<ValentineTask > Tasks { get; set; } 
    }
}

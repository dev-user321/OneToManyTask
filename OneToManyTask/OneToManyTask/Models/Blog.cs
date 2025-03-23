namespace OneToManyTask.Models
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }

        public string Time = "29.12.2019";
    }
}

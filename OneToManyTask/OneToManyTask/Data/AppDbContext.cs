using Microsoft.EntityFrameworkCore;
using OneToManyTask.Models;

namespace OneToManyTask.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<SliderImage> SliderImages { get; set; }
        public DbSet<SliderText> SliderTexts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Valentine> Valentines { get; set; }
        public DbSet<ValentineTask> ValentineTasks { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<FlowerExpert> FlowerExperts { get;set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}

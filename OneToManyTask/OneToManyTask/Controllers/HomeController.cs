using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneToManyTask.Data;
using OneToManyTask.Models;
using OneToManyTask.ViewModels;

namespace OneToManyTask.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var sliderImages = await _context.SliderImages
                .Where(m => !m.IsDeleted)
                .ToListAsync();

            var sliderText = await _context.SliderTexts
                .FirstOrDefaultAsync(m => !m.IsDeleted);

            var products = await _context.Products
                .Where(m => !m.IsDeleted)
                .Take(4)
                .ToListAsync();

            var productImages = await _context.ProductImages
                .Where(m => !m.IsDeleted)
                .ToListAsync();

            var categories = await _context.Categories
                .Where(m => !m.IsDeleted)
                .ToListAsync();

            foreach (var product in products)
            {
                product.Images = productImages
                    .Where(img => img.ProductId == product.Id)
                    .ToList();
            }

            var valentineTasks = await _context.ValentineTasks
                .Where(m => !m.IsDeleted)
                .ToListAsync();

            var valentine = await _context.Valentines
                .Where(m => !m.IsDeleted)
                .FirstOrDefaultAsync();
            
            valentine.Tasks = valentineTasks.Where(m=>m.ValentineId == valentine.Id).ToList();   

            var flowerExperts = await _context.FlowerExperts
                .Where(m => !m.IsDeleted)   
                .FirstOrDefaultAsync();
            flowerExperts.Experts = _context.Experts.ToList();

            var blogs = await _context.Blogs
                .Where(m => !m.IsDeleted)
                .ToListAsync();
            
            var homeVM = new HomeVM
            {
                SliderImages = sliderImages.ToList(),
                SliderText = sliderText,
                Products = products.ToList(),
                Categories = categories.ToList(),
                Valent = valentine,
                FlowerExpert = flowerExperts,
                Blogs = blogs,
            };

            return View(homeVM);
        }



    }
}

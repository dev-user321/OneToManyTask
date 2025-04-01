using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneToManyTask.Data;
using OneToManyTask.Models;

namespace OneToManyTask.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories
                .Where(m=>m.IsDeleted == false)
                .ToListAsync();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            //if (!ModelState.IsValid)
            //{
            //    return RedirectToAction("Index");
            //}

            var existedCategory = await _context.Categories
                .AnyAsync(m => m.Name.Trim().ToLower() == category.Name.Trim().ToLower());

            if (existedCategory)
            {
                ViewBag.ErrMessage = "Bu category artıq mövcuddur!";
                return View();
            }

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");


        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneToManyTask.Data;

namespace OneToManyTask.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Where(m => m.IsDeleted == false)
                .Include(m=>m.Images)
                .Take(4)
                .ToListAsync();
            return View(products);
        }

        public async Task<IActionResult> LoadMore(int count)
        {
            ViewBag.count = await _context.Products.CountAsync();
            var products = await _context.Products
                .Where (m => m.IsDeleted == false)
                .Include(m=>m.Images)
                .Skip(count)
                .Take(4)
                .ToListAsync();
            return PartialView("_PartialView",products);
        }
    }
}

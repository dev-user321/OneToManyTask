using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneToManyTask.Data;

namespace OneToManyTask.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class TableController : Controller
    {
        private readonly AppDbContext _context;
        public TableController(AppDbContext context)
        {
            _context = context;            
        }
        public async Task<IActionResult> Index()
        {
            var sliderImages = await _context.SliderImages
                .Where(m=>m.IsDeleted == false)
                .ToListAsync();
            return View(sliderImages);
        }
        public IActionResult Create()
        {
            return View();  
        }
    }
}

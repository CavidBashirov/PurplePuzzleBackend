using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PB102App.Data;
using PB102App.ViewModels;

namespace PB102App.Controllers
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
            return View(new HomeVM
            {
                Works = await _context.Works.Include(m => m.Images).ToListAsync(),
                Categories = await _context.Categories.Where(m => m.Works.Count != 0).ToListAsync(),
            });
        } 
    }
}

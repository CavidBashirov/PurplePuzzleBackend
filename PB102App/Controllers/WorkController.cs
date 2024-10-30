using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PB102App.Data;
using PB102App.Models;

namespace PB102App.Controllers
{
    public class WorkController : Controller
    {
        private readonly AppDbContext _context;

        public WorkController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Work> works = await _context.Works.Include(m=>m.Images).Take(3).ToListAsync();
            return View(works);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();
            Work work = await _context.Works.Include(m=>m.Category).Include(m=>m.Images).FirstOrDefaultAsync(m => m.Id == id);

            if (work is null) return NotFound();
            return View(work);
        }

        public async Task<IActionResult> ShowMore(int skip)
        {
            List<Work> works = await _context.Works.Include(m => m.Images).Skip(skip).Take(3).ToListAsync();
            return PartialView("_WorkPartial", works);
        }
    }
}

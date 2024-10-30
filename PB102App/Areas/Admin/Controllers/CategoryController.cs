using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PB102App.Data;
using PB102App.Models;

namespace PB102App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> categories = await _context.Categories.OrderByDescending(m=>m.Id).ToListAsync();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            Category category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);

            if (category is null) return NotFound();

            return View(category);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            bool hasCategory = await _context.Categories.AnyAsync(m => m.Name.Trim() == category.Name.Trim());

            if (hasCategory)
            {
                ModelState.AddModelError("Name", "Category already exist");
                return View();
            }

            await _context.Categories.AddAsync(new Category { Name = category.Name });
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Category existProduct = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);
            _context.Categories.Remove(existProduct);
            await _context.SaveChangesAsync();
            return Ok(id);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            Category category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);

            if (category is null) return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Category category)
        {
            if (id is null) return BadRequest();

            Category existCategory = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);

            if (existCategory is null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View();
            }

            bool hasCategory = await _context.Categories.AnyAsync(m => m.Name.Trim() == category.Name.Trim() && m.Id !=id);

            if (hasCategory)
            {
                ModelState.AddModelError("Name", "Category already exist");
                return View();
            }

            existCategory.Name = category.Name;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PB102App.Data;
using PB102App.Models;
using PB102App.ViewModels.Admin.Slider;
using System.IO;

namespace PB102App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderImageController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderImageController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.SliderImages.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            SliderImage sliderImage = await _context.SliderImages.FirstOrDefaultAsync(m => m.Id == id);

            if (sliderImage is null) return NotFound();

            return View(sliderImage);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderImage request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            foreach (var item in request.Photos)
            {
                string fileName = Guid.NewGuid().ToString() + "_" + item.FileName;

                string path = Path.Combine(_env.WebRootPath, "assets/img", fileName);

                using (FileStream stream = new(path, FileMode.Create))
                {
                    await item.CopyToAsync(stream);
                }

                await _context.SliderImages.AddAsync(new SliderImage { Image = fileName });

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var sliderImage = await _context.SliderImages.FindAsync(id);

            string existPath = Path.Combine(_env.WebRootPath, "assets/img", sliderImage.Image);

            DeleteFile(existPath);

            _context.SliderImages.Remove(sliderImage);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            SliderImage sliderImage = await _context.SliderImages.FirstOrDefaultAsync(m => m.Id == id);

            if (sliderImage is null) return NotFound();

            return View(new SliderImageEditVM { Image = sliderImage.Image, Id = sliderImage.Id});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, SliderImageEditVM request)
        {
            if (id is null) return BadRequest();

            SliderImage sliderImage = await _context.SliderImages.FirstOrDefaultAsync(m => m.Id == id);

            if (sliderImage is null) return NotFound();

            if(request.Photo != null)
            {
                string existPath = Path.Combine(_env.WebRootPath, "assets/img", sliderImage.Image);
                DeleteFile(existPath);

                string newFileName = Guid.NewGuid().ToString() + "_" + request.Photo.FileName;
                string newPath = Path.Combine(_env.WebRootPath, "assets/img", newFileName);

                using (FileStream stream = new(newPath, FileMode.Create))
                {
                    await request.Photo.CopyToAsync(stream);
                }

                sliderImage.Image = newFileName;

                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeMainStatus(int id)
        {
            SliderImage sliderImage = await _context.SliderImages.FirstOrDefaultAsync(m => m.Id == id);
            sliderImage.IsMain = true;
            var updatedSliderImageStatus = await _context.SliderImages.FirstOrDefaultAsync(m => m.Id != id && m.IsMain);
            updatedSliderImageStatus.IsMain = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private void DeleteFile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }

    }
}

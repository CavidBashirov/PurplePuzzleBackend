using Microsoft.AspNetCore.Mvc;
using PB102App.Data;
using PB102App.Services.Interfaces;

namespace PB102App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _sliderService.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();
            var slider = await _sliderService.GetByIdAsync((int)id);
            if (slider is null) return NotFound();
            return View(slider);
        }
    }
}

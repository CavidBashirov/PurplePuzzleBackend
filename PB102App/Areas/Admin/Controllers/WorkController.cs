using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PB102App.Data;
using PB102App.Services.Interfaces;

namespace PB102App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WorkController : Controller
    {
        private readonly IWorkService _workService;

        public WorkController(IWorkService workService)
        {
            _workService = workService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _workService.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            var work = await _workService.GetByIdAsync((int)id);

            if (work is null) return NotFound();

            return View(work);
        }
    }
}

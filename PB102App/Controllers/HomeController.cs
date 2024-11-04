using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PB102App.Data;
using PB102App.ViewModels;

namespace PB102App.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public HomeController(AppDbContext context,
                              IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;

        }

        public async Task<IActionResult> Index() 
        {
            return View(new HomeVM
            {
                Works = await _context.Works.Include(m => m.Images).ToListAsync(),
                Categories = await _context.Categories.Where(m => m.Works.Count != 0).ToListAsync(),
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkToBasket(int id)
        {
            List<BasketVM> basket;

            if (_httpContext.HttpContext.Request.Cookies["basket"] != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketVM>>(_httpContext.HttpContext.Request.Cookies["basket"]);
            }
            else
            {
                basket = new List<BasketVM>();
            }

            var existBasketData = basket.FirstOrDefault(m=>m.WorkId == id);

            if(existBasketData is null)
            {
                basket.Add(new BasketVM
                {
                    WorkId = id,
                    WorkCount = 1
                });
            }
            else
            {
                existBasketData.WorkCount++;
            }

            _httpContext.HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));

            return Ok(basket.Sum(m=>m.WorkCount));
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace PB102App.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

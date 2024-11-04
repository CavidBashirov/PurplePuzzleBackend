using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PB102App.Services.Interfaces;
using PB102App.ViewModels;

namespace PB102App.ViewCompnents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ILayoutService _layoutService;
        private readonly IHttpContextAccessor _httpContext;

        public HeaderViewComponent(ILayoutService layoutService,
                                   IHttpContextAccessor httpContext)
        {
            _layoutService = layoutService;
            _httpContext = httpContext;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View(new HeaderVM
            {
                Settings = await _layoutService.GetAllSettingsAsync(),
                BasketCount = GetBasketCount()
            })); ;
        }

        private int GetBasketCount()
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

            return basket.Sum(m => m.WorkCount);
        }
    }
}

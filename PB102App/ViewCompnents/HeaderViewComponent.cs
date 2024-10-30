using Microsoft.AspNetCore.Mvc;
using PB102App.Services.Interfaces;

namespace PB102App.ViewCompnents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ILayoutService _layoutService;

        public HeaderViewComponent(ILayoutService layoutService)
        {
            _layoutService = layoutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View(await _layoutService.GetAllSettingsAsync()));
        }
    }
}

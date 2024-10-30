using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PB102App.Services.Interfaces;
using PB102App.ViewModels;

namespace PB102App.ViewCompnents
{
    public class SliderViewcomponent : ViewComponent
    {
        private readonly ISliderService _sliderService;
        private readonly ISliderImageService _sliderImageService;

        public SliderViewcomponent(ISliderService sliderService,
                                   ISliderImageService sliderImageService)
        {
            _sliderService = sliderService;
            _sliderImageService = sliderImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View(new SliderHomeVM
            {
                Sliders = await _sliderService.GetAllAsync(),
                SliderImage = await _sliderImageService.GetAsync()
            }));
        }
    }
}

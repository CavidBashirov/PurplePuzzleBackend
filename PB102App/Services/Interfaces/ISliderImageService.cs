using PB102App.Models;
using PB102App.ViewModels.Admin.Slider;

namespace PB102App.Services.Interfaces
{
    public interface ISliderImageService
    {
        Task<SliderImageVM> GetAsync();
    }
}

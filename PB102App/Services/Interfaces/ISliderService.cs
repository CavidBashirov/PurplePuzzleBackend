using PB102App.Models;
using PB102App.ViewModels.Admin.Slider;

namespace PB102App.Services.Interfaces
{
    public interface ISliderService
    {
        Task CreateAsync(Slider slider);
        Task<List<SliderVM>> GetAllAsync();
        Task<SliderVM> GetByIdAsync(int id);
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PB102App.Data;
using PB102App.Services.Interfaces;
using PB102App.ViewModels.Admin.Slider;

namespace PB102App.Services
{
    public class SliderImageService : ISliderImageService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SliderImageService(AppDbContext context,
                                  IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SliderImageVM> GetAsync()
        {
            return _mapper.Map<SliderImageVM>(await _context.SliderImages.FirstOrDefaultAsync(m => m.IsMain));
        }
    }
}

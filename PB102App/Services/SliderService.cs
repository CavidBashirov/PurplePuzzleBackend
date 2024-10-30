using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PB102App.Data;
using PB102App.Models;
using PB102App.Services.Interfaces;
using PB102App.ViewModels.Admin.Slider;

namespace PB102App.Services
{
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SliderService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(Slider slider)
        {
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SliderVM>> GetAllAsync()
        {
            return _mapper.Map<List<SliderVM>>(await _context.Sliders.ToListAsync());
        }

        public async Task<SliderVM> GetByIdAsync(int id)
        {
            return _mapper.Map<SliderVM>(await _context.Sliders.FindAsync(id));
        }
    }
}

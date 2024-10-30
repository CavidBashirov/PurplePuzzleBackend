using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PB102App.Data;
using PB102App.Services.Interfaces;
using PB102App.ViewModels.Admin.Work;

namespace PB102App.Services
{
    public class WorkService : IWorkService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public WorkService(AppDbContext context,
                           IMapper mapper)
        {
            _context = context;    
            _mapper = mapper;
        }

        public async Task<IEnumerable<WorkVM>> GetAllAsync()
        {
            var works = await _context.Works.Include(m => m.Category)
                                            .Include(m => m.Images)
                                            .ToListAsync();

            return _mapper.Map<IEnumerable<WorkVM>>(works);
        }

        public async Task<SingleWorkVM> GetByIdAsync(int id)
        {
            var work = await _context.Works.Include(m => m.Category)
                                       .Include(m => m.Images)
                                       .FirstOrDefaultAsync(m=>m.Id == id);

            return _mapper.Map<SingleWorkVM>(work);
        }
    }
}

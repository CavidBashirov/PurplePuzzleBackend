using Microsoft.EntityFrameworkCore;
using PB102App.Data;
using PB102App.Services.Interfaces;

namespace PB102App.Services
{
    public class LayoutService : ILayoutService
    {
        private readonly AppDbContext _context;

        public LayoutService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<string, string>> GetAllSettingsAsync()
        {
            return await _context.Settings.ToDictionaryAsync(m => m.Key, m => m.Value);
        }
    }
}

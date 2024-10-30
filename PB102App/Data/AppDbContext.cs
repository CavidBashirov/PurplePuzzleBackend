using Microsoft.EntityFrameworkCore;
using PB102App.Models;

namespace PB102App.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Work> Works { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderImage> SliderImages { get; set; }
        public DbSet<WorkImage> WorkImages { get; set; }
        public DbSet<Setting> Settings { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option) { }
    }
}

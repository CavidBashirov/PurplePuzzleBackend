using PB102App.Models;

namespace PB102App.ViewModels.Admin.Work
{
    public class WorkVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string MainImage { get; set; }
    }
}

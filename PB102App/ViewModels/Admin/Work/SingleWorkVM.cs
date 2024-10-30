using PB102App.Models;

namespace PB102App.ViewModels.Admin.Work
{
    public class SingleWorkVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<WorkImage> Images { get; set; }
        public string CategoryName { get; set; }

    }
}

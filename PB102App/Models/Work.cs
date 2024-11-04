namespace PB102App.Models
{
    public class Work
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public decimal? Price { get; set; }
        public ICollection<WorkImage> Images { get; set; }
    }
}

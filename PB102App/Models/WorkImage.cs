namespace PB102App.Models
{
    public class WorkImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public bool IsMain { get; set; }
        public int WorkId { get; set; }
        public Work Work { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PB102App.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public ICollection<Work> Works { get; set; }

    }
}

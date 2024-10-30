using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PB102App.Models
{
    public class SliderImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public bool IsMain { get; set; } = false;
        [NotMapped]
        [Required]
        public List<IFormFile> Photos { get; set; }
    }
}

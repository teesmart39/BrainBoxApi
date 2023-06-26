using System.ComponentModel.DataAnnotations;

namespace BrainBoxAPI.DTO
{
    public class UpdateProductDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public double Cost { get; set; }
        [Required]
        public string Category { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace DB.ViewModels
{
    public class ProductRequest
    {
        [MaxLength(50)]
        [Required]
        public string? Name { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }

        [Range(1, 100)]
        public int AgeRestriction { get; set; }

        [Range(1, 1000)]
        [Required]
        public decimal Price { get; set; }

        public int CompanyId { get; set; }
    }
}

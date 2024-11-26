using System.ComponentModel.DataAnnotations;

namespace OnlineMarket.Service.DTOs.Products
{
    public class ProductCreationDto
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be a non-negative value")]
        public int Stock { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}

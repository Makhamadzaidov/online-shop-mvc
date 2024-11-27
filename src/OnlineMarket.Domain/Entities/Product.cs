using OnlineMarket.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace OnlineMarket.Domain.Entities
{
    public class Product : Auditable
    {
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? Stock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string? ImagePath { get; set; }
    }
}

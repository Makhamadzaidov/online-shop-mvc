using OnlineMarket.Domain.Commons;

namespace OnlineMarket.Domain.Entities
{
    public class Category : Auditable
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

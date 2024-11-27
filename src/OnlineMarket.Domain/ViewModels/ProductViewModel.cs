using OnlineMarket.Domain.Entities;

namespace OnlineMarket.Domain.ViewModels
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? Stock { get; set; }
        public string CategoryName { get; set; }
        public string? Image { get; set; }

        public static implicit operator ProductViewModel(Product product)
        {
            return new ProductViewModel()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Image = product.ImagePath,
                Stock = product.Stock,
                CategoryName = product.Category.Name,
            };
        }
    }
}

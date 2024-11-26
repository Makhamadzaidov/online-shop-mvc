using OnlineMarket.Domain.Entities;
using OnlineMarket.Service.Commons.Utils;
using OnlineMarket.Service.DTOs.Products;
using System.Linq.Expressions;

namespace OnlineMarket.Service.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateAsync(ProductCreationDto product);
        Task<IEnumerable<ProductViewDto>> GetAllAsync(Expression<Func<Product, bool>> expression = null, PaginationParams? @params = null);
    }
}

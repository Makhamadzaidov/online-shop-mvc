using OnlineMarket.Domain.Entities;
using OnlineMarket.Domain.Utils;
using OnlineMarket.Domain.ViewModels;
using OnlineMarket.Service.DTOs.Products;
using System.Linq.Expressions;

namespace OnlineMarket.Service.Interfaces
{
    public interface IProductService
    {
        /*Task<Product> CreateAsync(ProductCreationDto product);
        Task<IEnumerable<ProductViewDto>> GetAllAsync(Expression<Func<Product, bool>> expression = null, PaginationParams? @params = null);*/

        Task<IEnumerable<ProductViewModel>> GetAllProducts(PaginationParams @params);
    }
}

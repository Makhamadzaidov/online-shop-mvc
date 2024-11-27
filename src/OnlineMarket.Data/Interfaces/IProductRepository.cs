using OnlineMarket.Data.Commons;
using OnlineMarket.Domain.Entities;
using OnlineMarket.Domain.Utils;
using OnlineMarket.Domain.ViewModels;

namespace OnlineMarket.Data.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<PagedList<ProductViewModel>> GetAllByProductIdAsync(int productId, PaginationParams @params);
    }
}

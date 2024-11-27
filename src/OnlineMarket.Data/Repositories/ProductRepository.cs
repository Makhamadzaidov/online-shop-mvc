using Microsoft.EntityFrameworkCore;
using OnlineMarket.Data.Commons;
using OnlineMarket.Data.DbContexts;
using OnlineMarket.Data.Interfaces;
using OnlineMarket.Domain.Entities;
using OnlineMarket.Domain.Utils;
using OnlineMarket.Domain.ViewModels;

namespace OnlineMarket.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<PagedList<ProductViewModel>> GetAllByProductIdAsync(int productId, PaginationParams @params)
        {
            var productViews = _dbSet.Where(products => products.Id == productId).Include(p => p.Category).Select(p => (ProductViewModel)p);
            return await PagedList<ProductViewModel>.ToPagedListAsync(productViews, @params.PageNumber, @params.PageSize);
        }
    }
}

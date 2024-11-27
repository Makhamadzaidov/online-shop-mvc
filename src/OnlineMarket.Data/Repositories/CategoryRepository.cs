using OnlineMarket.Data.DbContexts;
using OnlineMarket.Data.Interfaces;
using OnlineMarket.Domain.Entities;

namespace OnlineMarket.Data.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}

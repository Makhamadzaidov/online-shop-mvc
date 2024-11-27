using OnlineMarket.Data.DbContexts;
using OnlineMarket.Data.Interfaces;
using OnlineMarket.Domain.Entities;

namespace OnlineMarket.Data.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }
    }
}

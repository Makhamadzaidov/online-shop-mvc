using OnlineMarket.Data.DbContexts;
using OnlineMarket.Data.Interfaces;
using OnlineMarket.Domain.Entities;

namespace OnlineMarket.Data.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {

        }
    }
}

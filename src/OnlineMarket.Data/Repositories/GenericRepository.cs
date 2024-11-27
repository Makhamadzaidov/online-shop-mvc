using Microsoft.EntityFrameworkCore;
using OnlineMarket.Data.DbContexts;
using OnlineMarket.Data.Interfaces;
using System.Linq.Expressions;

namespace OnlineMarket.Data.Repositories
{
    public class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : class
    {
        private protected DbSet<TSource> _dbSet;
        public GenericRepository(AppDbContext context)
        {
            _dbSet = context.Set<TSource>();
        }
        public async Task<TSource> CreateAsync(TSource source)
            => (await _dbSet.AddAsync(source)).Entity;

        public Task DeleteAsync(TSource source)
            => Task.FromResult(_dbSet.Remove(source));

        public IQueryable<TSource> GetAllAsync(Expression<Func<TSource, bool>>? expression = null, bool isTracking = true)
        {
            var sources = expression is null ? _dbSet : _dbSet.Where(expression);

            return isTracking ? sources : sources.AsNoTracking();
        }

        public async Task<TSource?> GetAsync(Expression<Func<TSource, bool>> expression)
            => await _dbSet.FirstOrDefaultAsync(expression);

        public Task<TSource> UpdateAsync(TSource source)
        {
            throw new NotImplementedException();
        }
    }
}

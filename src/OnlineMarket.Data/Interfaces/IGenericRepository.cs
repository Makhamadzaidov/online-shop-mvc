using System.Linq.Expressions;

namespace OnlineMarket.Data.Interfaces
{
    public interface IGenericRepository<TSource> where TSource : class
    {
        Task<TSource> CreateAsync(TSource source);
        Task<TSource> UpdateAsync(TSource source);
        Task DeleteAsync(TSource source);
        Task<TSource?> GetAsync(Expression<Func<TSource, bool>> expression);
        IQueryable<TSource> GetAllAsync(Expression<Func<TSource, bool>>? expression = null, bool isTracking = true);
    }
}

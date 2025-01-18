using System.Linq.Expressions;

namespace ClinicalTrials.Contracts.Data.Repositories;

public interface IRepository<T>
{
    Task<T?> GetAsync(long id);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, int skipCount, int takeCount,
        Expression<Func<T, object>> orderBy, bool isDescending = false);
    Task AddAsync(T entity);
    Task<int> CountAsync(Expression<Func<T, bool>> predicate);
}
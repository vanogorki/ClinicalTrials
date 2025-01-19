using System.Linq.Expressions;

namespace ClinicalTrials.Application.Common.Interfaces;

public interface IRepository<T>
{
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, int skipCount, int takeCount,
        Expression<Func<T, object>> orderBy, bool isDescending = false);
    Task AddAsync(T entity);
    Task<int> CountAsync(Expression<Func<T, bool>> predicate);
}
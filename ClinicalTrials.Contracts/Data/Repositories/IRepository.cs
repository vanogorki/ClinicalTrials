namespace ClinicalTrials.Contracts.Data.Repositories;

public interface IRepository<T>
{
    Task<T?> GetAsync(long id);
    Task AddAsync(T entity);
}
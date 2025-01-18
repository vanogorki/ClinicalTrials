using System.Linq.Expressions;
using ClinicalTrials.Contracts.Data.Repositories;
using ClinicalTrials.Migrations;
using Microsoft.EntityFrameworkCore;

namespace ClinicalTrials.Infrastructure.Data.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DatabaseContext _context;
    private readonly DbSet<T> _dbSet;

    protected Repository(DatabaseContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    
    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.CountAsync(predicate);
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, int skipCount, int takeCount,
        Expression<Func<T, object>> orderBy, bool isDescending = false)
    {
        if (isDescending)
            return await _dbSet.Where(predicate)
                .OrderByDescending(orderBy)
                .Skip(skipCount)
                .Take(takeCount)
                .ToListAsync();
        return await _dbSet.Where(predicate)
            .OrderBy(orderBy)
            .Skip(skipCount)
            .Take(takeCount)
            .ToListAsync();
    }

    public async Task<T?> GetAsync(long id)
    {
        var x = await _dbSet.FindAsync(id);
        return x;
    }
}
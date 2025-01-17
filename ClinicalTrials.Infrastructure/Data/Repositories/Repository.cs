using ClinicalTrials.Contracts.Data.Repositories;
using ClinicalTrials.Migrations;
using Microsoft.EntityFrameworkCore;

namespace ClinicalTrials.Infrastructure.Data.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DatabaseContext _context;
    // private protected readonly DbSet<T> DbSet;
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

    public async Task<T?> GetAsync(long id)
    {
        var x = await _dbSet.FindAsync(id);
        return x;
    }
}
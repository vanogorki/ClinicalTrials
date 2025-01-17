using ClinicalTrials.Contracts.Data.Entities;
using ClinicalTrials.Contracts.Data.Entities.Base;
using ClinicalTrials.Contracts.Enum;
using Microsoft.EntityFrameworkCore;

namespace ClinicalTrials.Migrations;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public DbSet<ClinicalTrial> ClinicalTrials { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClinicalTrial>()
            .Property(e => e.Participants)
            .HasDefaultValue(1);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var item in ChangeTracker.Entries<BaseEntity>().AsEnumerable())
            switch (item.State)
            {
                case EntityState.Added:
                    item.Entity.Created = DateTime.UtcNow;
                    item.Entity.EntityStatus = EntityStatus.Active;
                    break;
                case EntityState.Modified:
                    item.Entity.LastModified = DateTime.UtcNow;
                    break;
                case EntityState.Detached:
                case EntityState.Unchanged:
                case EntityState.Deleted:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        
        return base.SaveChangesAsync(cancellationToken);
    }
}
using ClinicalTrials.Domain.Repositories;

namespace ClinicalTrials.Persistence.Repositories;

public sealed class UnitOfWork(DatabaseContext context) : IUnitOfWork
{
    public IClinicalTrialRepository ClinicalTrialRepository => new ClinicalTrialRepository(context);

    public async Task CommitAsync()
    {
        await context.SaveChangesAsync();
    }
}
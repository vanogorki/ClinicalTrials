using ClinicalTrials.Application.Common.Interfaces;
using ClinicalTrials.Persistence.Data.Repositories;

namespace ClinicalTrials.Persistence.Data;

public sealed class UnitOfWork(DatabaseContext context) : IUnitOfWork
{
    public IClinicalTrialRepository ClinicalTrialRepository => new ClinicalTrialRepository(context);

    public async Task CommitAsync()
    {
        await context.SaveChangesAsync();
    }
}
using ClinicalTrials.Contracts.Data;
using ClinicalTrials.Contracts.Data.Repositories;
using ClinicalTrials.Infrastructure.Data.Repositories;
using ClinicalTrials.Migrations;

namespace ClinicalTrials.Infrastructure.Data;

public class UnitOfWork(DatabaseContext context) : IUnitOfWork
{
    public IClinicalTrialRepository ClinicalTrialRepository => new ClinicalTrialRepository(context);

    public async Task CommitAsync()
    {
        await context.SaveChangesAsync();
    }
}
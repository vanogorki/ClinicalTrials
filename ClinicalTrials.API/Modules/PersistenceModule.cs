using ClinicalTrials.Domain.Repositories;
using ClinicalTrials.Persistence;
using ClinicalTrials.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicalTrials.API.Modules;

internal static class PersistenceModule
{
    internal static void AddPersistenceModule(this WebApplicationBuilder builder)
    {
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        builder.Services.AddDbContext<DatabaseContext>(options =>
            options.UseNpgsql(connectionString));
        
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
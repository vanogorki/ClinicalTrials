using ClinicalTrials.Contracts.Data;
using ClinicalTrials.Contracts.Services;
using ClinicalTrials.Infrastructure.Data;
using ClinicalTrials.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicalTrials.Infrastructure;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddServices();
        services.AddUnitOfWork();

        return services;
    }
    
    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IClinicalTrialsService, ClinicalTrialsService>();

        return services;
    }
    
    private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        return services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
    
    // private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    // {
    //     return services.AddUnitOfWork();
    // }
    
    // private static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
    // {
    //     var connectionString = configuration.GetConnectionString("DBConnection");
    //     Environment.SetEnvironmentVariable("DBConnection", connectionString);
    //
    //     // use this for local database connection
    //     // return services.AddSqlServer<DatabaseContext>("YourConnectionString",
    //     return services.AddSqlServer<DatabaseContext>(connectionString,
    //         options =>
    //         {
    //             options.CommandTimeout(500);
    //             options.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName);
    //             options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    //         });
    // }
}
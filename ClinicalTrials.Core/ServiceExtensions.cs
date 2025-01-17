using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicalTrials.Core;

public static class ServiceExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        return services;
    }
}
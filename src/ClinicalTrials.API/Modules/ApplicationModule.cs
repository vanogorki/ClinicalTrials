using ClinicalTrials.API.Middlewares;
using ClinicalTrials.Persistence;
using ClinicalTrials.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace ClinicalTrials.API.Modules;

internal static class ApplicationModule
{
    internal static void AddApplicationModule(this WebApplicationBuilder builder)
    {
        builder.AddMediatrModule();
        builder.AddPersistenceModule();
        builder.AddMapperModule();

        builder.Services.AddLogging(options => { options.AddConsole(); });
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddControllers().AddNewtonsoftJson();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddScoped<ExceptionMiddleware>();
        builder.Services.AddSwaggerGen(o =>
        {
            o.SwaggerDoc(
                "v1",
                new OpenApiInfo
                {
                    Title = "API",
                    Version = "v1"
                });
        });
    }
    
    internal static void ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<DatabaseContext>();
        context.Database.Migrate();
    }
}
using ClinicalTrials.Infrastructure;
using ClinicalTrials.Migrations;
using Microsoft.EntityFrameworkCore;

namespace ClinicalTrials.API;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddInfrastructure();
        builder.Services.AddControllers();
        
        // Add DatabaseContext
        builder.Services.AddDbContext<DatabaseContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DBConnection")));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.ApplyMigrations();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.Run();
    }
}
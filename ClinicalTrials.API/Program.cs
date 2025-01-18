using ClinicalTrials.API.Middlewares;
using ClinicalTrials.API.Modules;

var builder = WebApplication.CreateBuilder(args);

builder.AddApplicationModule();

var app = builder.Build();

app.MapControllers();
app.UseMiddleware<ExceptionMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();
app.ApplyMigrations();

app.Run();
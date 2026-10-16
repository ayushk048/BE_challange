using FluentValidation;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using _Diabetes_BE_challenge.Config;
using _Diabetes_BE_challenge.CosmosConfig;
using _Diabetes_BE_challenge.CosmosConfig.Service;
using _Diabetes_BE_challenge.DTOs;
using _Diabetes_BE_challenge.Repository;
using _Diabetes_BE_challenge.Services;
using _Diabetes_BE_challenge.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IValidator<UserDTO>, UserValidator>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<ICosmosDbService>(CosmosDBConfig.InitializeCosmosClientInstanceAsync(builder.Configuration.GetSection("CosmosDb")).GetAwaiter().GetResult());
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddHealthChecks()
    .AddCheck<CosmosDbHealthCheck>("health");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.MapHealthChecks("/health", new HealthCheckOptions
{
    Predicate = reg => reg.Tags.Contains("custom"),
});

app.Run();
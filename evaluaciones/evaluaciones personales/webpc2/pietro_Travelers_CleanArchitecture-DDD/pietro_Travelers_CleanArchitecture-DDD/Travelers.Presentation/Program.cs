using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using Travelers.Application.Subscriptions.CommandServices;
using Travelers.Domain.Subscriptions.Repositories;
using Travelers.Domain.Subscriptions.Services;
using Travelers.Infrastructure.Shared.Contexts;
using Travelers.Infrastructure.Subscription.Persistence;
using Travelers.Presentation.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API",
        Description = "An ASP.NET Core Web API",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});

// Configure Dependency Injection
//Subscriptions Bounded Context
builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<IPlanCommandService, PlanCommandService>();

// Mapper
builder.Services.AddAutoMapper(typeof(ModelsToResponse));
builder.Services.AddAutoMapper(typeof(RequestToModels));

// Database Connection
var connectionString = builder.Configuration.GetConnectionString("SubscriptionConnection");
builder.Services.AddDbContext<SubscriptionContext>(
    dbContextOptions => dbContextOptions.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
    );

var app = builder.Build();

// Create database if not exists
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<SubscriptionContext>())
{
    context?.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
using System.Reflection;
using Carpio.Application.HR.CommandServices;
using Carpio.Domain.HR.Repositories;
using Carpio.Domain.HR.Services;
using Carpio.Infrastructure.Shared.Contexts;
using Carpio.Presentation.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Carpio.Infrastructure.HR.Persistence;
using Carpio.Infrastructure.Shared.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "si730pc2u202114900.API",
        Version = "v1",
        Description = "An ASP.NET Core Web API for managing Join Request. Created by Sharon Barrial, a software engineering student of UPC with a code student: u202114900.",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Sharon Barrial",
            Email = "u202114900@upc.edu.pe",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Apache 2.0",
            Url = new Uri("https://example.com/license")
        }
    });
    
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// Configure Dependency Injection
//HR Bounded Context
builder.Services.AddScoped<IJoinRequestRepository, JoinRequestRepository>();
builder.Services.AddScoped<IJoinRequestCommandService, JoinRequestCommandService>();

// Mapper
builder.Services.AddAutoMapper(
    typeof(ModelsToResponse),
    typeof(ModelsToRequest),
    typeof(RequestToModels)
    );


// Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HrContext>(
    dbContextOptions => dbContextOptions.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
    );

var app = builder.Build();

// Create database if not exists
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<HrContext>())
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
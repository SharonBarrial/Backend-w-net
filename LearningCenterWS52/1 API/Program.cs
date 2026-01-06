using _1_API.Mapper;
using _2_Domain;
using _3_Data;
using _3_Data.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Framework de inyección de dependencias:
//Cada vez que se solicite una interfaz (iTutorialData),
//se inyecta una clase concreta (TutorialOracle)
//Dependency inyection
builder.Services.AddScoped<iTutorialData, TutorialOracle>();

builder.Services.AddScoped<iTutorialDomain, TutorialDomain>();


//Automapper
builder.Services.AddAutoMapper(
    typeof(RequestToModels),
    typeof(ModelsToRequest),
    typeof(ModelsToResponse));

//Conexion a la base de datos MySQL
var connectionString = builder.Configuration.GetConnectionString("learningCenterConnection");//********
var serverVersion = new MySqlServerVersion(new Version(8, 4, 0));

builder.Services.AddDbContext<LearningCenterContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
    });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<LearningCenterContext>())
{
    context.Database.EnsureCreated();
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
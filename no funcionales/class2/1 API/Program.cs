using _1_API.Mapper;
using _2_Domain;
using _3_Data;
using _3_Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//---
//Cada vez que veas un interfaz del tipo ITutorialData instanciaras la clase TutorialOracle/TutorialData
//Para que sea intercambiable entre las clases existentes 
builder.Services.AddTransient<ITutorialData, TutorialData>();
//Para el domain
builder.Services.AddTransient<ITutorialDomain, TutorialDomain>();
//-----------

//Automapper
builder.Services.AddAutoMapper(
    typeof(RequestToModels),
    typeof(ModelsToRequest),
    typeof(ModelsToResponse));
//---


//Conexión a la base de datos MySQL
var connectionString = builder.Configuration.GetConnectionString("LearningCenterConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 36));

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
    }
);


var app = builder.Build();

//PARA CREAR UNA BASE DE DATOS SI NO EXISTE
using (var scope=app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetRequiredService<LearningCenterContext>())
{
    context.Database.EnsureCreated();
}
//------

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
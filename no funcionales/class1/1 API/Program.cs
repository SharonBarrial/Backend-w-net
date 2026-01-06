using _1_API.Mapper;
using _2_Domain;
using _3_Data;

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
builder.Services.AddAutoMapper(
    typeof(RequestToModels),
    typeof(ModelsToRequest),
    typeof(ModelsToResponse));

var app = builder.Build();

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
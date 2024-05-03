using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RotaDeViagem.API.Filters;
using RotaDeViagem.API.Setup;
using RotaDeViagem.DatabaseRepository.Context;
using RotaDeViagem.Domain.Commands.Request;
using RotaDeViagem.Domain.Entities;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(serviceProvider =>
{
    var connectionString = Configuration.GetConnectionString("ConnectionStrings"); ;
    var options = new DbContextOptionsBuilder<RotaDeViagemContext>()
        .UseSqlServer(connectionString)
        .Options;

    var userLoggedInfo = "1"; // simula o código do usuário
    var context = new RotaDeViagemContext(options, userLoggedInfo);
    return context;
});


var connectionString = builder.Configuration.GetConnectionString("ConnectionStrings");
builder.Services.AddScoped<IDbConnection, SqlConnection>((connection) => new SqlConnection(connectionString));

var autoMapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<Rota, AddNewRotaRequest>().ReverseMap();  
});
builder.Services.AddSingleton(autoMapperConfig.CreateMapper());

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddDependencyRepository();
builder.Services.AddDependencyProvider();
builder.Services.AddDependencyHandler();


builder.Services.AddMvc(config =>
{
    config.Filters.Add(typeof(ExceptionFilter));
});

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
public partial class Program { }
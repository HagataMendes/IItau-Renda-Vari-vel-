using Itau.Investimentos.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Itau.Investimentos.Infrastructure.Repositories;
using Itau.Investimentos.Infrastructure.Repositories.Interfaces;
using Itau.Investimentos.Application.Services;
using Itau.Investimentos.Application.Services.Interfaces; // Esta linha é importante!

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços ao contêiner (Injeção de Dependência)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração da Connection String do MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registro do DbContext com MySQL e Entity Framework Core
builder.Services.AddDbContext<ItauInvestimentosDbContext>(options =>
    options.UseMySql(connectionString,
        new MySqlServerVersion(new Version(8, 0, 42)), // <<< VERSÃO AJUSTADA PARA 8.0.42
        mySqlOptions =>
        {
            mySqlOptions.EnableRetryOnFailure(
                maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
        }));

// INÍCIO DO REGISTRO DOS SEUS REPOSITÓRIOS E SERVIÇOS
builder.Services.AddScoped<IOperacaoRepository, OperacaoRepository>();
builder.Services.AddScoped<IInvestimentosService, InvestimentosService>();
// FIM DO REGISTRO DOS SEUS REPOSITÓRIOS E SERVIÇOS

var app = builder.Build();

// Configura o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// O código de exemplo de WeatherForecast é mantido, mas você pode removê-lo se quiser no futuro.
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MySql.EntityFrameworkCore;
using Proto2.Persistence;
using Proto2.Persistence.Context;
using Proto2.Persistence.Contract;
using AutoMapper;
using Proto2.Application.helpers;
using Proto2.Application.Contracts;
using Proto2.Application.Services;
using System.Text.Json.Serialization.Metadata;
using System.Net.Sockets;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
/*.AddJsonOptions(options => {
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());    
});
*/

builder.Services.ConfigureHttpJsonOptions(options => {
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.SerializerOptions.WriteIndented = true;
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddDbContext<AppDbContext>(
    context => context.UseMySQL(builder.Configuration.GetConnectionString("MySqlConnectionString")!)
);

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//Persistences 
builder.Services.AddScoped<IPersonPersist, PersonPersist>();
builder.Services.AddScoped<IHomeCareCompanyPersist, HomeCareCompanyPersist>();
builder.Services.AddScoped<IHomeCareContactsPersist, HomeCareContactPersist>();

//Services
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IHomeCareCompanyService, HomeCareCompanyService>();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(cors => cors.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.MapControllers();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }

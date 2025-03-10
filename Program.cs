using DeveloperPathways.Data;
using DeveloperPathways.Services;
using Microsoft.EntityFrameworkCore;
using MediatR;
using DeveloperPathways.Controllers;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(typeof(DeveloperPathwaysController).Assembly); 

// Add services to the container.
builder.Services.AddDbContext<TitanicContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CsvService>();
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

using (var scope = app.Services.CreateScope())
{
    var csvService = scope.ServiceProvider.GetRequiredService<CsvService>();
    csvService.RetrieveCsv();
}

app.Run();
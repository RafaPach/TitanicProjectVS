using DeveloperPathways.Data;
using DeveloperPathways.Services;
using Microsoft.EntityFrameworkCore;
using MediatR;
using DeveloperPathways.Controllers;
using DeveloperPathways.Interface;
using DeveloperPathways.Infrastructure.Repositories;
using DeveloperPathways.Repository;
using DeveloperPathways.Application.Queries.GetByAge;
using DeveloperPathways.Application.Queries.GetPassengers;
using FluentValidation;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(typeof(DeveloperPathwaysController).Assembly); 

// Add services to the container.
builder.Services.AddDbContext<TitanicContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<CsvOptions>(builder.Configuration.GetSection("CsvOptions"));
builder.Services.AddScoped<CsvService>();
builder.Services.AddHostedService<CsvWorker>();

builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();
builder.Services.AddScoped<IGetByAgeRepository, GetByAgeRepository>();
builder.Services.AddScoped<IGetByClassRepository, GetByClassRepository>();
builder.Services.AddScoped<IGetSurivalRepository, GetSurvivalRepository>();

builder.Services.AddScoped<IValidator<GetAllPassengersQuery>, GetAllPassengersQueryValidator>();
builder.Services.AddScoped<IValidator<GetPassengerByIdQuery>, GetPassengerByIdQueryValidator>();
builder.Services.AddScoped<IValidator<GetPassengersByAgeQuery>, GetPassengersByAgeQueryValidator>();



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
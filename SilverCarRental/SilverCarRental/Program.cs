using Microsoft.EntityFrameworkCore;
using SilverCarRental.Core.Interface;
using SilverCarRental.Core.Services;
using SilverCarRental.Data;
using SilverCarRental.Data.Repositories;
using SilverCarRental.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<SilverDataContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("SilverCarRentalConnectionString")));

builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient(typeof(IRepository<Car>), typeof(CarRepository));
builder.Services.AddTransient(typeof(ICarRepository), typeof(CarRepository));

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

app.UseAuthorization();

app.MapControllers();

app.Run();

using Carter;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VeritcalSliceArch.Infrastructure.Persistence;
using VeritcalSliceArch.Infrastructure.Persistence.Data;
using static VeritcalSliceArch.Features.Product.Commands.CreateProduct;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddValidatorsFromAssemblyContaining<ProductValidator>();
builder.Services.AddDbContext<DataContext>(y => y.UseSqlServer("Server=OLGUNBEY\\SQLEXPRESS;Database=VSA;Trusted_Connection=True; TrustServerCertificate=True;"));
builder.Services.AddScoped<IApplicationDbContext, DataContext>();
builder.Services.AddMediatR(y =>
{
    y.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});
builder.Services.AddCarter();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapSwagger();
app.MapCarter();
app.Run();

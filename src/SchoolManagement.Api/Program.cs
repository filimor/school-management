using SchoolManagement.Application.Profiles;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Domain.Models;
using SchoolManagement.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<Entity>, Repository<Entity>>();
builder.Services.AddAutoMapper(typeof(DomainToDtoProfile), typeof(DtoToDomainProfile));

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

using System.Reflection;
using API_Task2.Data;
using API_Task2.Interfaces;
using API_Task2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(_ => { }, Assembly.GetExecutingAssembly());

builder.Services.AddHttpContextAccessor();// Resolve IFormFile

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapControllers();

app.UseStaticFiles();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

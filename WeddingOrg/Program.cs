using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WeddingOrg.Data;
using WeddingOrg.Models;
using WeddingOrg.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IWeddingsRepository, WeddingsRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(options 
    => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();

app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

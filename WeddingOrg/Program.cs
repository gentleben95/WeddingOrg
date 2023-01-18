using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WeddingOrg.Data;
using WeddingOrg.Models;
using WeddingOrg.Repositories;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IWeddingsRepository, WeddingsRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(options 
    => options.UseSqlServer(
        builder.Configuration.GetConnectionString("ApplicationConnectionString")));
builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddBlobServiceClient(builder.Configuration["WeddingOrg-Azure:blob"], preferMsi: true);
    clientBuilder.AddQueueServiceClient(builder.Configuration["WeddingOrg-Azure:queue"], preferMsi: true);
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

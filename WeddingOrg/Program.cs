using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeddingOrg.Application.Cameramen.DTOs;
using WeddingOrg.Application.Cameramen.Queries;
using WeddingOrg.Application.Interfaces;
using WeddingOrg.Infrastructure;
using WeddingOrg.Infrastructure.Data;
using WeddingOrg.Infrastructure.Repositories;
using MediatR;
using AutoMapper;
using System.Reflection;
using WeddingOrg.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton(typeof(CancellationToken), CancellationToken.None);
//builder.Services.AddMediatR(typeof(CameramanDto));
//builder.Services.AddMediatR(typeof(GetCameramenQuery).Assembly);
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();

app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
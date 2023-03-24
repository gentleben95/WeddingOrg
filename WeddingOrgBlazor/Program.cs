using MediatR;
using WeddingOrg.Application.Models.Cameramen.DTOs;
using WeddingOrg.Application.Models.Cameramen.Queries;
using WeddingOrg.Application.Interfaces;
using WeddingOrg.Infrastructure.Repositories;
using WeddingOrg.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using WeddingOrg.Application.Models.Cameramen.Commands;
using WeddingOrg.Domain.Entities;
using WeddingOrg.Application.Models.Photographers.Commands;
using WeddingOrg.Application.Models.Photographers.Queries;
using WeddingOrg.Application.Models.Photographers.DTOs;
using WeddingOrg.Application.Models.Restaurants.Queries;
using WeddingOrg.Application.Models.Restaurants.DTOs;
using WeddingOrg.Application.Models.Restaurants.Commands;
using WeddingOrg.Application.Models.Weddings.Queries;
using WeddingOrg.Application.Models.Weddings.Commands;
using WeddingOrg.Application.Models.Weddings.DTOs;

namespace WeddingOrgBlazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var configuration = builder.Configuration;
            configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddHttpClient();
            builder.Services.AddMediatR(typeof(Program));

            builder.Services.AddScoped<WeddingOrg.Controllers.CameramenController>();
            builder.Services.AddScoped<WeddingOrg.Controllers.PhotographersController>();
            builder.Services.AddScoped<WeddingOrg.Controllers.RestaurantsController>();
            builder.Services.AddScoped<WeddingOrg.Controllers.WeddingsController>();

            builder.Services.AddScoped<IRequestHandler<GetCameramenQuery, IEnumerable<Cameraman>>, GetCameramenQueryHandler>();
            builder.Services.AddScoped<IRequestHandler<CreateCameramanCommand, CameramanDto>, CreateCameramanCommandHandler>();
            builder.Services.AddScoped<IRequestHandler<DeleteCameramanCommand, int>, DeleteCameramanCommandHandler>();

            builder.Services.AddScoped<IRequestHandler<GetPhotographersQuery, IEnumerable<Photographer>>, GetPhotographersQueryHandler>();
            builder.Services.AddScoped<IRequestHandler<CreatePhotographerCommand, PhotographerDto>, CreatePhotographerCommandHandler>();
            builder.Services.AddScoped<IRequestHandler<DeletePhotographerCommand, int>, DeletePhotographerCommandHandler>();

            builder.Services.AddScoped<IRequestHandler<GetRestaurantsQuery, IEnumerable<Restaurant>>, GetRestaurantsQueryHandler>();
            builder.Services.AddScoped<IRequestHandler<CreateRestaurantCommand, RestaurantDto>, CreateRestaurantCommandHandler>();
            builder.Services.AddScoped<IRequestHandler<DeleteRestaurantCommand, int>, DeleteRestaurantCommandHandler>();

            builder.Services.AddScoped<IRequestHandler<GetWeddingsQuery, IEnumerable<Wedding>>, GetWeddingsQueryHandler>();
            builder.Services.AddScoped<IRequestHandler<CreateWeddingCommand, int>, CreateWeddingCommandHandler>();
            builder.Services.AddScoped<IRequestHandler<DeleteWeddingCommand, int>, DeleteWeddingCommandHandler>();
            builder.Services.AddScoped<IRequestHandler<AddPhotographerToWeddingCommand, int>, AddPhotographerToWeddingCommandHandler>();
            builder.Services.AddScoped<IRequestHandler<AddCameramanToWeddingCommand, int>, AddCameramanToWeddingCommandHandler>();
            builder.Services.AddScoped<IRequestHandler<AddRestaurantToWeddingCommand, int>, AddRestaurantToWeddingCommandHandler>();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IWeddingsRepository, WeddingsRepository>();

            var app = builder.Build();
            


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}
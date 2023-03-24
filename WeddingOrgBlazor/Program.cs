using MediatR;
using WeddingOrg.Application.Models.Cameramen.DTOs;
using WeddingOrg.Application.Models.Cameramen.Queries;
using WeddingOrg.Application.Interfaces;
using WeddingOrg.Infrastructure.Repositories;
using WeddingOrg.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using WeddingOrg.Application.Models.Cameramen.Commands;

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
            builder.Services.AddScoped<IRequestHandler<GetCameramenQuery, IEnumerable<CameramanDto>>, GetCameramenQueryHandler>();
            builder.Services.AddScoped<IRequestHandler<CreateCameramanCommand, CameramanDto>, CreateCameramanCommandHandler>();
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
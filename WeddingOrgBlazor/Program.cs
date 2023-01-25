using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using WeddingOrg.Controllers;
using WeddingOrg.Data;
using WeddingOrg.Repositories;
using WeddingOrgBlazor.Data;

namespace WeddingOrgBlazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddScoped<IWeddingsRepository, WeddingsRepository>();
            builder.Services.AddScoped<WeddingsController>();
            builder.Services.AddScoped<PhotographersController>();
            builder.Services.AddScoped<CameramenController>();
            builder.Services.AddScoped<RestaurantsController>();
            builder.Services.AddDbContext<ApplicationDbContext>(options
                => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
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
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration[
    "ConnectionStrings:ProductConnection"]);
    opts.EnableSensitiveDataLogging(true);
});

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddScoped<GuidResponseAttribute>();

var app = builder.Build();

app.UseStaticFiles();

app.MapDefaultControllerRoute();

app.MapRazorPages();

var context = app.Services
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<DataContext>();

SeedData.SeedDatabase(context);

app.Run();
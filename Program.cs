using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WebApp.TagHelpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration[
    "ConnectionStrings:ProductConnection"]);
    opts.EnableSensitiveDataLogging(true);
});

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddSingleton<CitiesData>();

builder.Services.AddTransient<ITagHelperComponent, TimeTagHelperComponent>();

var app = builder.Build();

app.UseStaticFiles();

app.MapControllers();

app.MapDefaultControllerRoute();

app.MapRazorPages();

var context = app.Services
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<DataContext>();

// temporary disable
SeedData.SeedDatabase(context);

app.Run();
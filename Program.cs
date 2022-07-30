using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration[
    "ConnectionStrings:ProductConnection"]);
    opts.EnableSensitiveDataLogging(true);
});

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.Cookie.IsEssential = true;
});

builder.Services.Configure<RazorPagesOptions>(opts =>
{
    opts.Conventions.AddPageRoute("/Index", "/extra/page/{id:long?}");
});

var app = builder.Build();

app.UseStaticFiles();

app.UseSession();

app.MapControllers();

app.MapDefaultControllerRoute();

app.MapRazorPages().Add(b => ((RouteEndpointBuilder)b).Order = 2); ;

var context = app.Services.CreateScope()
                          .ServiceProvider
                          .GetRequiredService<DataContext>();

// temporary disable
//SeedData.SeedDatabase(context);

app.Run();
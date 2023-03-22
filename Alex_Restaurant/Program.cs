using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Alex_Restaurant.Data;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Alex_RestaurantContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Alex_RestaurantContext") ?? throw new InvalidOperationException("Connection string 'Alex_RestaurantContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

var supportedCultures = new[]
   {
        new CultureInfo("en-US")
    };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-US"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

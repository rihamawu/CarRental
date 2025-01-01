using CarRental.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext configuration
builder.Services.AddDbContext<CarRentalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CarRentalDb")));

// Add services for MVC (controllers with views)
builder.Services.AddControllersWithViews();

// Add services for Razor Pages (if you are using Razor Pages)
builder.Services.AddRazorPages(); // This was missing in your code

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

// Enable routing
app.UseRouting();

// Enable authorization
app.UseAuthorization();

// Map controller routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Optionally, if you are also using Razor Pages:
app.MapRazorPages();

app.Run();

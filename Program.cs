using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Load environment-specific appsettings (Development or Production)
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

var apiUrl = builder.Configuration["ApiUrl"];
Console.WriteLine($"ApiUrl from appsettings: {apiUrl}");  // This should print the correct value to the console

// Add services to the container (MVC, Razor Views, etc.)
builder.Services.AddControllersWithViews(); // Enable MVC and Razor Views

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Show detailed errors in Development environment
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Use a custom error page in Production
    app.UseHsts(); // Enforce HTTP Strict Transport Security in Production
}

app.UseHttpsRedirection(); // Redirect HTTP to HTTPS
app.UseStaticFiles(); // Serve static files (like CSS, JS, images)

app.UseRouting();
app.UseAuthorization(); // Enable authorization middleware if necessary

// Define the default route for MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Default route: HomeController and Index action

app.MapControllers(); // Map API controllers

// Start the application
app.Run();

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC476.Data;
using MVC476.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MVC476AccountContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVC476AccountContext") ?? throw new InvalidOperationException("Connection string 'MVC476AccountContext' not found.")));
builder.Services.AddDbContext<MVC476Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVC476Context") ?? throw new InvalidOperationException("Connection string 'MVC476Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider; 
    SeedData.Initialize(services);

}
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

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using KI_lab.Data;
using KI_lab.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<KI_labContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("KI_labContext") ?? throw new InvalidOperationException("Connection string 'KI_labContext' not found.")));

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

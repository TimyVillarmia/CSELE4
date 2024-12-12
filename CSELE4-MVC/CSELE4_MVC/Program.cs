using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CSELE4_MVC.Data;
using CSELE4_MVC.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IFormFileService, FormFileService>();
builder.Services.AddDbContext<CSELE4_MVCContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CSELE4_MVCContext") ?? throw new InvalidOperationException("Connection string 'CSELE4_MVCContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

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
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();

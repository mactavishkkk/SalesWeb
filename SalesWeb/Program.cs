using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Localization;
using SalesWeb.Data;
using SalesWeb.Services;
using System.Globalization;

var str = $"Server=localhost;" +
          $"Database=development;" +
          $"Uid=root;" +
          $"Pwd=password";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SalesWebContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("SalesWebContext"), ServerVersion.AutoDetect(str)));

//Add seeding services
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartmentService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Add seeds to dabase
using (var scope = app.Services.CreateScope())
{
    var enUs = new CultureInfo("en-US");
    var localizationOptions = new RequestLocalizationOptions
    {
        DefaultRequestCulture = new RequestCulture(enUs),
        SupportedCultures = new List<CultureInfo> { enUs },
        SupportedUICultures = new List<CultureInfo> { enUs }
    };
    app.UseRequestLocalization(localizationOptions);

    var services = scope.ServiceProvider;
    try
    {
        var seedingService = services.GetRequiredService<SeedingService>();
        seedingService.Seed();
    } catch (Exception ex)
    {
        throw new Exception(ex.Message);
    }
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

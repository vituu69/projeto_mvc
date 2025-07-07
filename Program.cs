

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Json;
using WebProjct.Models;
using WebProjct.Data;
using Microsoft.Extensions.DependencyInjection;
using WebProjct.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddDbContext<WebProjctContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("WebProjctContext"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("WebProjctContext")),
        o => o.MigrationsAssembly("WebProjct")
    )
);
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();


//builder.Services.AddDbContext<WebProjctContext>(options =>
//options.UseMySql(builder.Configuration.GetConnectionString("WebProjctContext"), o =>
//o.MigrationsAssembly("WebProjct")));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Services.CreateScope();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Executa o seed manualmente
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var seedingService = services.GetRequiredService<SeedingService>();
    seedingService.Seed(); // ← Aqui ele popula


}



app.Run();

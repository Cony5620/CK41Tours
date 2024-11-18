using CK41Tours.DAO;
using CK41Tours.Services;
using CK41Tours.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
builder.Services.AddDbContext<CK41ToursDbContext>(o=>o.UseSqlServer(config.GetConnectionString("CK41ToursConnectionString")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ITGService,TGService>();
builder.Services.AddTransient<IDTService,DTService>();
builder.Services.AddTransient<ITMService,TMService>();
builder.Services.AddTransient<ITTService, TTService>();
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

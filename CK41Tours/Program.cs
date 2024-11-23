//using CK41Tours.DAO;
//using CK41Tours.Services;
//using CK41Tours.UnitOfWorks;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);
//var config = builder.Configuration;
//builder.Services.AddDbContext<CK41ToursDbContext>(o=>o.UseSqlServer(config.GetConnectionString("CK41ToursConnectionString")));

//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); builder.Services.AddControllersWithViews();
//builder.Services.AddTransient<ITGService,TGService>();
//builder.Services.AddTransient<IDTService,DTService>();
//builder.Services.AddTransient<ITMService,TMService>();
//builder.Services.AddTransient<ITTService, TTService>();

//builder.Services.AddRazorPages();
//builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<CK41ToursDbContext>()
//    .AddDefaultUI()
//    .AddDefaultTokenProviders();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}
//app.UseStaticFiles();


//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthentication();
//app.UseAuthorization();

////app.MapControllerRoute(
////    name: "default",
////    pattern: "{controller=Home}/{action=Index}/{id?}");

//// Default route to login page for unauthenticated users
//app.Use(async (context, next) =>
//{
//    if (!context.User.Identity.IsAuthenticated && !context.Request.Path.StartsWithSegments("/Identity/Account/Login"))
//    {
//        context.Response.Redirect("/Identity/Account/Login");
//        return;
//    }
//    await next();
//});

//app.MapRazorPages();
//app.Run();


using CK41Tours.DAO;
using CK41Tours.Services;
using CK41Tours.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Load configuration
var config = builder.Configuration;

// Add database context
builder.Services.AddDbContext<CK41ToursDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("CK41ToursConnectionString")));

// Register services and Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ITGService, TGService>();
builder.Services.AddTransient<IDTService, DTService>();
builder.Services.AddTransient<ITMService, TMService>();
builder.Services.AddTransient<ITTService, TTService>();
builder.Services.AddTransient<IDDService,DDService>();

// Add Razor Pages and Identity
builder.Services.AddRazorPages();
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<CK41ToursDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

// Add MVC support
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Middleware to serve static files and enforce HTTPS
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Authentication and Authorization middleware
app.UseAuthentication();
app.UseAuthorization();

// Middleware to redirect unauthenticated users
app.Use(async (context, next) =>
{
    if (!context.User.Identity.IsAuthenticated && !context.Request.Path.StartsWithSegments("/Identity/Account/Login"))
    {
        context.Response.Redirect("/Identity/Account/Login");
        return;
    }
    await next();
});

// Define the default route for MVC Controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map Razor Pages
app.MapRazorPages();

app.Run();

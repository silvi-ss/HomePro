using HomePro.Data;
using HomePro.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HomePro.Web.Infrastructure;
using HomePro.Services.Data;
using HomePro.Data.Repository.Interfaces;

using HomePro.Web.Infrastructure.Extensions;
using HomePro.Services.Data.Interfaces;
using HomePro.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddDefaultIdentity<IdentityUser>
    (options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequiredLength = 10;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequiredUniqueChars = 2;    
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();


//builder.Services.RegisterRepositories(typeof(ApplicationUser).Assembly);
builder.Services.AddScoped<
    IRepository<ServiceCatalog, Guid>,
    BaseRepository<ServiceCatalog, Guid>>();

builder.Services.RegisterServices(typeof(IBaseService).Assembly);

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();

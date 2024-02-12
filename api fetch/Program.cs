using api_fetch.Data;
using api_fetch.Manager;
using api_fetch.Provider;
using api_fetch.Provider.Interface;
using App.Base;
using App.Expenses;
using App.Setup;
using App.User;
using AspNetCoreHero.ToastNotification;
using DateConverter;
using DateConverter.Converters;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Pioneer.Pagination;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 10;
    config.IsDismissable = false;
    config.Position = NotyfPosition.BottomRight;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x => { x.LoginPath = "/Auth/Login"; });

builder.Services.UserConfiguration()
    .BaseConfig()
    .SetupConfig()
    .UseRootConfig()
    .UseNepaliDateConfig();
builder.Services.AddScoped<DbContext, ApplicationDbContext>()
    .AddScoped<IAuthManager, AuthManager>()
    .AddHttpContextAccessor()
    .AddScoped<IUserProvider,UserProvider>()
    .AddTransient<IPaginatedMetaService,PaginatedMetaService>();

var app = builder.Build();

app.Services.CreateScope().ServiceProvider.GetService<ApplicationDbContext>()?.Database.Migrate();

app.UseCookiePolicy(new CookiePolicyOptions()
{
    MinimumSameSitePolicy = SameSiteMode.Lax,
            
});
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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "areaRoute",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
).RequireAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}").RequireAuthorization();

app.Run();
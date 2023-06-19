using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using ThirdPartyAuthTest;
using ThirdPartyAuthTest.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddRazorPages();
services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>();

services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
});


var customThemeStyles =
    new Dictionary<ConsoleThemeStyle, SystemConsoleThemeStyle>
    {
        {
            ConsoleThemeStyle.Text, new SystemConsoleThemeStyle
            {
                Foreground = ConsoleColor.Green,
            }
        },
        {
            ConsoleThemeStyle.String, new SystemConsoleThemeStyle
            {
                Foreground = ConsoleColor.Yellow,
            }
        },
    };

var customTheme = new SystemConsoleTheme(customThemeStyles);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console(theme: customTheme)
    .CreateLogger();

Log.Logger.Information("Iniciando aplicacion!");

builder.Host.UseSerilog((context, config) =>
{
    config.WriteTo.Console();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//-------Custom Middleware
app.UseLoggingMiddleware();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action}");
});
app.Run();


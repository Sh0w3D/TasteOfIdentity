using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server;
using Server.Data;

var seed = args.Contains("/seed");
if(seed)
{
    args = args.Except(new[] { "/seed" }).ToArray();
}

var builder = WebApplication.CreateBuilder(args);
var defauldConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (seed)
{
    SeedData.EnsureSeedData(defauldConnectionString);
}

var assembly = typeof(Program).Assembly.GetName().Name;


builder.Services.AddDbContext<AspNetIdentityDbContext>(options =>
    options.UseNpgsql(defauldConnectionString,
        b => b.MigrationsAssembly(assembly)));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AspNetIdentityDbContext>();

builder.Services.AddIdentityServer()
    .AddAspNetIdentity<IdentityUser>()
    .AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = b =>
        b.UseNpgsql(defauldConnectionString, opt => opt.MigrationsAssembly(assembly));
    })
    .AddOperationalStore(options =>
    {
        options.ConfigureDbContext = b =>
        b.UseNpgsql(defauldConnectionString, opt => opt.MigrationsAssembly(assembly));
    })
    .AddDeveloperSigningCredential();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
//app.UseAuthorization();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapDefaultControllerRoute();
//});
app.Run();

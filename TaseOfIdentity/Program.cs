using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using TaseOfIdentity.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(dbConnectionString));


builder.Services.AddScoped<IStudentService, StudentService>();
var app = builder.Build();
app.MapControllers();

app.Run();

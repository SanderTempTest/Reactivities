using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(Opt =>
{
    Opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors();


var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x =>x.AllowAnyHeader().AllowAnyMethod()
.WithOrigins("http://localhost:3000", "https://localhost:3000"));
app.MapControllers();

using var scope = app.Services.CreateScope();
var Services = scope.ServiceProvider;

try
{
    var context = Services.GetRequiredService<AppDbContext>();
    await context.Database.MigrateAsync();
    await DbInitializer.SeedDAta(context);
}
catch (Exception ex)
{
    var logger = Services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during migratoin");
}

app.Run();
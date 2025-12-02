using Microsoft.EntityFrameworkCore;
using web_server_app_dev_final.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure Entity Framework with SQL Server and retry logic for transient failures
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 10,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null)));

var app = builder.Build();

// Apply migrations automatically on startup with retry logic
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    var maxRetries = 10;
    var delay = TimeSpan.FromSeconds(5);

    for (int i = 0; i < maxRetries; i++)
    {
        try
        {
            logger.LogInformation("Attempting to migrate database (attempt {Attempt}/{MaxRetries})...", i + 1, maxRetries);
            var context = services.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            logger.LogInformation("Database migration completed successfully.");
            break;
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "Database migration failed (attempt {Attempt}/{MaxRetries}). Retrying in {Delay} seconds...", i + 1, maxRetries, delay.TotalSeconds);
            if (i == maxRetries - 1)
            {
                logger.LogError(ex, "Database migration failed after {MaxRetries} attempts.", maxRetries);
            }
            else
            {
                Thread.Sleep(delay);
            }
        }
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

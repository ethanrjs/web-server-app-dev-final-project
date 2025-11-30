using Microsoft.EntityFrameworkCore;
using web_server_app_dev_final.Models;

namespace web_server_app_dev_final.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Game> Games => Set<Game>();
    public DbSet<Platform> Platforms => Set<Platform>();
}

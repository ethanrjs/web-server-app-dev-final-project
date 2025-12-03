using Microsoft.EntityFrameworkCore;
using web_server_app_dev_final.Models;

namespace web_server_app_dev_final.Data;

/// <summary>
/// Database context for the game library application.
/// Handles database connections and entity configurations.
/// </summary>
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Game> Games => Set<Game>();
    public DbSet<Platform> Platforms => Set<Platform>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure decimal precision for Rating
        modelBuilder.Entity<Game>()
            .Property(g => g.Rating)
            .HasPrecision(3, 1);

        // Seed initial game data - Only Ethan R's reviews
        modelBuilder.Entity<Game>().HasData(
            new Game
            {
                Id = 1,
                Title = "Minecraft",
                Developer = "Mojang Studios",
                ReleaseYear = 2011,
                Platforms = "PC,PS5,NSW",
                Genres = "Sandbox,Survival",
                Rating = 10.0m,
                CoverImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/1672970/library_600x900_2x.jpg",
                ReviewText = "The most important game ever made.",
                Reviewer = "Ethan R",
                ReviewDate = new DateTime(2025, 12, 2),
                IsFeatured = true,
                Description = "Build anything you can imagine in this infinite sandbox."
            },
            new Game
            {
                Id = 2,
                Title = "Overwatch 2",
                Developer = "Blizzard Entertainment",
                ReleaseYear = 2022,
                Platforms = "PC,PS5",
                Genres = "Shooter,Multiplayer",
                Rating = 5.0m,
                CoverImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/2357570/library_600x900_2x.jpg",
                ReviewText = "A disappointing sequel that removed more than it added.",
                Reviewer = "Ethan R",
                ReviewDate = new DateTime(2025, 12, 2),
                IsFeatured = false
            },
            new Game
            {
                Id = 3,
                Title = "Subnautica",
                Developer = "Unknown Worlds",
                ReleaseYear = 2018,
                Platforms = "PC,PS5",
                Genres = "Survival,Adventure",
                Rating = 9.0m,
                CoverImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/264710/library_600x900_2x.jpg",
                ReviewText = "Terrifying ocean survival that nails atmosphere.",
                Reviewer = "Ethan R",
                ReviewDate = new DateTime(2025, 12, 2),
                IsFeatured = false
            },
            new Game
            {
                Id = 4,
                Title = "Factorio",
                Developer = "Wube Software",
                ReleaseYear = 2020,
                Platforms = "PC",
                Genres = "Simulation,Strategy",
                Rating = 9.0m,
                CoverImageUrl = "https://cdn.cloudflare.steamstatic.com/steam/apps/427520/library_600x900_2x.jpg",
                ReviewText = "The factory must grow.",
                Reviewer = "Ethan R",
                ReviewDate = new DateTime(2025, 12, 2),
                IsFeatured = false
            },
                        new Game
                        {
                            Id = 5,
                            Title = "The Isle",
                            Developer = "Afterthought LLC",
                            ReleaseYear = 2015,
                            Platforms = "PC",
                            Genres = "Simulation,Survival,Horror",
                            Rating = 10.0m,
                            CoverImageUrl = "https://tse1.mm.bing.net/th/id/OIP.4D_3COBMYkVMCYYWQ7KCLwHaLH?cb=ucfimg2&ucfimg=1&rs=1&pid=ImgDetMain&o=7&rm=3",
                            ReviewText = "Withstand what the island throws at you, no matter the cost.",
                            Reviewer = "Ella S",
                            ReviewDate = new DateTime(2025, 12, 3),
                            IsFeatured = false
                        }
        );
    }
}

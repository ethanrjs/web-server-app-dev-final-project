using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace web_server_app_dev_final.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Developer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: true),
                    Platforms = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genres = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Reviewer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReleaseYear = table.Column<int>(type: "int", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CoverImageUrl", "Description", "Developer", "Genres", "IsFeatured", "Platforms", "Rating", "ReleaseYear", "ReviewDate", "ReviewText", "Reviewer", "Title" },
                values: new object[,]
                {
                    { 1, "https://cdn.cloudflare.steamstatic.com/steam/apps/1672970/library_600x900_2x.jpg", "Build anything you can imagine in this infinite sandbox.", "Mojang Studios", "Sandbox,Survival", true, "PC,PS5,NSW", 10.0m, 2011, new DateTime(2025, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The most important game ever made.", "Ethan R", "Minecraft" },
                    { 2, "https://cdn.cloudflare.steamstatic.com/steam/apps/2357570/library_600x900_2x.jpg", null, "Blizzard Entertainment", "Shooter,Multiplayer", false, "PC,PS5", 5.0m, 2022, new DateTime(2025, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "A disappointing sequel that removed more than it added.", "Ethan R", "Overwatch 2" },
                    { 3, "https://cdn.cloudflare.steamstatic.com/steam/apps/264710/library_600x900_2x.jpg", null, "Unknown Worlds", "Survival,Adventure", false, "PC,PS5", 9.0m, 2018, new DateTime(2025, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terrifying ocean survival that nails atmosphere.", "Ethan R", "Subnautica" },
                    { 4, "https://cdn.cloudflare.steamstatic.com/steam/apps/427520/library_600x900_2x.jpg", null, "Wube Software", "Simulation,Strategy", false, "PC", 9.0m, 2020, new DateTime(2025, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The factory must grow.", "Ethan R", "Factorio" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Platforms");
        }
    }
}

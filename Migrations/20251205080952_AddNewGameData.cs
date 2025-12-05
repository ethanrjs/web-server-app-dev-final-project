using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace web_server_app_dev_final.Migrations
{
    /// <inheritdoc />
    public partial class AddNewGameData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CoverImageUrl", "Description", "Developer", "Genres", "IsFeatured", "Platforms", "Rating", "ReleaseYear", "ReviewDate", "ReviewText", "Reviewer", "Title" },
                values: new object[,]
                {
                    { 9, "https://archives.bulbagarden.net/media/upload/d/dc/Black_EN_boxart.png", null, "Game Freak", "RPG", false, "DS", 10.0m, 2010, new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Game Freak's pinnacle of Pokemon!", "Ethan G", "Pokemon Black Version" },
                    { 10, "https://upload.wikimedia.org/wikipedia/en/d/dc/Utopia_%28video_game%29_boxart.jpg", null, "Mattel Electronics", "Strategy", false, "Intellivision", 8.0m, 1982, new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Civilization's great-granddaddy.", "Ethan G", "Utopia" },
                    { 11, "https://upload.wikimedia.org/wikipedia/en/e/e6/Worms_WMD_cover_art.jpg", null, "", "Strategy, Party, Physics", false, "PC, Switch, XBOX, PS4, IOS, Android", 6.0m, 2016, new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Worms is fun, but this one disappoints.", "Ethan G", "Worms WMD" },
                    { 12, "https://upload.wikimedia.org/wikipedia/en/d/d5/Civilization_VII_cover.png", null, "Firaxis Games", "Strategy", false, "Cross-Platform", 6.0m, 2025, new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "An unworthy successor to 6.", "Ethan G", "Civilization 7" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}

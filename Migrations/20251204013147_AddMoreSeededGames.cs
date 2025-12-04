using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace web_server_app_dev_final.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreSeededGames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CoverImageUrl", "Description", "Developer", "Genres", "IsFeatured", "Platforms", "Rating", "ReleaseYear", "ReviewDate", "ReviewText", "Reviewer", "Title" },
                values: new object[,]
                {
                    { 6, "https://upload.wikimedia.org/wikipedia/en/4/44/Red_Dead_Redemption_II.jpg", null, "Rockstar Games", "Open World,Shooter,RPG", false, "PC", 10.0m, 2018, new DateTime(2025, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "I have a plan.", "Ella S", "Red Dead Redemption 2" },
                    { 7, "https://i1.sndcdn.com/artworks-EioFkgzPYZ8dFdQc-g71gJA-t1080x1080.jpg", null, "Funkin' Crew", "Rhythm,Music", false, "PC", 10.0m, 2019, new DateTime(2025, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rhythm game perfection.", "Ella S", "Friday Night Funkin'" },
                    { 8, "https://cdn.cloudflare.steamstatic.com/steam/apps/319510/header.jpg", null, "Scott Cawthon", "Horror", false, "PC,Moblie,Console", 10.0m, 2014, new DateTime(2025, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Single handedly the best horror franchise out there.", "Ella S", "Five Nights At Freddy's (Series)" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}

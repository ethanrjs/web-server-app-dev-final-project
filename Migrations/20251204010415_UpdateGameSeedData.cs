using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_server_app_dev_final.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGameSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CoverImageUrl", "Description", "Developer", "Genres", "IsFeatured", "Platforms", "Rating", "ReleaseYear", "ReviewDate", "ReviewText", "Reviewer", "Title" },
                values: new object[] { 5, "https://tse1.mm.bing.net/th/id/OIP.4D_3COBMYkVMCYYWQ7KCLwHaLH?cb=ucfimg2&ucfimg=1&rs=1&pid=ImgDetMain&o=7&rm=3", null, "Afterthought LLC", "Simulation,Survival,Horror", false, "PC", 10.0m, 2015, new DateTime(2025, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Withstand what the island throws at you, no matter the cost.", "Ella S", "The Isle" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}

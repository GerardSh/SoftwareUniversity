using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Horizons.Migrations
{
    /// <inheritdoc />
    public partial class FavoritesCount_Removed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavoritesCount",
                table: "Destinations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FavoritesCount",
                table: "Destinations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

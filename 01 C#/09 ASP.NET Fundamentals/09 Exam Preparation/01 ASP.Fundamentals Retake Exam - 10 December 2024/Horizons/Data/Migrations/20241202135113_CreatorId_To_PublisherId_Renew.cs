using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Horizons.Migrations
{
    /// <inheritdoc />
    public partial class CreatorId_To_PublisherId_Renew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_AspNetUsers_CreatorId",
                table: "Destinations");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_CreatorId",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Destinations");

            migrationBuilder.AlterColumn<string>(
                name: "PublisherId",
                table: "Destinations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_PublisherId",
                table: "Destinations",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_AspNetUsers_PublisherId",
                table: "Destinations",
                column: "PublisherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_AspNetUsers_PublisherId",
                table: "Destinations");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_PublisherId",
                table: "Destinations");

            migrationBuilder.AlterColumn<string>(
                name: "PublisherId",
                table: "Destinations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Destinations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_CreatorId",
                table: "Destinations",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_AspNetUsers_CreatorId",
                table: "Destinations",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

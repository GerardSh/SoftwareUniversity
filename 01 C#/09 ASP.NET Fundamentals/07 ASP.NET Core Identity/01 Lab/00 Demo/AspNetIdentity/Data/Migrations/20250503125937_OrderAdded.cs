using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetIdentity.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrderAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The unique identifier for the order.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date and time the order was placed."),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The price of the order."),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false, comment: "The user who placed the order.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "An order placed by a user.");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}

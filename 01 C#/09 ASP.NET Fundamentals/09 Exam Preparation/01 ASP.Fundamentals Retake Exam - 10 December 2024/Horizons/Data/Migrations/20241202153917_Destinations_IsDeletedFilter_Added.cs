using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Horizons.Migrations
{
    /// <inheritdoc />
    public partial class Destinations_IsDeletedFilter_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7699db7d-964f-4782-8209-d76562e0fece",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ad2299c-ca2f-48b2-a2d0-3126281d111a", "AQAAAAIAAYagAAAAEIcb7Egf8v+2TKNpiTQYp2keF6ht+O/iMw9ZJN/5KQqDBphrmsdgPhHnB7Wb+DJeaw==", "f6208567-53ce-4190-9176-5ef706154062" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2024, 12, 2, 17, 39, 16, 506, DateTimeKind.Local).AddTicks(5460));

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2024, 12, 2, 17, 39, 16, 506, DateTimeKind.Local).AddTicks(5508));

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2024, 12, 2, 17, 39, 16, 506, DateTimeKind.Local).AddTicks(5511));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7699db7d-964f-4782-8209-d76562e0fece",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62b9de73-62ba-4230-98b9-f361690b3733", "AQAAAAIAAYagAAAAEHIB31rhMQcaOG39TSLgB6FlYxgcZ0JV5n9FamguuoXVGfxWZ0sDIyT6d39+Hc1MsA==", "6146cfdd-f74b-4f12-9b18-0c7544e1abb8" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2024, 12, 2, 16, 42, 59, 908, DateTimeKind.Local).AddTicks(1935));

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2024, 12, 2, 16, 42, 59, 908, DateTimeKind.Local).AddTicks(1992));

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2024, 12, 2, 16, 42, 59, 908, DateTimeKind.Local).AddTicks(1996));
        }
    }
}

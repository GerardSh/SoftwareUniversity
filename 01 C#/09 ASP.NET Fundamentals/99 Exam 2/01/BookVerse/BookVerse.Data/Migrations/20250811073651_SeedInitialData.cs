using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookVerse.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd", 0, "8290066b-f18c-43a5-bc59-7ad54d90aaa5", "admin@bookverse.com", true, false, null, "ADMIN@BOOKVERSE.COM", "ADMIN@BOOKVERSE.COM", "AQAAAAIAAYagAAAAEPi3iHhIZC7TPP6oF0quAQqZPcdEuwW/XcyzBpXRgBKW8zsx3dPHGW515f4uD/7ELQ==", null, false, "3a7c675a-d1b0-48ec-8206-8742937c00b1", false, "admin@bookverse.com" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fantasy" },
                    { 2, "Thriller" },
                    { 3, "Romance" },
                    { 4, "Sci-Fi" },
                    { 5, "History" },
                    { 6, "Non-Fiction" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CoverImageUrl", "Description", "GenreId", "PublishedOn", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 1, "https://m.media-amazon.com/images/I/9187Qn8bL6L._UF1000,1000_QL80_.jpg", "Emily Harper (released 2015): A quiet village, a hidden path, and a choice that changes everything.", 1, new DateTime(2025, 8, 11, 10, 36, 51, 202, DateTimeKind.Local).AddTicks(295), "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd", "Whispers of the Mountain" },
                    { 2, "https://m.media-amazon.com/images/I/719g0mh9f2L._UF1000,1000_QL80_.jpg", "Michael Turner (released: 2017): An investigator follows a trail of secrets through a city shrouded in mystery.", 2, new DateTime(2025, 8, 11, 10, 36, 51, 202, DateTimeKind.Local).AddTicks(347), "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd", "Shadows in the Fog" },
                    { 3, "https://m.media-amazon.com/images/I/71zwodP9GzL._UF1000,1000_QL80_.jpg", "Sarah Collins (released 2020): A touching story about love, distance, and the power of written words.", 3, new DateTime(2025, 8, 11, 10, 36, 51, 202, DateTimeKind.Local).AddTicks(351), "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd", "Letters from the Heart" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

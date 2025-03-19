using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCinemaDbCodeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Cinema identifier"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "Cinema name"),
                    Location = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "Cinema location"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Shows if cinema is deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.Id);
                },
                comment: "Cinemas in the system");

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Movie identifier"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Movie title"),
                    Genre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Movie genre"),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Movie release date"),
                    Director = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Movie director"),
                    Duration = table.Column<int>(type: "int", nullable: false, comment: "Movie duration"),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false, comment: "Movie description"),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true, comment: "Movie image url from the image store"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Shows if movie is deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                },
                comment: "Movie in the system");

            migrationBuilder.CreateTable(
                name: "ApplicationUserMovies",
                columns: table => new
                {
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the user"),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the movie"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Shows if movie from user watchlist is deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserMovies", x => new { x.ApplicationUserId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserMovies_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationUserMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                },
                comment: "Movie watchlist for system user");

            migrationBuilder.CreateTable(
                name: "CinemaMovies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the movie"),
                    CinemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the cinema"),
                    AvailableTickets = table.Column<int>(type: "int", nullable: false, comment: "Amount of available tickets for this movie in this cinema"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Shows if movie in a cinema is deleted"),
                    Showtimes = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true, defaultValue: "00000", comment: "Showtimes for the movie in a cinema")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CinemaMovies_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CinemaMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                },
                comment: "Movies in a cinema with available tickets and schedule");

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Ticket identifier"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Ticket price"),
                    CinemaMovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the CinemaMovie projection entity"),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the user bought the ticket")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_CinemaMovies_CinemaMovieId",
                        column: x => x.CinemaMovieId,
                        principalTable: "CinemaMovies",
                        principalColumn: "Id");
                },
                comment: "Tickets in the system");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserMovies_MovieId",
                table: "ApplicationUserMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaMovies_CinemaId_MovieId",
                table: "CinemaMovies",
                columns: new[] { "CinemaId", "MovieId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CinemaMovies_MovieId",
                table: "CinemaMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ApplicationUserId",
                table: "Tickets",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CinemaMovieId",
                table: "Tickets",
                column: "CinemaMovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserMovies");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "CinemaMovies");

            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}

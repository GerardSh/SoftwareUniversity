using System.Text.Json;

using CinemaApp.Data.Dtos;
using CinemaApp.Data.Models;
using CinemaApp.Data.Seeding.Interfaces;
using CinemaApp.Data.Utilities.Interfaces;
using static CinemaApp.Common.OutputMessages.ErrorMessages;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CinemaApp.Data.Seeding
{
    public class CinemaMovieSeeder : BaseSeeder<CinemaMovieSeeder>, IEntitySeeder
    {
        private readonly CinemaDbContext dbContext;

        public CinemaMovieSeeder(CinemaDbContext dbContext, IValidator entityValidator,
            ILogger<CinemaMovieSeeder> logger) : base(entityValidator, logger)
        {
            this.dbContext = dbContext;
        }

        public override string FilePath
            => Path.Combine(AppContext.BaseDirectory, "Files", "cinemasMovies.json");

        public async Task SeedEntityData()
        {
            await this.ImportCinemasMoviesFromJson();
        }

        private async Task ImportCinemasMoviesFromJson()
        {
            string cinemasMoviesStr = await File.ReadAllTextAsync(this.FilePath);

            try
            {
                CinemaMovieDto[]? cinemaMovieDtos =
                JsonSerializer.Deserialize<CinemaMovieDto[]>(cinemasMoviesStr);
                if (cinemaMovieDtos != null && cinemaMovieDtos.Length > 0)
                {
                    ICollection<CinemaMovie> validCinemaMovies = new List<CinemaMovie>();
                    foreach (CinemaMovieDto cinemaMovieDto in cinemaMovieDtos)
                    {
                        if (!this.EntityValidator.IsValid(cinemaMovieDto))
                        {
                            // Log the message
                            this.Logger
                                .LogWarning(BuildEntityValidatorWarningMessage(nameof(CinemaMovie)));

                            // Skip the current DTO instance
                            continue;
                        }

                        string[] cinemaInfo = cinemaMovieDto
                            .Cinema
                            .Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                        string cinemaName = cinemaInfo[0];
                        string? cinemaLocation = cinemaInfo.Length > 1 ?
                            cinemaInfo[1] : null;

                        // Build the query for extracting Cinema using Query Tree
                        IQueryable<Cinema> cinemaQuery = dbContext
                            .Cinemas
                            .Where(c => c.Name == cinemaName);
                        if (cinemaLocation != null)
                        {
                            cinemaQuery = cinemaQuery
                                .Where(c => c.Location == cinemaLocation);
                        }

                        Cinema? cinema = await cinemaQuery
                            .SingleOrDefaultAsync();
                        Movie? movie = await dbContext
                            .Movies
                            .FirstOrDefaultAsync(m => m.Title == cinemaMovieDto.Movie);
                        if (cinema == null || movie == null)
                        {
                            // Non-existing movie or cinema => cannot import the MovieCinema DTO!
                            string logMessage = string.Format(EntityImportError, nameof(CinemaMovie)) +
                                                ReferencedEntityMissing;

                            // Log warning message
                            this.Logger.LogWarning(logMessage);

                            // Skip the current DTO instance
                            continue;
                        }

                        CinemaMovie? existingProjection = await dbContext
                            .CinemaMovies
                            .FirstOrDefaultAsync(cm => cm.CinemaId == cinema.Id &&
                                                       cm.MovieId == movie.Id);
                        if (existingProjection != null &&
                            existingProjection.Showtimes == cinemaMovieDto.Showtimes)
                        {
                            // Log warning message
                            this.Logger.LogWarning(EntityInstanceAlreadyExist);

                            // Skip the current DTO instance
                            continue;
                        }

                        CinemaMovie newCinemaMovie = new CinemaMovie()
                        {
                            CinemaId = cinema.Id,
                            MovieId = movie.Id,
                            AvailableTickets = cinemaMovieDto.AvailableTickets,
                            IsDeleted = cinemaMovieDto.IsDeleted,
                            Showtimes = cinemaMovieDto.Showtimes
                        };
                        validCinemaMovies.Add(newCinemaMovie);
                    }

                    await dbContext.CinemaMovies.AddRangeAsync(validCinemaMovies);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                this.Logger.LogError(e.Message);
                throw;
            }
        }
    }
}

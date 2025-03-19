using CinemaApp.Data.Dtos;
using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace CinemaApp.Data.Utilities
{
    public static class DataProcessor
    {
        public static async Task ImportMoviesFromJson (CinemaDbContext context)
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Files", "movies.json");
            string moviesStr = await File.ReadAllTextAsync(path);
            var movies = JsonSerializer.Deserialize<List<Movie>>(moviesStr);

            if (movies != null && movies.Count > 0)
            {
                List<Guid> moviesIds = movies.Select(m => m.Id).ToList();
                if (await context.Movies.AnyAsync(m => moviesIds.Contains(m.Id)) == false)
                {
                    await context.Movies.AddRangeAsync(movies);
                    await context.SaveChangesAsync();
                }
            }
        }

        public static async Task ImportCinemasMoviesFromJson (CinemaDbContext context)
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Files", "cinemasMovies.json");
            string cinemasMoviesStr = await File.ReadAllTextAsync(path);
            var cinemasMovies = JsonSerializer.Deserialize<List<CinemaMovieDto>>(cinemasMoviesStr);

            var movieTitles = cinemasMovies.Select(m => m.Movie).ToArray();
            var cinemas = cinemasMovies
                .Select(cm => new
                {
                    Key = cm.Cinema,
                    Name = cm.Cinema
                        .Split('-', StringSplitOptions.RemoveEmptyEntries)
                        .First(),
                    Location = cm.Cinema.Contains('-')
                        ? cm.Cinema.Split('-', StringSplitOptions.RemoveEmptyEntries).Last()
                        : string.Empty
                })
                .GroupBy(c => c.Key)
                .ToDictionary(k => k.Key, v => new Cinema() 
                {
                    Id = Guid.NewGuid(),
                    Name = v.First().Name,
                    Location = v.First().Location
                });

            var movies = await context.Movies
                .Where(m => movieTitles.Contains(m.Title))
                .ToDictionaryAsync(k => k.Title, v => v);

            List<CinemaMovie> cinemaMoviesEntities = new List<CinemaMovie>();

            foreach (var cm in cinemasMovies)
            {
                var cinemaMovie = new CinemaMovie()
                {
                    Id = Guid.NewGuid(),
                    AvailableTickets = cm.AvailableTickets,
                    Cinema = cinemas[cm.Cinema],
                    Movie = movies[cm.Movie],
                    Showtimes = cm.Showtimes
                };

                cinemaMoviesEntities.Add(cinemaMovie);
            }

            await context.CinemaMovies.AddRangeAsync(cinemaMoviesEntities);
            await context.SaveChangesAsync();
        }

        public static async Task ImportTicketsFromXml (CinemaDbContext context)
        {
            throw new NotImplementedException();
        }
    }
}

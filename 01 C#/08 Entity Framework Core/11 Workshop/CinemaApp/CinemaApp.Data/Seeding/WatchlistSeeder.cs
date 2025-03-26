using CinemaApp.Data.Dtos;
using CinemaApp.Data.Models;
using CinemaApp.Data.Seeding.Interfaces;
using CinemaApp.Data.Utilities.Interfaces;
using static CinemaApp.Common.OutputMessages.ErrorMessages;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CinemaApp.Data.Seeding
{
    public class WatchlistSeeder : BaseSeeder<WatchlistSeeder>, IEntitySeeder, IXmlSeeder
    {
        private readonly CinemaDbContext dbContext;
        private readonly IXmlHelper xmlHelper;

        private readonly UserManager<ApplicationUser> userManager;

        public WatchlistSeeder(CinemaDbContext dbContext, IXmlHelper xmlHelper,
            UserManager<ApplicationUser> userManager, IValidator entityValidator, 
            ILogger<WatchlistSeeder> logger) : base(entityValidator, logger)
        {
            this.dbContext = dbContext;
            this.xmlHelper = xmlHelper;

            this.userManager = userManager;
        }

        public override string FilePath
            => Path.Combine(AppContext.BaseDirectory, "Files", "watchlists.xml");

        public string RootName
            => "Users";

        public IXmlHelper XmlHelper
            => this.xmlHelper;

        public async Task SeedEntityData()
        {
            await this.ImportWatchlistFromXml();
        }

        private async Task ImportWatchlistFromXml()
        {
            string watchlistStr = await File.ReadAllTextAsync(this.FilePath);

            try
            {
                UserWatchlistDto[]? watchlistDtos = this.XmlHelper
                .Deserialize<UserWatchlistDto[]>(watchlistStr, this.RootName);
                if (watchlistDtos != null && watchlistDtos.Length > 0)
                {
                    ICollection<ApplicationUserMovie> validWatchlists = new List<ApplicationUserMovie>();
                    foreach (UserWatchlistDto watchlistDto in watchlistDtos)
                    {
                        if (!this.EntityValidator.IsValid(watchlistDto))
                        {
                            // Log warning message
                            this.Logger.LogWarning(BuildEntityValidatorWarningMessage(nameof(ApplicationUserMovie)));

                            // Skip current Watchlist DTO instance
                            continue;
                        }

                        ApplicationUser? user = await userManager
                            .FindByNameAsync(watchlistDto.Username);
                        if (user == null)
                        {
                            // Log warning message
                            this.Logger.LogWarning(ReferencedEntityMissing);

                            // Skip current Watchlist DTO instance
                            continue;
                        }

                        foreach (UserWatchlistMovieDto movieDto in watchlistDto.Movies)
                        {
                            if (!this.EntityValidator.IsValid(movieDto))
                            {
                                // Log warning message
                                this.Logger.LogWarning(BuildEntityValidatorWarningMessage(nameof(ApplicationUserMovie)));

                                // Skip current Movie DTO instance
                                continue;
                            }

                            Movie? movie = await dbContext
                                .Movies
                                .FirstOrDefaultAsync(m => m.Title == movieDto.Title);
                            if (movie == null)
                            {
                                // Log warning message
                                this.Logger.LogWarning(ReferencedEntityMissing);

                                // Skip current Movie DTO instance
                                continue;
                            }

                            bool watchListExists = await dbContext
                                .ApplicationUserMovies
                                .AnyAsync(um => um.MovieId == movie.Id &&
                                           um.ApplicationUserId == user.Id);
                            if (watchListExists)
                            {
                                // Log warning message
                                this.Logger.LogWarning(EntityInstanceAlreadyExist);

                                // Skip current Movie DTO instance
                                continue;
                            }

                            ApplicationUserMovie userMovie = new ApplicationUserMovie()
                            {
                                ApplicationUser = user,
                                Movie = movie,
                            };
                            validWatchlists.Add(userMovie);
                        }
                    }

                    await dbContext.ApplicationUserMovies.AddRangeAsync(validWatchlists);
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

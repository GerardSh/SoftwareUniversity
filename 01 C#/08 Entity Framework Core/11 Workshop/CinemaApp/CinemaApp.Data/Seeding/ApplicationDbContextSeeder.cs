using CinemaApp.Data.Models;
using CinemaApp.Data.Utilities.Interfaces;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

using CinemaApp.Data.Seeding.Interfaces;

namespace CinemaApp.Data.Seeding
{
    public class ApplicationDbContextSeeder : IDbSeeder
    {
        private readonly CinemaDbContext dbContext;

        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;

        private readonly IValidator entityValidator;
        private readonly IXmlHelper xmlHelper;

        private readonly ICollection<IEntitySeeder> entitySeeders;

        // TODO: Implement ILogger factory pattern to provide the logger instances
        public ApplicationDbContextSeeder(CinemaDbContext dbContext, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole<Guid>> roleManager, IValidator entityValidator,
            IXmlHelper xmlHelper, ILogger<MoviesSeeder> movieLogger,
            ILogger<CinemaMovieSeeder> cinemaMovieLogger, ILogger<TicketSeeder> ticketLogger,
            ILogger<WatchlistSeeder> watchlistLogger, ILogger<IdentitySeeder> identityLogger)
        {
            this.dbContext = dbContext;

            this.userManager = userManager;
            this.roleManager = roleManager;

            this.entityValidator = entityValidator;
            this.xmlHelper = xmlHelper;

            this.entitySeeders = new List<IEntitySeeder>();
            this.InitializeDbSeeders(movieLogger, cinemaMovieLogger, ticketLogger, watchlistLogger, identityLogger);
        }

        public async Task SeedData()
        {
            foreach (IEntitySeeder entitySeeder in this.entitySeeders)
            {
                await entitySeeder.SeedEntityData();
            }
        }

        private void InitializeDbSeeders(ILogger<MoviesSeeder> movieLogger, ILogger<CinemaMovieSeeder> cinemaMovieLogger, 
            ILogger<TicketSeeder> ticketLogger, ILogger<WatchlistSeeder> watchlistLogger, ILogger<IdentitySeeder> identityLogger)
        {
            // TODO: Refactor this using Reflection API to create instances of the entity seeders run-time
            this.entitySeeders.Add(new MoviesSeeder(this.dbContext, this.entityValidator, movieLogger));
            this.entitySeeders.Add(new CinemaMovieSeeder(this.dbContext, this.entityValidator, cinemaMovieLogger));
            this.entitySeeders.Add(new TicketSeeder(this.dbContext, this.xmlHelper, this.entityValidator, ticketLogger));
            this.entitySeeders.Add(new WatchlistSeeder(this.dbContext, this.xmlHelper, this.userManager, this.entityValidator, watchlistLogger));
            this.entitySeeders.Add(new IdentitySeeder(this.dbContext, this.userManager, this.roleManager, this.entityValidator, identityLogger));
        }
    }
}

using CinemaApp.Data.Dtos;
using CinemaApp.Data.Models;
using CinemaApp.Data.Seeding.Interfaces;
using CinemaApp.Data.Utilities.Interfaces;
using static CinemaApp.Common.OutputMessages.ErrorMessages;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CinemaApp.Data.Seeding
{
    public class TicketSeeder : BaseSeeder<TicketSeeder>, IEntitySeeder, IXmlSeeder
    {
        private readonly CinemaDbContext dbContext;

        private readonly IXmlHelper xmlHelper;

        public TicketSeeder(CinemaDbContext dbContext, IXmlHelper xmlHelper, 
            IValidator entityValidator, ILogger<TicketSeeder> logger) 
            : base(entityValidator, logger)
        {
            this.dbContext = dbContext;
            this.xmlHelper = xmlHelper;
        }

        public override string FilePath 
            => Path.Combine(AppContext.BaseDirectory, "Files", "tickets.xml");

        public string RootName
            => "Tickets";

        public IXmlHelper XmlHelper
            => this.xmlHelper;

        public async Task SeedEntityData()
        {
            await this.ImportTicketsFromXml();
        }

        private async Task ImportTicketsFromXml()
        {
            string ticketsStr = await File.ReadAllTextAsync(this.FilePath);

            try
            {
                TicketDto[]? ticketDtos = this.XmlHelper
                    .Deserialize<TicketDto[]>(ticketsStr, this.RootName);
                if (ticketDtos != null && ticketDtos.Length > 0)
                {
                    ICollection<Ticket> validTickets = new List<Ticket>();
                    foreach (TicketDto ticketDto in ticketDtos)
                    {
                        if (!this.EntityValidator.IsValid(ticketDto))
                        {
                            // Log warning message
                            this.Logger.LogWarning(BuildEntityValidatorWarningMessage(nameof(Ticket)));

                            // Skip current DTO instance
                            continue;
                        }

                        bool isPriceValid = decimal
                            .TryParse(ticketDto.Price, out decimal ticketPrice);
                        bool isMovieIdValid = Guid
                            .TryParse(ticketDto.MovieId, out Guid ticketMovieId);
                        bool isCinemaIdValid = Guid
                            .TryParse(ticketDto.CinemaId, out Guid ticketCinemaId);
                        bool isUserIdValid = Guid
                            .TryParse(ticketDto.UserId, out Guid ticketUserId);
                        if (!isPriceValid || !isMovieIdValid ||
                            !isCinemaIdValid || !isUserIdValid)
                        {
                            string logMessage = string.Format(EntityImportError, nameof(Ticket)) + EntityDataParseError;

                            this.Logger.LogWarning(logMessage);

                            continue;
                        }

                        CinemaMovie? ticketCinemaMovie = await dbContext
                            .CinemaMovies
                            .SingleOrDefaultAsync(cm => cm.CinemaId == ticketCinemaId &&
                                                        cm.MovieId == ticketMovieId);
                        ApplicationUser? ticketUser = await dbContext
                            .Users
                            .SingleOrDefaultAsync(u => u.Id == ticketUserId);
                        if (ticketUser == null || ticketCinemaMovie == null)
                        {
                            // Non-existing movie or cinema => cannot import the MovieCinema DTO!
                            string logMessage = string.Format(EntityImportError, nameof(Ticket)) +
                                                ReferencedEntityMissing;

                            // Log warning message
                            this.Logger.LogWarning(logMessage);

                            // Skip the current DTO instance
                            continue;
                        }

                        bool ticketExists = await dbContext
                            .Tickets
                            .AnyAsync(t => t.ApplicationUserId == ticketUser.Id &&
                                           t.CinemaMovieId == ticketCinemaMovie.Id);
                        if (ticketExists)
                        {
                            // Log warning message
                            this.Logger.LogWarning(EntityInstanceAlreadyExist);

                            // Skip current DTO instance
                            continue;
                        }

                        Ticket newTicket = new Ticket()
                        {
                            Price = ticketPrice,
                            ApplicationUserId = ticketUserId,
                            CinemaMovieId = ticketCinemaMovie.Id
                        };
                        validTickets.Add(newTicket);
                    }

                    await dbContext.Tickets.AddRangeAsync(validTickets);
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

namespace BlackBird.TicketManagement.Infrastructure.TransverseRepositories.Clock;

public interface IClockRepository
{
    DateTimeOffset UtcNow();
}

namespace BlackBird.TicketManagement.Infrastructure.TransverseRepositories.Clock;

public class ClockRepository : IClockRepository
{
    public DateTimeOffset UtcNow()
    {
        var returnValue = DateTimeOffset.UtcNow;
        return returnValue;
    }
}

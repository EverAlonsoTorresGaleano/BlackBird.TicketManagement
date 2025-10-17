using BlackBird.TicketManagement.Infrastructure.Models;

namespace BlackBird.TicketManagement.Infrastructure.ModelExtension;

public record TicketHistory
{
    public Ticket? Ticket { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
}

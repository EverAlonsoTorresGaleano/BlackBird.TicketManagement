namespace BlackBird.TicketManagement.Entities.ModelDTO;

public record TicketHistoryDTO
{
    public TicketDTO? Ticket { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
}

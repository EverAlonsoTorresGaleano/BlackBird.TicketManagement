namespace BlackBird.TicketManagement.Entities.ModelDTO;

public record TicketDTO
{
    public long TicketId { get; set; }

    public long TicketTypeFk { get; set; }

    public long TicketStateFk { get; set; }

    public long CreatedByUserFk { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? Details { get; set; }

    public string? Audience { get; set; }

    public string? Localization { get; set; }

    public DateTime? EventDate { get; set; }

    public long? UpdatedByUserFk { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public long? AsignedToUserFk { get; set; }

    public string TicketTypeName { get; set; }

    public string TicketStateName { get; set; }
}

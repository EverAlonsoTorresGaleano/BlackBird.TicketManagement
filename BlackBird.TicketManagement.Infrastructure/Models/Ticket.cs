namespace BlackBird.TicketManagement.Infrastructure.Models;

public partial class Ticket
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

    public virtual User? AsignedToUserFkNavigation { get; set; }

    public virtual User CreatedByUserFkNavigation { get; set; } = null!;

    public virtual GeneralTypeItem TicketStateFkNavigation { get; set; } = null!;

    public virtual GeneralTypeItem TicketTypeFkNavigation { get; set; } = null!;

    public virtual User? UpdatedByUserFkNavigation { get; set; }
}

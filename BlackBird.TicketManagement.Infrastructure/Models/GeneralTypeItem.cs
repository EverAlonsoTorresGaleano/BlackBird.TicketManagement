namespace BlackBird.TicketManagement.Infrastructure.Models;

public partial class GeneralTypeItem
{
    public long GeneralTypeItemId { get; set; }

    public long GeneralTypeGroupFk { get; set; }

    public string ItemName { get; set; } = null!;

    public virtual GeneralTypeGroup GeneralTypeGroupFkNavigation { get; set; } = null!;

    public virtual ICollection<Ticket> TicketTicketStateFkNavigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketTicketTypeFkNavigations { get; set; } = new List<Ticket>();
}

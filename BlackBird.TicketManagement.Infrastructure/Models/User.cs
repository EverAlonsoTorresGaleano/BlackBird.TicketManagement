using System;
using System.Collections.Generic;

namespace BlackBird.TicketManagement.Infrastructure.Models;

public partial class User
{
    public long UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserSecret { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public bool IsLocked { get; set; }

    public DateTime? LastAccess { get; set; }

    public long RoleFk { get; set; }

    public virtual UserRole RoleFkNavigation { get; set; } = null!;

    public virtual ICollection<Ticket> TicketAsignedToUserFkNavigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketCreatedByUserFkNavigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketUpdatedByUserFkNavigations { get; set; } = new List<Ticket>();
}

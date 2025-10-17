using System;
using System.Collections.Generic;

namespace BlackBird.TicketManagement.Infrastructure.Models;

public partial class UserRole
{
    public long UserRoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public bool IsEnabled { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}

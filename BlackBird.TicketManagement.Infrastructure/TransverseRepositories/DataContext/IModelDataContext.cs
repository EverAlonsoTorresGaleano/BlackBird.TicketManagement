using BlackBird.TicketManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace BlackBird.TicketManagement.Infrastructure.TransverseRepositories.DataContext;

public interface IModelDataContext : IDisposable
{
    DbSet<GeneralTypeGroup> GeneralTypeGroups { get; set; }

    DbSet<GeneralTypeItem> GeneralTypeItems { get; set; }

    DbSet<Ticket> Tickets { get; set; }

    DbSet<User> Users { get; set; }

    DbSet<UserRole> UserRoles { get; set; }

}

using BlackBird.TicketManagement.Infrastructure.TransverseRepositories.DataContext;
using Microsoft.EntityFrameworkCore;

namespace BlackBird.TicketManagement.Infrastructure.TransverseRepositories.DataContextFactory;

public interface IDataContextFactory : IDbContextFactory<ModelDataContext>
{
    new ModelDataContext CreateDbContext();

}

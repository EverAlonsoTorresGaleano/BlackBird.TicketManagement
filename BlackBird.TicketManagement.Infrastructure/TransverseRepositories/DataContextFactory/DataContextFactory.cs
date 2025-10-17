using BlackBird.TicketManagement.Entities.Options;
using BlackBird.TicketManagement.Infrastructure.TransverseRepositories.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;

namespace BlackBird.TicketManagement.Infrastructure.TransverseRepositories.DataContextFactory;

public class DataContextFactory(IOptions<ConnectionStringOptions> connectionStringOptions) : IDataContextFactory
{

    ConnectionStringOptions? connectionStringOptionsValues = connectionStringOptions?.Value;
    public ModelDataContext CreateDbContext()
    {
        ModelDataContext context;

        var builder = new DbContextOptionsBuilder<ModelDataContext>();
        builder.UseSqlServer(connectionStringOptionsValues.AzureSQLServer, delegate (SqlServerDbContextOptionsBuilder sqlOptions)
        {
            sqlOptions.EnableRetryOnFailure(connectionStringOptionsValues.RetryCount, TimeSpan.FromSeconds(connectionStringOptionsValues.MaxRetryDelay), null);
            sqlOptions.CommandTimeout(connectionStringOptionsValues.TimeOut);
        });
        context = new ModelDataContext(builder.Options);
        return context;

    }
}

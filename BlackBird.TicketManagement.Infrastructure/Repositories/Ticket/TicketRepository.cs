using BlackBird.TicketManagement.Entities.ModelDTO;
using BlackBird.TicketManagement.Infrastructure.Extensions;
using BlackBird.TicketManagement.Infrastructure.TransverseRepositories.DataContextFactory;
using Microsoft.EntityFrameworkCore;

namespace BlackBird.TicketManagement.Infrastructure.Repositories.Ticket;

public class TicketRepository(IDataContextFactory dataContextFactory) : ITicketRepository
{
    public async Task<TicketDTO?> AddTicket(TicketDTO ticketDTO)
    {
        var context = dataContextFactory.CreateDbContext();
        var ticket = ticketDTO.ToTicket();
        context.Tickets.Add(ticket!);
        await context.SaveChangesAsync();
        return ticket!.ToTicketDTO();
    }

    public async Task<bool?> DeleteTicket(long ticketId)
    {
        var context = dataContextFactory.CreateDbContext();
        context.Tickets.RemoveRange(context.Tickets.Where(t => t.TicketId == ticketId));
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<List<TicketDTO>?> GetAllTicket()
    {
        var context = dataContextFactory.CreateDbContext();
        var resturnList = await context.Tickets.Include(t => t.TicketStateFkNavigation).Include(t => t.TicketTypeFkNavigation).ToListAsync();
        return resturnList.Select(t => t.ToTicketDTO()!).ToList();
    }

    public async Task<TicketDTO?> GetTicketById(long ticketId)
    {
        var context = dataContextFactory.CreateDbContext();
        var resturnValue = await context.Tickets.Include(t => t.TicketStateFkNavigation).Include(t => t.TicketTypeFkNavigation)
            .FirstOrDefaultAsync(t => t.TicketId == ticketId);
        return resturnValue.ToTicketDTO();
    }

    public async Task<List<TicketHistoryDTO?>> GetTicketHistoryById(long ticketId)
    {
        TicketHistoryDTO tempObject = new();
        var context = dataContextFactory.CreateDbContext();
        var returnList = context.Tickets.TemporalAll()
            .Where(t => t.TicketId == ticketId)
            .OrderByDescending(t => EF.Property<DateTime>(t, nameof(tempObject.ValidFrom)))
            .Select(t => new TicketHistoryDTO
            {
                Ticket = t.ToTicketDTO(),
                ValidFrom = EF.Property<DateTime>(t, nameof(tempObject.ValidFrom)),
                ValidTo = EF.Property<DateTime>(t, nameof(tempObject.ValidTo))
            }).ToList();

        return returnList;
    }



    public async Task<TicketDTO?> UpdateTicket(TicketDTO ticketDTO)
    {
        TicketDTO returnValue = ticketDTO;
        var context = dataContextFactory.CreateDbContext();
        var ticket = ticketDTO.ToTicket();

        var ticketDb = await context.Tickets.FirstOrDefaultAsync(t => t.TicketId == ticket.TicketId);
        if (ticketDb is not null)
        {
            ticketDb = ticket;
            await context.SaveChangesAsync();
            returnValue = ticketDb!.ToTicketDTO()!;
        }

        //TODO: Notificar cambios importantes en los tickets mediante eventos internos del sistema. 
        // Podriamos crear un mensaje en un Queue de Azure
        // Y crear un Azure Function Que el trigger sea un nuevo mensaje en la Queue
        // Para que un Correo con estos cambios.
        // Pero no tento una subscripcion de Azure para probar esto.    

        return returnValue;
    }
}

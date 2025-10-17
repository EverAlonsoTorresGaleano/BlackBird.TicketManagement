using BlackBird.TicketManagement.Entities.ModelDTO;

namespace BlackBird.TicketManagement.Infrastructure.Repositories.Ticket;

public interface ITicketRepository
{
    Task<TicketDTO?> AddTicket(TicketDTO ticket);
    Task<bool?> DeleteTicket(long ticketId);
    Task<List<TicketDTO>?> GetAllTicket();
    Task<TicketDTO?> GetTicketById(long ticketId);
    Task<List<TicketHistoryDTO>> GetTicketHistoryById(long ticketId);
    Task<TicketDTO?> UpdateTicket(TicketDTO ticket);
}

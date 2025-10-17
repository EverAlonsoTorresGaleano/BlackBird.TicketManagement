
using BlackBird.TicketManagement.Entities.ModelDTO;

namespace BlackBird.TicketManagement.Application.Services.Ticket;

public interface ITicketService
{
    Task<TicketDTO> AddTicket(TicketDTO ticket);
    Task<bool?> DeleteTicket(long ticketId);
    Task<List<TicketDTO>> GetAllTicket();
    Task<TicketDTO> GetTicketById(long ticketId);
    Task<List<TicketHistoryDTO>> GetTicketHistoryById(long ticketId);
    Task<TicketDTO> UpdateTicket(TicketDTO ticket);
}

using BlackBird.TicketManagement.Entities.ModelDTO;
using BlackBird.TicketManagement.Infrastructure.Repositories.Ticket;

namespace BlackBird.TicketManagement.Application.Services.Ticket;

public class TicketService(ITicketRepository ticketRepository) : ITicketService
{
    public async Task<TicketDTO> AddTicket(TicketDTO ticket)
    {
        TicketDTO returnValue = await ticketRepository.AddTicket(ticket);
        return returnValue;
    }

    public async Task<bool?> DeleteTicket(long ticketId)
    {
        bool? returnValue = await ticketRepository.DeleteTicket(ticketId);
        return returnValue;
    }

    public async Task<List<TicketDTO>> GetAllTicket()
    {
        List<TicketDTO> returnValue = await ticketRepository.GetAllTicket();
        return returnValue;
    }

    public async Task<TicketDTO> GetTicketById(long ticketId)
    {
        TicketDTO returnValue = await ticketRepository.GetTicketById(ticketId);
        return returnValue;
    }

    public async Task<List<TicketHistoryDTO>> GetTicketHistoryById(long ticketId)
    {
        List<TicketHistoryDTO> returnValue = await ticketRepository.GetTicketHistoryById(ticketId);
        return returnValue;
    }

    

    public async Task<TicketDTO> UpdateTicket(TicketDTO ticket)
    {
        TicketDTO returnValue = await ticketRepository.UpdateTicket(ticket);
        return returnValue;
    }
}

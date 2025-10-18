using BlackBird.TicketManagement.Entities.ModelDTO;
using BlackBird.TicketManagement.Infrastructure.ModelExtension;
using BlackBird.TicketManagement.Infrastructure.Models;

namespace BlackBird.TicketManagement.Infrastructure.Extensions;

public static class MapperExtensions
{

    public static UserDTO? ToUserDTO(this User dbObject)
    {
        if (dbObject is null)
        {
            return null;
        }
        UserDTO dto = new()
        {
            UserId = dbObject.UserId,
            UserName = dbObject.UserName,
            Name = dbObject.Name,
            LastName = dbObject.LastName,
            Email = dbObject.Email,
            Phone = dbObject.Phone,
            Address = dbObject.Address,
            IsLocked = dbObject.IsLocked,
            LastAccess = dbObject.LastAccess,
            RoleFk = dbObject.RoleFk,
            RoleName = dbObject.RoleFkNavigation?.RoleName ?? string.Empty
        };
        return dto;
    }

    public static User? ToUser(this UserDTO dtoObject)
    {
        if (dtoObject is null)
        {
            return null;
        }
        User dbObject = new()
        {
            UserId = dtoObject.UserId,
            UserName = dtoObject.UserName,
            Name = dtoObject.Name,
            LastName = dtoObject.LastName,
            Email = dtoObject.Email,
            Phone = dtoObject.Phone,
            Address = dtoObject.Address,
            IsLocked = dtoObject.IsLocked,
            LastAccess = dtoObject.LastAccess,
            RoleFk = dtoObject.RoleFk,
        };
        return dbObject;
    }

    public static Ticket? ToTicket(this TicketDTO dtoObject)
    {
        if (dtoObject is null)
        {
            return null;
        }
        Ticket dto = new()
        {
            AsignedToUserFk = dtoObject.AsignedToUserFk,
            CreatedByUserFk = dtoObject.CreatedByUserFk,
            CreatedDate = dtoObject.CreatedDate,
            Details = dtoObject.Details,
            TicketId = dtoObject.TicketId,
            TicketStateFk = dtoObject.TicketStateFk,
            TicketTypeFk = dtoObject.TicketTypeFk,
            UpdatedByUserFk = dtoObject.UpdatedByUserFk,
            Localization = dtoObject.Localization,
            EventDate = dtoObject.EventDate,
            UpdatedDate = dtoObject.UpdatedDate,
            Audience = dtoObject.Audience,
        };
        return dto;
    }

    public static TicketDTO? ToTicketDTO(this Ticket? dbObjectd)
    {
        if (dbObjectd is null)
        {
            return null;
        }
        TicketDTO dto = new()
        {
            AsignedToUserFk = dbObjectd.AsignedToUserFk,
            AsignedToUserName = dbObjectd.AsignedToUserFkNavigation is null ? string.Empty : dbObjectd.AsignedToUserFkNavigation.FullName,
            CreatedByUserFk = dbObjectd.CreatedByUserFk,
            CreatedByUserName = dbObjectd.CreatedByUserFkNavigation is null ? string.Empty : dbObjectd.CreatedByUserFkNavigation.FullName,
            CreatedDate = dbObjectd.CreatedDate,
            Details = dbObjectd.Details,
            TicketId = dbObjectd.TicketId,
            TicketStateFk = dbObjectd.TicketStateFk,
            TicketTypeFk = dbObjectd.TicketTypeFk,
            UpdatedByUserFk = dbObjectd.UpdatedByUserFk,
            Localization = dbObjectd.Localization,
            EventDate = dbObjectd.EventDate,
            UpdatedDate = dbObjectd.UpdatedDate,
            Audience = dbObjectd.Audience,

            TicketStateName = dbObjectd.TicketStateFkNavigation is null ? string.Empty : dbObjectd.TicketStateFkNavigation.ItemName,
            TicketTypeName = dbObjectd.TicketTypeFkNavigation is null ? string.Empty : dbObjectd.TicketTypeFkNavigation.ItemName
        };
        return dto;
    }

    public static TicketHistoryDTO? ToTicketHistoryDTO(this TicketHistory dbObject)
    {
        if (dbObject is null)
        {
            return null;
        }
        TicketHistoryDTO dto = new()
        {
            Ticket = dbObject.Ticket.ToTicketDTO(),
            ValidFrom = dbObject.ValidFrom,
            ValidTo = dbObject.ValidTo
        };
        return dto;
    }

}

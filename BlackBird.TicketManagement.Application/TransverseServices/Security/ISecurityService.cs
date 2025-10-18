using BlackBird.TicketManagement.Entities.ModelDTO;

namespace BlackBird.TicketManagement.Application.TransverseServices.Security;

public interface ISecurityService
{
    Task<UserDTO> AddUser(UserDTO user);
    Task<bool?> DisableUser(long userId);
    Task<List<UserDTO>> GetAllUsers();
    Task<UserDTO> GetUserById(long userId);
    Task<TokenResponseDTO> Login(TokenRequestDTO loginInfo);
}

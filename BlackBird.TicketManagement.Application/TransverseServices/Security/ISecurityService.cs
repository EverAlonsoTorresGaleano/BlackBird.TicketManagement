using BlackBird.TicketManagement.Entities.ModelDTO;

namespace BlackBird.TicketManagement.Application.TransverseServices.Security;

public interface ISecurityService
{
    Task<UserDTO> AddUser(UserDTO user);
    Task<bool?> DisableUser(string userName);
    Task<List<UserDTO>> GetAllUsers();
    Task<UserDTO> GetUserByName(string userName);
    Task<TokenResponseDTO> Login(TokenRequestDTO loginInfo);
}

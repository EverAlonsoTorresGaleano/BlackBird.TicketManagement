using BlackBird.TicketManagement.Entities.ModelDTO;

namespace BlackBird.TicketManagement.Infrastructure.TransverseRepository.Security;

public interface ISecurityRepository
{
    Task<UserDTO> AddUser(UserDTO user);
    Task<bool?> DisableUser(long userId);
    Task<List<UserDTO>> GetAllUsers();
    Task<UserDTO> GetUserById(long userId);
    Task<UserDTO> Login(TokenRequestDTO loginInfo);
}

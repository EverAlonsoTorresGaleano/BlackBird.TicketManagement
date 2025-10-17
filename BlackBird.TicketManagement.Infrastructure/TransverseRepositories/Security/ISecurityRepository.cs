using BlackBird.TicketManagement.Entities.ModelDTO;

namespace BlackBird.TicketManagement.Infrastructure.TransverseRepository.Security;

public interface ISecurityRepository
{
    Task<UserDTO> AddUser(UserDTO user);
    Task<bool?> DisableUser(string userName);
    Task<List<UserDTO>> GetAllUsers();
    Task<UserDTO> GetUserByName(string userName);
    Task<UserDTO> Login(TokenRequestDTO loginInfo);
}

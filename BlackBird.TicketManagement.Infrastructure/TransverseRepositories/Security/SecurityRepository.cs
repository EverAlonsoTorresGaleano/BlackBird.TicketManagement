using BlackBird.TicketManagement.Entities.ModelDTO;
using BlackBird.TicketManagement.Infrastructure.Extensions;
using BlackBird.TicketManagement.Infrastructure.TransverseRepositories.Clock;
using BlackBird.TicketManagement.Infrastructure.TransverseRepositories.DataContextFactory;
using Microsoft.EntityFrameworkCore;

namespace BlackBird.TicketManagement.Infrastructure.TransverseRepository.Security;

public class SecurityRepository(IDataContextFactory dataContextFactory, IClockRepository clockRepository) : ISecurityRepository
{
    public async Task<UserDTO?> Login(TokenRequestDTO loginInfo)
    {
        var context = dataContextFactory.CreateDbContext();
        var userInfo = await context.Users.FirstOrDefaultAsync(u => u.UserName == loginInfo.user_id && u.UserSecret == loginInfo.user_secret);
        if (userInfo is not null)
        {
            userInfo.LastAccess = clockRepository.UtcNow().DateTime;
            await context.SaveChangesAsync();
        }
        return userInfo!.ToUserDTO();
    }
    public async Task<bool?> DisableUser(long userId)
    {
        var context = dataContextFactory.CreateDbContext();
        var userDb = await context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        if (userDb is not null)
        {
            userDb.IsLocked = true;
            await context.SaveChangesAsync();
            return true;
        }
        return null;
    }

    public async Task<UserDTO> GetUserById(long userId)
    {
        var context = dataContextFactory.CreateDbContext();
        var returnValue = await context.Users.Include(u => u.RoleFkNavigation).FirstOrDefaultAsync(u => u.UserId == userId);
        return returnValue!.ToUserDTO()!;
    }

    public async Task<List<UserDTO>> GetAllUsers()
    {
        var context = dataContextFactory.CreateDbContext();
        var returnList = await context.Users.Include(u => u.RoleFkNavigation).ToListAsync();
        return returnList!.Select(u => u.ToUserDTO()!).ToList();
    }

    public async Task<UserDTO> AddUser(UserDTO userDTO)

    {
        var context = dataContextFactory.CreateDbContext();
        var user = userDTO.ToUser();
        context.Users.Add(user!);
        await context.SaveChangesAsync();
        return user!.ToUserDTO();
    }
}

using BlackBird.TicketManagement.Entities.ModelDTO;
using BlackBird.TicketManagement.Entities.Options;
using BlackBird.TicketManagement.Infrastructure.TransverseRepositories.Clock;
using BlackBird.TicketManagement.Infrastructure.TransverseRepository.Security;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlackBird.TicketManagement.Application.TransverseServices.Security;

public class SecurityService(ISecurityRepository securityRepository, IClockRepository clockRepository, IOptions<IdentityServiceServerSettingsOptions> identityServiceServerSettingsOptions) : ISecurityService
{
    private IdentityServiceServerSettingsOptions identityServiceServerSettingsOptionsValues = identityServiceServerSettingsOptions.Value;
    private const string TokenBearerPrefix = "Bearer";
    private const string KeyUserId = "UserId";
    private const string KeyGivenName = "GivenName";
    private const string KeyEmail = "Email";
    public async Task<TokenResponseDTO> Login(TokenRequestDTO loginInfo)
    {
        TokenResponseDTO returnValue = new();
        UserDTO userInfo = await securityRepository.Login(loginInfo);
        if (userInfo is null)
        {
            returnValue = await CreateEmptyJwtTokenAsync(loginInfo);
        }
        else
        {
            returnValue = await CreateJwtTokenAsync(loginInfo, ToClaimsList(userInfo), userInfo, identityServiceServerSettingsOptionsValues);
        }
        return returnValue;
    }


    public async Task<UserDTO> AddUser(UserDTO user)
    {
        UserDTO returnValue = await securityRepository.AddUser(user);
        return returnValue;
    }

    public async Task<bool?> DisableUser(long userId)
    {
        bool? returnValue = await securityRepository.DisableUser(userId);
        return returnValue;
    }

    public async Task<UserDTO> GetUserById(long userId)
    {
        UserDTO returnValue = await securityRepository.GetUserById(userId);
        return returnValue;
    }
    public async Task<List<UserDTO>> GetAllUsers()
    {
        List<UserDTO> returnValue = await securityRepository.GetAllUsers();
        return returnValue;
    }

    private List<Claim> ToClaimsList(UserDTO userInfo)
    {
        List<Claim> claimList =
        [
            new (KeyUserId.ToString(), userInfo.UserId.ToString()),
            new (KeyGivenName.ToString(), $"{userInfo.Name} {userInfo.LastName}"),
            new (KeyEmail.ToString(), userInfo.Email!),
        ];
        return claimList;
    }


    private Task<TokenResponseDTO> CreateEmptyJwtTokenAsync(TokenRequestDTO requestBody)
    {
        TokenResponseDTO response = new()
        {
            access_token = null,
            token_type = TokenBearerPrefix,
            issued_at = null,
            expires_in = null,
            scope = requestBody.scope!,
            application_id = requestBody.application_id,
            user_id = requestBody.user_id,
        };
        return Task.FromResult(response);
    }

    private Task<TokenResponseDTO> CreateJwtTokenAsync(TokenRequestDTO requestBody, List<Claim> claimList, UserDTO userInfoDTO, IdentityServiceServerSettingsOptions _jwtIdentityServerOptionsValues)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = CreateJwtTokenDescriptor(claimList, _jwtIdentityServerOptionsValues);
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        var access_token = tokenHandler.WriteToken(securityToken);
        TokenResponseDTO response = new()
        {
            access_token = access_token,
            token_type = TokenBearerPrefix,
            issued_at = tokenDescriptor.IssuedAt!.Value.Ticks,
            expires_in = _jwtIdentityServerOptionsValues.TokenLifeTimeMinutes,
            scope = $"{userInfoDTO.RoleFk}-{userInfoDTO.RoleName}",
            application_id = requestBody.application_id,
            user_id = requestBody.user_id,
        };
        return Task.FromResult(response);
    }

    private SecurityTokenDescriptor CreateJwtTokenDescriptor(List<Claim> claimList, IdentityServiceServerSettingsOptions _jwtIdentityServerOptionsValues)
    {
        var securityKey = new SigningCredentials(new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes(_jwtIdentityServerOptionsValues!.Key!)),
                    SecurityAlgorithms.HmacSha256Signature
                );

        var time = clockRepository.UtcNow;
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Issuer = _jwtIdentityServerOptionsValues.Issuer,
            Audience = _jwtIdentityServerOptionsValues.Audience,
            Subject = new ClaimsIdentity(claimList.ToArray()),
            IssuedAt = clockRepository.UtcNow().DateTime,
            Expires = clockRepository.UtcNow().DateTime.AddMinutes(_jwtIdentityServerOptionsValues.TokenLifeTimeMinutes),
            SigningCredentials = securityKey,

        };
        return tokenDescriptor;
    }
}
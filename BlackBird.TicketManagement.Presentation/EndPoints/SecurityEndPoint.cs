using Asp.Versioning.Builder;
using BlackBird.TicketManagement.Application.TransverseServices.Security;
using BlackBird.TicketManagement.Entities.ModelDTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlackBird.TicketManagement.Presentation.EndPoints;

public static class SecurityEndPoint
{

    public static void MapSecurityEndPoint(this WebApplication app)
    {
        var endPointGroupVersioned = app.MapGroup("api/Security/");

        endPointGroupVersioned.MapPost("token", Login)
            .WithSummary("Login Async in order to Generate Jwt Token Bearer")
            .WithDescription("[Anonymous]")
            .AllowAnonymous();
    }

    public static async Task<Results<Ok<TokenResponseDTO>, UnauthorizedHttpResult, NotFound, ValidationProblem>> Login(
        HttpRequest request,
        [FromBody] TokenRequestDTO loginInfo,
        [FromServices] ISecurityService securityService)
    {
        TokenResponseDTO returnObject = await securityService.Login(loginInfo);
        return returnObject == null ? TypedResults.NotFound() : TypedResults.Ok(returnObject);
    }

}
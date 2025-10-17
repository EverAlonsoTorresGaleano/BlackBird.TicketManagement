using Asp.Versioning.Builder;
using BlackBird.TicketManagement.Application.Services.Ticket;
using BlackBird.TicketManagement.Application.TransverseServices.Security;
using BlackBird.TicketManagement.Entities.ModelDTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlackBird.TicketManagement.Presentation.EndPoints;

public static class UserEndPoint
{

    public static void MapUserEndPointt(this WebApplication app)
    {
        var endPointGroupVersioned = app.MapGroup("api/User/");

        endPointGroupVersioned.MapGet("ByNameAsync", GetUserByName)
             .WithSummary("Get Users by Name Async")
             .WithDescription("[Requiere Authorization] Please Add Header 'Authorization'='Bearer {Token}'")
             .RequireAuthorization();

        endPointGroupVersioned.MapGet("AllAsync", GetAllUsers)
            .WithSummary("Get All USers Async")
            .WithDescription("[Requiere Authorization] Please Add Header 'Authorization'='Bearer {Token}'")
            .RequireAuthorization();

        endPointGroupVersioned.MapPost("AddAsync", AddUser)
           .WithSummary("Add AddUser Async")
           .WithDescription("\"[Requiere Authorization] Please Add Header 'Authorization'='Bearer {Token}'")
           .RequireAuthorization();

        endPointGroupVersioned.MapPatch("DisableAsync", DisableUsers)
            .WithSummary("Disable User by Id Async")
            .WithDescription("[Requiere Authorization] Please Add Header 'Authorization'='Bearer {Token}'")
            .RequireAuthorization();

    }

    public static async Task<Results<Ok<UserDTO>, UnauthorizedHttpResult, NotFound, ValidationProblem>> GetUserByName(
    HttpRequest request,
     [FromQuery] string userName,
    [FromServices] ISecurityService securityService)
    {
        UserDTO returnObject = await securityService.GetUserByName(userName);
        return returnObject == null ? TypedResults.NotFound() : TypedResults.Ok(returnObject);
    }

    public static async Task<Results<Ok<List<UserDTO>>, UnauthorizedHttpResult, NotFound, ValidationProblem>> GetAllUsers(
    HttpRequest request,
    [FromServices] ISecurityService securityService)
    {
        List<UserDTO> returnObject = await securityService.GetAllUsers();
        return returnObject == null ? TypedResults.NotFound() : TypedResults.Ok(returnObject);
    }

    public static async Task<Results<Ok<UserDTO>, UnauthorizedHttpResult, NotFound, ValidationProblem>> AddUser(
    HttpRequest request,
    [FromServices] ISecurityService securityService,
    [FromBody] UserDTO user)
    {
        UserDTO returnObject = await securityService.AddUser(user);
        return returnObject == null ? TypedResults.NotFound() : TypedResults.Ok(returnObject);
    }

    public static async Task<Results<Ok<bool?>, UnauthorizedHttpResult, NotFound, ValidationProblem>> DisableUsers(
    HttpRequest request,
    [FromQuery] string userName,
    [FromServices] ISecurityService securityService)
    {
        bool? returnObject = await securityService.DisableUser(userName);
        return returnObject == null ? TypedResults.NotFound() : TypedResults.Ok(returnObject);


    }
}
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
        var endPointGroupVersioned = app.MapGroup("api/Users/");

        endPointGroupVersioned.MapGet("", GetAllUsers)
          .WithSummary("Get All USers Async")
          .WithDescription("[Requiere Authorization] Please Add Header 'Authorization'='Bearer {Token}'")
         .RequireAuthorization();

        endPointGroupVersioned.MapGet("{userId}", GetUserById)
             .WithSummary("Get Users by Name Async")
             .WithDescription("[Requiere Authorization] Please Add Header 'Authorization'='Bearer {Token}'")
             .RequireAuthorization();



        endPointGroupVersioned.MapPost("Add", AddUser)
           .WithSummary("Add AddUser Async")
           .WithDescription("\"[Requiere Authorization] Please Add Header 'Authorization'='Bearer {Token}'")
           .RequireAuthorization();

        endPointGroupVersioned.MapPatch("Disable/{userId}", DisableUsers)
            .WithSummary("Disable User by Id Async")
            .WithDescription("[Requiere Authorization] Please Add Header 'Authorization'='Bearer {Token}'")
            .RequireAuthorization();

    }

    public static async Task<Results<Ok<UserDTO>, UnauthorizedHttpResult, NotFound, ValidationProblem>> GetUserById(
    HttpRequest request,
     [FromRoute] long userId,
    [FromServices] ISecurityService securityService)
    {
        UserDTO returnObject = await securityService.GetUserById(userId);
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
    [FromRoute] long userId,
    [FromServices] ISecurityService securityService)
    {
        bool? returnObject = await securityService.DisableUser(userId);
        return returnObject == null ? TypedResults.NotFound() : TypedResults.Ok(returnObject);


    }
}
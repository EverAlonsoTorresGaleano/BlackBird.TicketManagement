using Asp.Versioning.Builder;
using BlackBird.TicketManagement.Application.Services.Ticket;
using BlackBird.TicketManagement.Entities.ModelDTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlackBird.TicketManagement.Presentation.EndPoints;

public static class TicketEndPoint
{
    public static void MapTicketEndPoint(this WebApplication app)
    {
        var endPointGroupVersioned = app.MapGroup("api/Ticket/");

        endPointGroupVersioned.MapGet("AllAsync", GetAllTicket)
            .WithSummary("Get All Ticket Async")
            .WithDescription("\"[Requiere Authorization] Please Add Header 'Authorization'='Bearer {Token}'")
            .RequireAuthorization();

        endPointGroupVersioned.MapGet("ByIdAsync", GetTicketById)
            .WithSummary("Get Ticket by Id Async")
            .WithDescription("\"[Requiere Authorization] Please Add Header 'Authorization'='Bearer {Token}'")
            .RequireAuthorization();

        endPointGroupVersioned.MapGet("HistoryByIdAsync", GetTicketHistoryById)
          .WithSummary("Gett Ticket History by Id Async")
          .WithDescription("\"[Requiere Authorization] Please Add Header 'Authorization'='Bearer {Token}'")
          .RequireAuthorization();

        endPointGroupVersioned.MapPost("AddAsync", AddTicket)
            .WithSummary("Add Ticket Async")
            .WithDescription("\"[Requiere Authorization] Please Add Header 'Authorization'='Bearer {Token}'")
            .RequireAuthorization();

        endPointGroupVersioned.MapPut("UpdateAsync", UpdateTicket)
            .WithSummary("Update Ticket Async")
            .WithDescription("\"[Requiere Authorization] Please Add Header 'Authorization'='Bearer {Token}'")
            .RequireAuthorization();

        endPointGroupVersioned.MapDelete("DeleteAsync", DeleteTicket)
            .WithSummary("Delete Ticket Async")
            .WithDescription("[Requiere Authorization] Please Add Header 'Authorization'='Bearer {Token}'")
            .RequireAuthorization();
    }

    public static async Task<Results<Ok<List<TicketDTO>>, UnauthorizedHttpResult, NotFound, ValidationProblem>> GetAllTicket(
    HttpRequest request,
    [FromServices] ITicketService productService)
    {
        List<TicketDTO> returnObject = await productService.GetAllTicket();
        return returnObject == null ? TypedResults.NotFound() : TypedResults.Ok(returnObject);
    }

    public static async Task<Results<Ok<TicketDTO>, UnauthorizedHttpResult, NotFound, ValidationProblem>> GetTicketById(
    HttpRequest request,
    [FromServices] ITicketService productService,
    [FromQuery] long ticketId)
    {
        TicketDTO returnObject = await productService.GetTicketById(ticketId);
        return returnObject == null ? TypedResults.NotFound() : TypedResults.Ok(returnObject);
    }

    public static async Task<Results<Ok<List<TicketHistoryDTO>>, UnauthorizedHttpResult, NotFound, ValidationProblem>> GetTicketHistoryById(
    HttpRequest request,
    [FromServices] ITicketService productService,
    [FromQuery] long ticketId)
    {
        List<TicketHistoryDTO> returnObject = await productService.GetTicketHistoryById(ticketId);
        return returnObject == null ? TypedResults.NotFound() : TypedResults.Ok(returnObject);
    }
    

    public static async Task<Results<Ok<TicketDTO>, UnauthorizedHttpResult, NotFound, ValidationProblem>> AddTicket(
    HttpRequest request,
    [FromServices] ITicketService productService,
    [FromBody] TicketDTO ticket)
    {
        TicketDTO returnObject = await productService.AddTicket(ticket);
        return returnObject == null ? TypedResults.NotFound() : TypedResults.Ok(returnObject);
    }

    public static async Task<Results<Ok<TicketDTO>, UnauthorizedHttpResult, NotFound, ValidationProblem>> UpdateTicket(
    HttpRequest request,
    [FromServices] ITicketService productService,
    [FromBody] TicketDTO ticket)
    {
        TicketDTO returnObject = await productService.UpdateTicket(ticket);
        return returnObject == null ? TypedResults.NotFound() : TypedResults.Ok(returnObject);
    }

    public static async Task<Results<Ok<bool?>, UnauthorizedHttpResult, NotFound, ValidationProblem>> DeleteTicket(
    HttpRequest request,
    [FromServices] ITicketService productService,
    [FromQuery] long ticketId)
    {
        bool? returnObject = await productService.DeleteTicket(ticketId);
        return returnObject == null ? TypedResults.NotFound() : TypedResults.Ok(returnObject);
    }
}

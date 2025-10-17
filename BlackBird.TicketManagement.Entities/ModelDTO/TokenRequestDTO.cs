namespace BlackBird.TicketManagement.Entities.ModelDTO;

public record TokenRequestDTO
{
    public string grant_type { get; set; } = "ClientCredentials";

    public string? scope { get; set; }

    public string application_id { get; set; } = "eb2d4ffc-dc34-435f-8983-ecd42481143f";

    public string? user_id { get; set; } = "ever.torresg";

    public string? user_secret { get; set; } = "123";

}

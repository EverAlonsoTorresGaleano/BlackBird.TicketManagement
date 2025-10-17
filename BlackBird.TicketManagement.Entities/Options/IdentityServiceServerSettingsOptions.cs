namespace BlackBird.TicketManagement.Entities.Options;

public record IdentityServiceServerSettingsOptions
{
    public string Key { get; set; } = "";

    public string Issuer { get; set; } = "";

    public string Audience { get; set; } = "";

    public int TokenLifeTimeMinutes { get; set; } = 30;

    public int MaxUserFailRetrys { get; set; } = 3;

    public string[]? AuthorizedUrls { get; set; }

    public const string SectionName = "IdentityServiceServerSettings";

}

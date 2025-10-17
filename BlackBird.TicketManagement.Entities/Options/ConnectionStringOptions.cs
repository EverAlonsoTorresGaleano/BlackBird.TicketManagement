namespace BlackBird.TicketManagement.Entities.Options;

public record ConnectionStringOptions
{
    public const string SectionName = "ConnectionStrings";  
    public string AzureSQLServer { get; set; }=string.Empty;
    public int RetryCount { get; set; }

    public int MaxRetryDelay { get; set; }

    public int TimeOut { get; set; }

}

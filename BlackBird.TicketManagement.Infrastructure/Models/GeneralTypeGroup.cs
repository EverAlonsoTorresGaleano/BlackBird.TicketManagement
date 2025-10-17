namespace BlackBird.TicketManagement.Infrastructure.Models;

public partial class GeneralTypeGroup
{
    public long GeneralTypeGroupId { get; set; }

    public string GroupName { get; set; } = null!;

    public virtual ICollection<GeneralTypeItem> GeneralTypeItems { get; set; } = new List<GeneralTypeItem>();
}

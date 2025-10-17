namespace BlackBird.TicketManagement.Entities.ModelDTO;

public  class UserDTO
{
    public long UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserSecret { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public bool IsLocked { get; set; }

    public DateTime? LastAccess { get; set; }

    public long RoleFk { get; set; }

    public string RoleName { get; set; }
}

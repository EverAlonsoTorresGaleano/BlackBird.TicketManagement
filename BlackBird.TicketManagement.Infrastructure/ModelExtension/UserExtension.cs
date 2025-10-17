namespace BlackBird.TicketManagement.Infrastructure.Models;

public partial class User
{
    public string FullName 
    {
        get 
        {
            return $"{Name} {LastName}";    
        } 
    
    } 
}

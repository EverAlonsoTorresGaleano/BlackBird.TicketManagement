--CReate MOdelo de Mapeo contra DB SQL SERVER
dotnet ef dbcontext scaffold "Server=(local);Database=BlackBird.TicketManagement.DB;Integrated Security=true;TrustServerCertificate=True;Persist Security Info=True; Encrypt=Optional;Command Timeout=120;MultipleActiveResultSets=true;Max Pool Size=200;Application Name=BlackBird.TicketManagement" Microsoft.EntityFrameworkCore.SqlServer --force -o "Models"


--Crear MIgraciones 

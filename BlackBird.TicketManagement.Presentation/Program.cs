using BlackBird.TicketManagement.Application.Services.Ticket;
using BlackBird.TicketManagement.Application.TransverseServices.Security;
using BlackBird.TicketManagement.Entities.Options;
using BlackBird.TicketManagement.Infrastructure.Repositories.Ticket;
using BlackBird.TicketManagement.Infrastructure.TransverseRepositories.Clock;
using BlackBird.TicketManagement.Infrastructure.TransverseRepositories.DataContext;
using BlackBird.TicketManagement.Infrastructure.TransverseRepositories.DataContextFactory;
using BlackBird.TicketManagement.Infrastructure.TransverseRepository.Security;
using BlackBird.TicketManagement.Presentation.EndPoints;
using BlackBird.TicketManagement.Presentation.Helpers;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.


builder.Services.AddOptions<ConnectionStringOptions>().BindConfiguration(ConnectionStringOptions.SectionName);

builder.Services.AddOptions<IdentityServiceServerSettingsOptions>().BindConfiguration(IdentityServiceServerSettingsOptions.SectionName);

//Dependency Injection for Repository and Service   
builder.Services.AddTransient<IModelDataContext, ModelDataContext>();

builder.Services.AddSingleton<IDataContextFactory, DataContextFactory>();

builder.Services.AddDbContextFactory<ModelDataContext, DataContextFactory>(options =>
{

}, ServiceLifetime.Singleton);

builder.Services.AddTransient<IClockRepository, ClockRepository>();
builder.Services.AddTransient<ITicketRepository, TicketRepository>();
builder.Services.AddTransient<ISecurityRepository, SecurityRepository>();


builder.Services.AddTransient<ITicketService, TicketService>();
builder.Services.AddTransient<ISecurityService, SecurityService>();

//Identity Service Server 
var identityServiceServerOptions = configuration.GetSection(IdentityServiceServerSettingsOptions.SectionName).Get<IdentityServiceServerSettingsOptions>();
builder.AddAuthenticationForJwtServer(identityServiceServerOptions!);
builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.AddCorsOnlyForAuthorizedUrls(identityServiceServerOptions!.AuthorizedUrls!);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseCors();


app.MapSecurityEndPoint();
app.MapUserEndPointt();
app.MapTicketEndPoint();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
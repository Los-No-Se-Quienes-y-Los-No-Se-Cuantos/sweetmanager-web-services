using Microsoft.EntityFrameworkCore;
using sweetmanager.API.Clients.Application.Internal.CommandServices;
using sweetmanager.API.Clients.Application.Internal.QueryServices;
using sweetmanager.API.Clients.Domain.Repositories;
using sweetmanager.API.Clients.Domain.Services;
using sweetmanager.API.Clients.Infrastructure.Persistence.EFC.Repositories;
using sweetmanager.API.Clients.Interfaces.ACL;
using sweetmanager.API.Clients.Interfaces.ACL.Services;
using sweetmanager.API.Rooms.Application.Internal.CommandServices;
using sweetmanager.API.Rooms.Application.Internal.QueryServices;
using sweetmanager.API.Rooms.Domain.Repositories;
using sweetmanager.API.Rooms.Domain.Services;
using sweetmanager.API.Rooms.Infrastructure.Persistence.EFC.Repositories;
using sweetmanager.API.Communication.Application.Internal.CommandServices;
using sweetmanager.API.communication.Application.Internal.QueryServices;
using sweetmanager.API.Communication.Domain.Repositories;
using sweetmanager.API.Communication.Domain.Services;
using sweetmanager.API.Communication.Infrastructure.Persistence.EFC.Repositories;
using sweetmanager.API.Communication.Infrastructure.Socket;
using sweetmanager.API.Payments.Application.Internal.CommandService;
using sweetmanager.API.Payments.Application.Internal.OutboundServices.ACL;
using sweetmanager.API.Payments.Application.Internal.QueryService;
using sweetmanager.API.Payments.Domain.Repositories;
using sweetmanager.API.Payments.Domain.Services;
using sweetmanager.API.Payments.Infrastructure.Persistence.EFC.Repositories;
using sweetmanager.API.Shared.Domain.Repositories;
using sweetmanager.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using sweetmanager.API.Subscriptions.Application.Internal.CommandServices;
using sweetmanager.API.Subscriptions.Application.Internal.QueryServices;
using sweetmanager.API.Subscriptions.Domain.Repositories;
using sweetmanager.API.Subscriptions.Domain.Services;
using sweetmanager.API.Subscriptions.Infrastructure.Persistence.EFC;
using sweetmanager.API.Supply.Application.Internal.CommandServices;
using sweetmanager.API.Supply.Application.Internal.QueryServices;
using sweetmanager.API.Supply.Domain.Repositories;
using sweetmanager.API.Supply.Domain.Services;
using sweetmanager.API.Supply.Infrastructure.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers( options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var connectionStringFromEnvironment = Environment.GetEnvironmentVariable("SweetManagerDbConnection");

if (connectionStringFromEnvironment != null)
{
    connectionString = connectionStringFromEnvironment;
}

// Configure Database Context and Logging Levels
builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();    
    });



// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Dependency Injection

// Rooms Bounded Context Injection Configuration
builder.Services.AddScoped<IBedroomCommandService, BedroomCommandService>();
builder.Services.AddScoped<IBookingCommandService, BookingCommandService>();
builder.Services.AddScoped<IBedroomQueryService, BedroomQueryService>();
builder.Services.AddScoped<IBookingQueryService, BookingQueryService>();
builder.Services.AddScoped<IBedroomRepository, BedroomRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

// Supply Bounded Context Injection Configuration
builder.Services.AddScoped<ISupplyCommandService, SupplyCommandService>();
builder.Services.AddScoped<ISupplyQueryService, SupplyQueryService>();
builder.Services.AddScoped<ISupplyRepository, SupplyRepository>();

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<INotificationCommandService, NotificationCommandService>();

builder.Services.AddScoped<INotificationQueryService, NotificationQueryService>();

builder.Services.AddScoped<INotificationRepository, NotificationRepository>();

builder.Services.AddScoped<IWebSocketHandler, WebSocketHandler>();

// Subscription Bounded Context Injection Configuration
builder.Services.AddScoped<ISubscriptionCommandService, SubscriptionCommandService>();
builder.Services.AddScoped<ISubscriptionQueryService, SubscriptionQueryService>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

// Payment Bounded Context Injection Configuration
builder.Services.AddScoped<IPaymentCommandService, PaymentCommandService>();
builder.Services.AddScoped<IPaymentQueryService, PaymentQueryService>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<ExternalProfileService>();

// Client Bounded Context Injection Configuration
builder.Services.AddScoped<IClientCommandService, ClientCommandService>();
builder.Services.AddScoped<IClientQueryService, ClientQueryService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientsContextFacade, ClientsContextFacade>();

var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

#region ConfigurationSocket

var webSocketOptions = new WebSocketOptions()
{
    KeepAliveInterval = TimeSpan.FromMinutes(2),
};

app.UseWebSockets(webSocketOptions);

var webSocketHandler = new WebSocketHandler();

app.Map("/communication", webSocketHandler.HandleWebSocketAsync);

#endregion

// Configuration cors
app.UseCors(
    b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin() 
);

// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
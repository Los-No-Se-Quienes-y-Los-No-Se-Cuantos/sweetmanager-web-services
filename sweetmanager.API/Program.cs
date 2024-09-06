using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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
using sweetmanager.API.IAM.Application.Internal.CommandServices.Credential;
using sweetmanager.API.IAM.Application.Internal.CommandServices.Roles;
using sweetmanager.API.IAM.Application.Internal.CommandServices.Users;
using sweetmanager.API.IAM.Application.Internal.OutboundContext;
using sweetmanager.API.IAM.Application.Internal.QueryServices.Credential;
using sweetmanager.API.IAM.Application.Internal.QueryServices.Roles;
using sweetmanager.API.IAM.Application.Internal.QueryServices.Users;
using sweetmanager.API.IAM.Domain.Repositories;
using sweetmanager.API.IAM.Domain.Repositories.Credential;
using sweetmanager.API.IAM.Domain.Repositories.Roles;
using sweetmanager.API.IAM.Domain.Repositories.Users;
using sweetmanager.API.IAM.Domain.Services.Roles;
using sweetmanager.API.IAM.Domain.Services.UserCredentials.Administration;
using sweetmanager.API.IAM.Domain.Services.UserCredentials.Work;
using sweetmanager.API.IAM.Domain.Services.Users.Administration;
using sweetmanager.API.IAM.Domain.Services.Users.Work;
using sweetmanager.API.IAM.Infrastructure.Hashing.BCrypt.Services;
using sweetmanager.API.IAM.Infrastructure.Persistence.EFC.Repositories.Credential;
using sweetmanager.API.IAM.Infrastructure.Persistence.EFC.Repositories.Roles;
using sweetmanager.API.IAM.Infrastructure.Persistence.EFC.Repositories.Users;
using sweetmanager.API.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using sweetmanager.API.IAM.Infrastructure.Poblation.Roles;
using sweetmanager.API.IAM.Infrastructure.Tokens.JWT.Configuration;
using sweetmanager.API.IAM.Infrastructure.Tokens.JWT.Services;
using sweetmanager.API.IAM.Interfaces.ACL;
using sweetmanager.API.IAM.Interfaces.ACL.Services;
using sweetmanager.API.Payments.Application.Internal.CommandService;
using sweetmanager.API.Payments.Application.Internal.OutboundServices.ACL;
using sweetmanager.API.Payments.Application.Internal.QueryService;
using sweetmanager.API.Payments.Domain.Repositories;
using sweetmanager.API.Payments.Domain.Services;
using sweetmanager.API.Payments.Infrastructure.Persistence.EFC.Repositories;
using sweetmanager.API.Reports.Application.Internal;
using sweetmanager.API.Reports.Application.Internal.CommandService;
using sweetmanager.API.Reports.Application.Internal.QueryService;
using sweetmanager.API.Reports.Domain.Repositories;
using sweetmanager.API.Reports.Domain.Services;
using sweetmanager.API.Reports.Infrastructure.Persistence.EFC;
using sweetmanager.API.Reports.Infrastructure.Persistence.EFC.Repositories;
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


#region Database Configuration
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

#endregion

#region OPENAPI Configuration
// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "Sweet Manager API",
                Version = "v1",
                Description = "Sweet Manager API",
                TermsOfService = new Uri("https://acme-learning.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "Sweet Manager Studios",
                    Email = "contact@swm.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer", Type = ReferenceType.SecurityScheme
                    } 
                }, 
                Array.Empty<string>()
            }
        });
    });

#endregion

builder.Services.AddHttpContextAccessor();

#region Injection Configuration for Every Bounded Context

// Rooms Bounded Context Injection Configuration
builder.Services.AddScoped<IBedroomCommandService, BedroomCommandService>();
builder.Services.AddScoped<IBookingCommandService, BookingCommandService>();
builder.Services.AddScoped<IBedroomQueryService, BedroomQueryService>();
builder.Services.AddScoped<IBookingQueryService, BookingQueryService>();
builder.Services.AddScoped<IBedroomRepository, BedroomRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IReportQueryService, ReportQueryService>();
builder.Services.AddScoped<IReportCommandService, ReportCommandService>();

builder.Services.AddSingleton<FirebaseClient>();
builder.Services.AddScoped<IFirebaseService, FirebaseService>();



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

// IAM Bounded Context Injection Configuration

builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();
builder.Services.AddScoped<IHashingService, HashingServices>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleCommandService, RoleCommandService>();
builder.Services.AddScoped<IRoleQueryService, RoleQueryService>();
builder.Services.AddScoped<IWorkerCredentialRepository, WorkerCredentialRepository>();
builder.Services.AddScoped<IAdministratorCredentialRepository, AdministratorCredentialRepository>();
builder.Services.AddScoped<IAdministratorCredentialCommandService, AdministratorCredentialCommandService>();
builder.Services.AddScoped<IAdministratorCredentialQueryService, AdministratorCredentialQueryService>();
builder.Services.AddScoped<IWorkerCredentialRepository, WorkerCredentialRepository>();
builder.Services.AddScoped<IWorkerCredentialCommandService, WorkerCredentialCommandService>();
builder.Services.AddScoped<IWorkerCredentialQueryService, WorkerCredentialQueryService>();
builder.Services.AddScoped<IAdministratorRepository, AdministratorRepository>();
builder.Services.AddScoped<IAdministratorCommandService, AdministratorCommandService>();
builder.Services.AddScoped<IAdministratorQueryService, AdministratorQueryService>();
builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();
builder.Services.AddScoped<IWorkerCommandService, WorkerCommandService>();
builder.Services.AddScoped<IWorkerQueryService, WorkerQueryService>();
builder.Services.AddScoped<IWorkerRoleCommandService, WorkerRoleCommandService>();
builder.Services.AddScoped<IWorkerRoleQueryService, WorkerRoleQueryService>();
builder.Services.AddScoped<IManagerWorkerRoleCommandService, ManagerWorkerRoleCommandService>();
builder.Services.AddScoped<IManagerWorkerRoleRepository, ManagerWorkerRoleRepository>();
builder.Services.AddScoped<IWorkerRoleRepository, WorkerRoleRepository>();

builder.Services.AddScoped<DatabaseInitializer>();

#endregion

#region TOKEN CONFIGURATION

var tokenSettings = builder.Configuration.GetSection("TokenSettings");

builder.Services.Configure<TokenSettings>(tokenSettings);

var secretKey = tokenSettings["Secret"];

var audience = tokenSettings["Audience"];

var issuer = tokenSettings["Issuer"];

var securityKey = !string.IsNullOrEmpty(secretKey)
    ? new SymmetricSecurityKey(Encoding.Default.GetBytes(secretKey))
    : throw new ArgumentException("Secret key is null or empty");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = securityKey,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddTransient<TokenValidationHandler>();

builder.Services.AddAuthorization();

#endregion

var app = builder.Build();

#region Ensure Database Created (COMPILE AppDbContext)
// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

#endregion

#region Run DatabaseInitializer
using (var scope = app.Services.CreateScope())
{
    var initializer = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();

    initializer.InitializeAsync().Wait();
}
#endregion

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseRequestAuthorization();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
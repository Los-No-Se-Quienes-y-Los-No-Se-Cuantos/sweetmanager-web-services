using sweetmanager.API.IAM.Domain.Model.Commands;
using sweetmanager.API.IAM.Domain.Model.Queries;
using sweetmanager.API.IAM.Domain.Services.Roles;

namespace sweetmanager.API.IAM.Infrastructure.Poblation.Roles;

public class DatabaseInitializer(IRoleCommandService roleCommandService, IRoleQueryService
    roleQueryService)
{
    public async Task InitializeAsync()
    {
        // Check if the Role table is empty

        var result = 
            await roleQueryService.Handle(new GetAllRolesQuery());
        
        if (!result.Any())
        {
              // Prepopulate the Role table
              await roleCommandService.Handle(new SeedRolesCommand());
        }
    }
}
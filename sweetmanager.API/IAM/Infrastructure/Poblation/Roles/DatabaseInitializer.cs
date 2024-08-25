using sweetmanager.API.IAM.Domain.Model.Commands;
using sweetmanager.API.IAM.Domain.Model.Commands.Role;
using sweetmanager.API.IAM.Domain.Model.Queries;
using sweetmanager.API.IAM.Domain.Services.Roles;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace sweetmanager.API.IAM.Infrastructure.Poblation.Roles;

public class DatabaseInitializer(IRoleCommandService roleCommandService, 
    IRoleQueryService roleQueryService, 
    AppDbContext appDbContext,
    IWorkerRoleQueryService workerRoleQueryService,
    IWorkerRoleCommandService workerRoleCommandService)
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
        
        // Check if the WorkerArea table is empty 
        var workerRoleResult = await workerRoleQueryService.Handle(new GetAllRolesQuery());

        if (!workerRoleResult.Any())
        {
            await workerRoleCommandService.Handle(new SeedSubRolesCommand());
        }
    }
}
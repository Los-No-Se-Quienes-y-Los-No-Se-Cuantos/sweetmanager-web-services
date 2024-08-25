using sweetmanager.API.IAM.Domain.Model.Aggregates.Management;
using sweetmanager.API.IAM.Domain.Model.Commands.Role;
using sweetmanager.API.IAM.Domain.Model.Entities.Roles.WorkerAreas;

namespace sweetmanager.API.IAM.Domain.Model.Entities.Roles.SupervisionAreas;

public class AdministratorWorkerRole
{
    public int AdministratorId { get; set; }
    
    public virtual Administrator? Administrator { get; set; }

    public AdministratorWorkerRole()
    {
        
    }
    
    public int WorkerRoleId { get; set; }
    
    public virtual WorkerRole? WorkerRole { get; set; }

    public AdministratorWorkerRole(CreateManagerWorkerRoleCommand command)
    {
        AdministratorId = command.AdministratorId;

        WorkerRoleId = command.WorkerRoleId;
    }
}
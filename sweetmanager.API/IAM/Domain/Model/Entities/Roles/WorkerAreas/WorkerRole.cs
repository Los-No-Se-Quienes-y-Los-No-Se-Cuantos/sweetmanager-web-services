using System.ComponentModel.DataAnnotations;
using sweetmanager.API.IAM.Domain.Model.Aggregates.Work;
using sweetmanager.API.IAM.Domain.Model.Entities.Roles.SupervisionAreas;
using sweetmanager.API.IAM.Domain.Model.ValueObjects;

namespace sweetmanager.API.IAM.Domain.Model.Entities.Roles.WorkerAreas;

public partial class WorkerRole(EWorkerRoles role)
{
    public int Id { get; private set; }
    
    [MaxLength(30)]
    public EWorkerRoles Role { get; private set; } = role;
    
    public virtual ICollection<AdministratorWorkerRole>? Administrators { get; set; }
    
    public virtual ICollection<Worker>? Workers { get; set; }

    public WorkerRole() : this(EWorkerRoles.KITCHEN_STAFF)
    {
        
    }
}
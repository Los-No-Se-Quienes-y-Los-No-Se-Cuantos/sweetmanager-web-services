using sweetmanager.API.IAM.Domain.Model.Entities.Credential;
using sweetmanager.API.IAM.Domain.Model.Entities.Roles.Standard;
using sweetmanager.API.IAM.Domain.Model.Entities.Roles.SupervisionAreas;
using sweetmanager.API.IAM.Domain.Model.Entities.User;
using sweetmanager.API.IAM.Domain.Model.ValueObjects;

namespace sweetmanager.API.IAM.Domain.Model.Aggregates.Management;

public partial class Administrator(string username, string email, Role role, string name, string phoneNumber, string accountStatus, string surname)
    : User(username, email, role, name, surname,phoneNumber)
{
    public Administrator() : this("","",new Role(ERoles.ROLE_MANAGER), "", "", "", "")
    {
        
    }
    public virtual ICollection<AdministratorWorkerRole>? SupervisionAreaManagerWorkerRoles { get; set; }
    
    public string AccountStatus { get; private set; } = accountStatus;
    
    public virtual AdministratorCredential? AdministratorCredential { get; set; }
    
}
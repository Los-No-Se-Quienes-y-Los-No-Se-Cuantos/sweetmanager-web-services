using sweetmanager.API.IAM.Domain.Model.Entities.Credential;
using sweetmanager.API.IAM.Domain.Model.Entities.Roles.Standard;
using sweetmanager.API.IAM.Domain.Model.Entities.Roles.WorkerAreas;
using sweetmanager.API.IAM.Domain.Model.Entities.User;
using sweetmanager.API.IAM.Domain.Model.ValueObjects;

namespace sweetmanager.API.IAM.Domain.Model.Aggregates.Work;

public partial class Worker(
    string username,
    string email,
    Role role,
    int roleArea,
    bool activeAccount,
    string phoneNumber,
    string name, 
    string surname)
    : User(username, email, role, name, surname, phoneNumber)
{
    public int RoleArea { get; private set; } = roleArea;
    
    public virtual WorkerRole? WorkArea { get; set; }
    
    public virtual WorkerCredential? WorkerCredential { get; set; }
    
    public bool ActiveAccount { get; private set; } = activeAccount;

    public Worker() : this("", "",new Role(ERoles.ROLE_WORKER), 0, true, "", "", "")
    {
        
    }
    
    public Worker UpdateActiveAccount(bool activeAccount)
    {
        ActiveAccount = activeAccount;

        return this;
    }
    
    public Worker UpdateRoleArea(int roleArea)
    {
        RoleArea = roleArea;

        return this;
    }

    public string GetWorkArea() => RoleArea.ToString();

}
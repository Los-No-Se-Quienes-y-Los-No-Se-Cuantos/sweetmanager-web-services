using sweetmanager.API.IAM.Domain.Model.ValueObjects;

namespace sweetmanager.API.IAM.Domain.Model.Entities;

public partial class Role(ERoles name)
{
    
    public long Id { get; private set; }
    
    public ERoles Name { get; private set; } = name;

    public string GetStringName() => Name.ToString();
    
    public static Role GetDefaultRole() =>  new Role(ERoles.ROLE_MANAGER);
    
}
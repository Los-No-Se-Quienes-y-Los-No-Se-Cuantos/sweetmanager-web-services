using sweetmanager.API.IAM.Domain.Model.Exceptions;
using sweetmanager.API.IAM.Domain.Model.ValueObjects;

namespace sweetmanager.API.IAM.Domain.Model.Queries;

public record GetRoleByNameQuery(ERoles Name)
{
    
}
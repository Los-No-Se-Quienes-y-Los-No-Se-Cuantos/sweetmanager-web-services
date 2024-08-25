using sweetmanager.API.IAM.Domain.Model.ValueObjects;

namespace sweetmanager.API.IAM.Domain.Model.Queries;

public record GetWorkerRoleByNameQuery(EWorkerRoles Name);
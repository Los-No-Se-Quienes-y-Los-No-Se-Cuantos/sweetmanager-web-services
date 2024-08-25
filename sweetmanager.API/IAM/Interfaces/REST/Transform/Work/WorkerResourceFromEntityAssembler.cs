using sweetmanager.API.IAM.Domain.Model.Aggregates.Work;
using sweetmanager.API.IAM.Interfaces.REST.Resources.Authentication.Work;

namespace sweetmanager.API.IAM.Interfaces.REST.Transform;

public class WorkerResourceFromEntityAssembler
{
    public static WorkerResource ToResourceFromEntity(Worker entity)
    {
        return new WorkerResource(entity.Username, entity.Email, entity.GetWorkArea(), entity.ActiveAccount,
            entity.PhoneNumber,
            entity.Name.Name, entity.Name.Surname);
    }
}
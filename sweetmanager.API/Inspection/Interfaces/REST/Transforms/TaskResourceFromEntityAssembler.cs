using sweetmanager.API.Inspection.Interfaces.REST.Resources;
using Task = sweetmanager.API.Inspection.Domain.Model.Aggregates.Assignments.Task;

namespace sweetmanager.API.Inspection.Interfaces.REST.Transforms;

public class TaskResourceFromEntityAssembler
{
    public static TaskResource ToResourceFromEntity(Task entity)
    {
        return new TaskResource(entity.Id, entity.Title, entity.Description, entity.WorkerId);
    }
}
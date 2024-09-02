using sweetmanager.API.Inspection.Domain.Model.Commands;
using sweetmanager.API.Inspection.Interfaces.REST.Resources;

namespace sweetmanager.API.Inspection.Interfaces.REST.Transforms;

public class CreateTaskCommandFromResourceAssembler
{
    public static CreateTaskCommand ToCommandFromResource(CreateTaskResource resource)
    {
        return new CreateTaskCommand(resource.Title, resource.Description, resource.WorkerId);
    }
}
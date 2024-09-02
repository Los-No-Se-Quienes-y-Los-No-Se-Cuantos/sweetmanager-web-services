using sweetmanager.API.Inspection.Domain.Model.Commands;

namespace sweetmanager.API.Inspection.Domain.Services;

public interface ITaskCommandService
{
    Task<Model.Aggregates.Assignments.Task> Handle(CreateTaskCommand command);
}
using sweetmanager. API. Inspection. Domain. Model. Queries;

namespace sweetmanager.API.Inspection.Domain.Services;

public interface ITaskQueryService
{
    Task<Model.Aggregates.Assignments.Task?> Handle(GetTaskByIdQuery query);
    Task<IEnumerable<Model.Aggregates.Assignments.Task>> Handle(GetAllTasksQuery query);
    Task<IEnumerable<Model.Aggregates.Assignments.Task>> Handle(GetAllTasksByWorkerIdQuery query);
}
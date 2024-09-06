using sweetmanager.API.Inspection.Domain.Repositories;
using sweetmanager.API.Inspection.Domain.Services;
using sweetmanager. API. Inspection. Domain. Model. Queries;
namespace sweetmanager.API.Inspection.Application.QueryService;

public class TaskQueryService(ITaskRepository taskRepository): ITaskQueryService
{
    public async Task<Domain.Model.Aggregates.Assignments.Task?> Handle(GetTaskByIdQuery query)
    {
        return await taskRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Domain.Model.Aggregates.Assignments.Task>> Handle(GetAllTasksQuery query)
    {
        return await taskRepository.ListAsync();
    }

    public async Task<IEnumerable<Domain.Model.Aggregates.Assignments.Task>> Handle(GetAllTasksByWorkerIdQuery query)
    {
        return await taskRepository.FindTaskByWorkerIdAsync(query.WorkerId);
    }
}


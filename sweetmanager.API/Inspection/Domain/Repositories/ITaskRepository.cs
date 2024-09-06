using sweetmanager.API.Shared.Domain.Repositories;
using Task = sweetmanager.API.Inspection.Domain.Model.Aggregates.Assignments.Task;

namespace sweetmanager.API.Inspection.Domain.Repositories;

public interface ITaskRepository: IBaseRepository<Task>
{
    Task<IEnumerable<Task>> FindTaskByWorkerIdAsync(int workerId);
}
using sweetmanager.API.Inspection.Domain.Model.Commands;
using sweetmanager.API.Inspection.Domain.Repositories;
using sweetmanager.API.Inspection.Domain.Services;
using sweetmanager.API.Shared.Domain.Repositories;
using Task = sweetmanager.API.Inspection.Domain.Model.Aggregates.Assignments.Task;

namespace sweetmanager.API.Inspection.Application.CommandService;

public class TaskCommandService(ITaskRepository taskRepository, IUnitOfWork unitOfWork): ITaskCommandService
{
    public async Task<Task> Handle(CreateTaskCommand command)
    {
        var task = new Task(command);
        await taskRepository.AddAsync(task);
        await unitOfWork.CompleteAsync();
        return task;
    }
}
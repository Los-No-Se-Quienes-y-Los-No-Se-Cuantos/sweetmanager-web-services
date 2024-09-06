using sweetmanager.API.Inspection.Domain.Model.Commands;

namespace sweetmanager.API.Inspection.Domain.Model.Aggregates.Assignments;


public partial class Task
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int WorkerId { get; private set; }
    
    public Task() {}
    
    public Task(CreateTaskCommand command)
    {
        Title = command.Name;
        Description = command.Description;
        WorkerId = 0;
    }
    
    public Task(CreateTaskCommand command, int workerId)
    {
        Title = command.Name;
        Description = command.Description;
        WorkerId = workerId;
    }
}
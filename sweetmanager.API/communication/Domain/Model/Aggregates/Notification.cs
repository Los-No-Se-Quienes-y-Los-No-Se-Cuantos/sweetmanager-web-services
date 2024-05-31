using sweetmanager.API.communication.Domain.Model.Commands;

namespace sweetmanager.API.communication.Domain.Model.Aggregates;

public partial class Notification 
{
    public int Id { get; private set; }
    
    public string Title { get; private set; }
    
    public string Message { get; private set; }
    
    protected Notification()
    {
        this.Title = string.Empty;
        this.Message = string.Empty;
    }
    
    public Notification(CreateNotificationCommand command)
    {
        this.Title = command.title;
        this.Message = command.message;
    }

    public DateTimeOffset? UpdatedDate { get; set; }
}
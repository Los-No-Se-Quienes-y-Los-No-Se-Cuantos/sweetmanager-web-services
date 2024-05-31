using sweetmanager.API.interaction.Domain.Model.Commands;

namespace sweetmanager.API.interaction.Domain.Model.Aggregates;

public class Notification
{
    public int Id { get; private set; }
    
    public string Title { get; private set; }
    
    public string Message { get; private set; }
    
    public DateTime CreatedAt { get; private set; }
    
    protected Notification()
    {
        this.Title = string.Empty;
        this.Message = string.Empty;
        this.CreatedAt = DateTime.Now;
    }
    
    public Notification(CreateNotificationCommand command)
    {
        this.Title = command.title;
        this.Message = command.message;
        this.CreatedAt = DateTime.Now;
    }
    
}
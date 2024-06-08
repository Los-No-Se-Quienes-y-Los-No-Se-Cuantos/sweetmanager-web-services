using sweetmanager.API.Communication.Domain.Model.Commands;

namespace sweetmanager.API.Communication.Domain.Model.Aggregates;

public partial class Notification 
{
    public int Id { get; private set; }
    
    public string Title { get; private set; }
    
    public string Message { get; private set; }
    
    public Notification(string title, string message)
    {
        Title = title;
        Message = message;
    }
    
    public Notification(CreateNotificationCommand command)
    {
        Title = command.Title;
        Message = command.Message;
    }
    
}
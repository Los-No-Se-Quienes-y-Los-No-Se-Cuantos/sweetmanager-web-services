namespace sweetmanager.API.Communication.Domain.Model.Aggregates.Chat;

public class ChatMember
{
    public int ChatRoomId { get; set; }
    
    public int? TechnicalId { get; private set; }
    
    public int? CustomerId { get; private set; }

    
    
    public ChatMember()
    {
        
    }
    
    
}
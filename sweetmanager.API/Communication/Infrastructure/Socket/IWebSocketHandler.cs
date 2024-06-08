using System.Net.WebSockets;

namespace sweetmanager.API.Communication.Infrastructure.Socket;

public interface IWebSocketHandler
{
    Task HandleWebSocketAsync(HttpContext context);
    
}
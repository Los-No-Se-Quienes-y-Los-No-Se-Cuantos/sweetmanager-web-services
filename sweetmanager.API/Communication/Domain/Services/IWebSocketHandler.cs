namespace sweetmanager.API.Communication.Domain.Services;

public interface IWebSocketHandler
{
    Task HandleWebSocketAsync(HttpContext context);
}
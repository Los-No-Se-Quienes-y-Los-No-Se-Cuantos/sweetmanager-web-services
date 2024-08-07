using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using sweetmanager.API.Communication.Domain.Services;

namespace sweetmanager.API.Communication.Infrastructure.Socket;

// IWebSocketHandler handles WebSocket connections and messages
public class WebSocketHandler : IWebSocketHandler
{
    // Stores all active WebSocket connections grouped by Room Name
    private static readonly ConcurrentDictionary<string, List<WebSocket>> Rooms = new();
    
    // This method handles a new WebSocket Request
    public async Task HandleWebSocketAsync(HttpContext context)
    {
        if (context.WebSockets.IsWebSocketRequest)
        {
            var webSocket = await context.WebSockets.AcceptWebSocketAsync();

            string? room = context.Request.Query["room"];

            // If there is no room name in the query string, close the connection
            if (string.IsNullOrEmpty(room))
            {
                await webSocket.CloseAsync(WebSocketCloseStatus.PolicyViolation, "Room name is required", CancellationToken.None);

                return;
            }

            // Add the WebSocket connection to the corresponding room in the Rooms dictionary
            Rooms.AddOrUpdate(room, [webSocket], (key, oldValue) =>
            {
                oldValue.Add(webSocket);

                return oldValue;
            });

            // Start receiving messages from the WebSocket
            await ReceiveMessages(webSocket, room);

            // Remove the WebSocket connection from the room when the connection is closed
            Rooms[room].Remove(webSocket);

            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed by the WebSocketHandler", CancellationToken.None);
        }
        else
        {
            context.Response.StatusCode = 400;
        }
    }
    
    private static async Task ReceiveMessages(WebSocket webSocket, string room)
    {
        // Buffer to store the received message  and reduces the number of I/O Operations (Read a chunk of data at once)
        var buffer = new byte[1024 * 4];

        var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

        // Keep receiving messages until the WebSocket connection is closed
        while (!result.CloseStatus.HasValue)
        {
            // Convert the received message to a string
            var message = Encoding.UTF8.GetString(buffer, 0, result.Count);

            // Send the message to all other WebSocket connections in the same room except for the sender
            await BroadcastMessage(message, webSocket, room);

            result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        }
    }
    
    private static async Task BroadcastMessage(string message, WebSocket senderWebSocket, string room)
    {
        // Convert in Bytes the message to be sent
        var messageBuffer = Encoding.UTF8.GetBytes(message);

        // First check if the room exists in the Rooms dictionary
        if (Rooms.TryGetValue(room, out var sockets))
        {
            // Send the message to all other WebSocket connections in the same room except for the sender
            foreach (var socket in sockets.Where(socket => socket != senderWebSocket && socket.State == WebSocketState.Open))
            {
                // Send the message to the WebSocket connection
                await socket.SendAsync(new ArraySegment<byte>(messageBuffer), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }
}
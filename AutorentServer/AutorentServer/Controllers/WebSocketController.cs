using System.Net.WebSockets;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace AutorentServer.Controllers;

public class WebSocketController : ControllerBase
{
    [HttpGet("/ws")]
    public async Task Get()
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();

            string msg = "Hello World!";
            var encoded = Encoding.UTF8.GetBytes(msg);
            var buffer = new ArraySegment<Byte>(encoded, 0, encoded.Length);
            await webSocket.SendAsync(buffer, WebSocketMessageType.Text, WebSocketMessageFlags.None,
                CancellationToken.None);
            
            await Task.Delay(3000);
            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "ServerClose",
                new CancellationTokenSource(20_000).Token);
        }
        else
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
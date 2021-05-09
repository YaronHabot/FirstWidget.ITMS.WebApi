using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstWidget.ITMS.WebApi.Handlers
{

    public class AlertHandler : IAlertHandler, IDisposable
    {
        private readonly ConcurrentDictionary<string, WebSocket> _sockets;

        public AlertHandler()
        {
            _sockets = new ConcurrentDictionary<string, WebSocket>();
        }

        public async Task NotifyClients(string alertStr)
        {
            var buffer = Encoding.ASCII.GetBytes(alertStr); 
            foreach(var webSocket in _sockets.Values)
            {
                await webSocket.SendAsync(
                    new ArraySegment<byte>(buffer, 0, buffer.Length), 
                    WebSocketMessageType.Text, 
                    true, 
                    CancellationToken.None
                );
            }
        }
        public async Task PushAsync(HttpContext context, WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            string clientId = Encoding.UTF8.GetString(buffer, 0, result.Count);

            // record the client id and it's websocket instance
            if (_sockets.TryGetValue(clientId, out var wsi))
            {                
                if (wsi.State == WebSocketState.Open)
                {
                    Console.WriteLine($"abort the before clientId named {clientId}");
                    await wsi.CloseAsync(WebSocketCloseStatus.InternalServerError, "A new client with same id was connected!", CancellationToken.None);                    
                }

                _sockets.AddOrUpdate(clientId, webSocket, (x, y) => webSocket);
            }
            else
            {
                Console.WriteLine($"add or update {clientId}");
                _sockets.AddOrUpdate(clientId, webSocket, (x, y) => webSocket);
            }

            while (!result.CloseStatus.HasValue)
            {
                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }            

            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
            Console.WriteLine("close=" + clientId);

            _sockets.TryRemove(clientId, out _);
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose");       
            _sockets?.Clear();     
        }
    }
}

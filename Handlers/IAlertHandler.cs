using Microsoft.AspNetCore.Http;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace FirstWidget.ITMS.WebApi.Handlers
{

    public interface IAlertHandler
    {
        Task NotifyClients(string alertStr);
        Task PushAsync(HttpContext context, WebSocket webSocket);
    }
}
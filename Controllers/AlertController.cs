using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace FirstWidget.ITMS.WebApi.Controllers
{
    /////////////////////////////////////////////////////////////////////////////
    // Demonstrate object orientd architecture

    public abstract class AlbertControllerBase : ControllerBase
    {
        private readonly Handlers.IAlertHandler _alertHandler;

        public AlbertControllerBase(Handlers.IAlertHandler alertHandler)
        {
            this._alertHandler = alertHandler;
        }

        [HttpPost]
        public string Post(AlertItem alertItem)
        {
            if (this._alertHandler != null)
            {
                //Get the sender name from the driving class
                alertItem.Sender = AlertSender();

                //Send the alert to subscribing websocket clients
                this._alertHandler.NotifyClients(JsonSerializer.Serialize(alertItem));
            }
            return $"Alert Received: {alertItem.Message}";
        }

        //Demonstrate how to force deriving classes to implemnt their own behavior
        protected abstract string AlertSender();
    }

    [ApiController]
    [Route("[controller]")]
    public class NCDBController : AlbertControllerBase
    {
        private readonly ILogger<NCDBController> _logger;

        public NCDBController(
            ILogger<NCDBController> logger,
            Handlers.IAlertHandler alertHandler
        ) : base(alertHandler)
        {
            _logger = logger;
        }

        protected override string AlertSender()
        {
            return "National Crime Database";
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class CBController : AlbertControllerBase
    {
        private readonly ILogger<CBController> _logger;

        public CBController(
            ILogger<CBController> logger,
            Handlers.IAlertHandler alertHandler
        ) : base(alertHandler)
        {
            _logger = logger;
        }

        protected override string AlertSender()
        {
            return "Credit Bureau";
        }
    }

    public class AlertItem
    {
        public String SSN {get; set;}
        public String Message {get; set;}

        //What was the source of the alret, National Crime Database or Credit Bureau
        public string Sender {get; set;} 

    }
}

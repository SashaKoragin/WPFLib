using System;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRLibraryAutomations.HubError
{
    public class HubError : HubPipelineModule
    {
        protected override void OnIncomingError(ExceptionContext exceptionContext,
            IHubIncomingInvokerContext invokerContext)
        {
            var caller = invokerContext.Hub.Clients.Caller;
            Loggers.Log4NetLogger.Error(exceptionContext.Error);
            caller.ExceptionHandler(exceptionContext.Error.Message);
            Loggers.Log4NetLogger.Error(new Exception($"Кто вызывал {caller}"));
        }
    }
}
using System;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Transports;
using Microsoft.Owin.Cors;
using Owin;
using SignalRLibraryAutomations.HubError;

namespace SignalRLibraryAutomations.ConnectAutomations
{
   public class StartSignalR
    {
        public void Configuration(IAppBuilder app)
        {
            try
            {
                
                GlobalHost.HubPipeline.AddModule(new HubError.HubError());
                GlobalHost.Configuration.DisconnectTimeout = TimeSpan.FromHours(8);
                app.Map("/signalr", map =>
                {
                    map.UseCors(CorsOptions.AllowAll);
                    var hubConfiguration = new HubConfiguration
                    {
                        EnableDetailedErrors = true
                    };
                    map.RunSignalR(hubConfiguration);
                });

            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
        }
    }
}

using System;
using System.ServiceModel;
using System.ServiceProcess;
using System.Threading;
using ServiceAutomation.Service;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using SignalRLibraryAutomations.ConnectAutomations;

[assembly: OwinStartup(typeof(StartSignalR))]
namespace ServiceAutomation
{
    
     class ServiceAutomation : ServiceBase
    {
        public ServiceHost Service;
        public IDisposable MyServerAutomation { get; set; }

        protected override void OnStart(string[] args)
        {
            var url = "http://+:8060";
            MyServerAutomation = WebApp.Start(url);
            Service?.Close();
            Service = new ServiceHost(typeof(ServiceAuto));
            Service.Open();
            new Thread(StartAutomationService).Start();
        }

        void StartAutomationService()
        {
            Loggers.Log4NetLogger.Info(new Exception("Запустили сервис статистики автоматизации!"));
        }

        protected override void OnStop()
        {
            try
            {
                HubAutomations.Disconnected(null);
                if (Service != null)
                {
                    Service.Close();
                    Service = null;
                }
                MyServerAutomation?.Dispose();
                Loggers.Log4NetLogger.Info(new Exception("Остановили сервис статистики автоматизации!"));
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Info(e);
            }
        }
    }
}
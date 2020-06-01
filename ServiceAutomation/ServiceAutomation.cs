using System;
using System.ServiceModel;
using System.ServiceProcess;
using System.Threading;
using ServiceAutomation.Service;

namespace ServiceAutomation
{
     class ServiceAutomation : ServiceBase
    {
        public ServiceHost Service;

        protected override void OnStart(string[] args)
        {
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
                if (Service != null)
                {
                    Service.Close();
                    Service = null;
                }
                Loggers.Log4NetLogger.Info(new Exception("Остановили сервис статистики автоматизации!"));
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Info(e);
            }
        }
    }
}
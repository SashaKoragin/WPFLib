using System.ServiceProcess;

namespace ServiceAutomation
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static void Main()
        {
            var serviceRun = new ServiceBase[]
            {
                new ServiceAutomation()
            };
            ServiceBase.Run(serviceRun);
        }
    }
}
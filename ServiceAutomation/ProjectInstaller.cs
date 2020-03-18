using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace ServiceAutomation
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            var process = new ServiceProcessInstaller { Account = ServiceAccount.LocalSystem };
            var service = new ServiceInstaller
            {
                ServiceName = "ServiceAutomation",
                Description = "Служба статистики и аналитики АИС3!!!"
            };
            Installers.Add(process);
            Installers.Add(service);
        }
    }
}
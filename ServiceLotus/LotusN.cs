using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ServiceLotus
{
    public partial class LotusN : ServiceBase
    {

        public ServiceHost serviceHost = null;
        public LotusN()
        {
            // Name the Windows Service
            ServiceName = "LotusReport";
        }

        public static void Main()
        {
            ServiceBase.Run(new LotusN());
        }

        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }
            serviceHost = new ServiceHost(typeof(LotusNotes.Wcf.ServiceLotusNotes));
            serviceHost.Open();

        }

        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }
}
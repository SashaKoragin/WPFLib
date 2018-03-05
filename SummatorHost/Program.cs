using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SummatorHost
{
    class Program
    {
        static void Main()
        {
   
            try
            {
                using (ServiceHost host = new ServiceHost(typeof(LotusNotes.Wcf.ServiceLotusNotes)))
                {
                    host.Open();
                    Console.WriteLine("Наш Host запущен!!!");
                    Console.ReadLine();
        }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadLine();
            }
        }
    }
}

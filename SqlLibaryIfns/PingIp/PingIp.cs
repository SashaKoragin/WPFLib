using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using LibaryXMLAutoModelXmlSql.Model.ServerAndComputer;

namespace SqlLibaryIfns.PingIp
{
  public class PingIp
    {

        public ServerAndComputer Ping(ServerAndComputer server)
        {
            Ping ping = new Ping();
            PingReply pingReply = null;
            foreach (var servers in server.ServerIfns)
            {
                pingReply = ping.Send(servers.ServerIp);
                servers.Status = pingReply.Status.ToString();

            }
            return server;
        }

    }
}

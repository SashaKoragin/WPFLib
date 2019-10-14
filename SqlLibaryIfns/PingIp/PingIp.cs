using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using EfDatabase.Inventarization.Base;
using EfDatabase.Inventarization.BaseLogica.AddObjectDb;
using LibaryXMLAutoModelXmlSql.Model.ServerAndComputer;

namespace SqlLibaryIfns.PingIp
{
  public class PingIp
    {

        public ServerAndComputer Ping(ServerAndComputer server)
        {
            try
            {
            Ping ping = new Ping();
            PingReply pingReply = null;
            foreach (var servers in server.ServerIfns)
            {
                pingReply = ping.Send(servers.ServerIp);
                if (pingReply != null) servers.Status = pingReply.Status.ToString();
            }
            return server;
            }
            catch (Exception e)
            {
                Loggers.Log4NetLogger.Error(e);
            }
            return null;
        }
        /// <summary>
        /// Поик и отпускания в БД наименования рабочих станций
        /// </summary>
        /// <param name="pathdomain">путь к домену конечной точки</param>
        /// <param name="workstation">Рабочии станции</param>
        public void FindIpHost(string pathdomain,string workstation)
        {
            var directoryEntry = new DirectoryEntry("LDAP://regions.tax.nalog.ru") {Path = pathdomain};
            DirectorySearcher searcher = new DirectorySearcher(directoryEntry) {Filter = workstation};
            var allhost = searcher.FindAll();
            AddObjectDb add = new AddObjectDb();
            ComputerIpAdressSynhronization synhronization = new ComputerIpAdressSynhronization();
            add.ClearsHostSynhronization();
            add.IsProcessComplete(1,false);
            foreach (SearchResult find in allhost)
            {
                var namecomputers = find.GetDirectoryEntry().Name.Replace("CN=", "");
                try
                {
                    IPAddress[] adress = Dns.GetHostAddresses(namecomputers);
                    synhronization.IpAdress = adress[0].ToString();
                    synhronization.NameHost = namecomputers;
                    synhronization.MacAdress = null;
                    synhronization.StatusIp = null;
                    synhronization.UserName = null;
                    add.AddHostSynhronization(synhronization);
                }
                catch (Exception exception)
                {
                    synhronization.IpAdress = null;
                    synhronization.NameHost = namecomputers;
                    synhronization.MacAdress = null;
                    synhronization.StatusIp = exception.Message;
                    synhronization.UserName = null;
                    add.AddHostSynhronization(synhronization);
                }
            }
            add.IsProcessComplete(1, true);
        }
    }
}

using System;
using System.DirectoryServices;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using EfDatabase.Inventory.Base;
using EfDatabase.Inventory.BaseLogic.AddObjectDb;
using LibaryXMLAutoModelXmlSql.Model.ServerAndComputer;

namespace SqlLibaryIfns.PingIp
{
  public class PingIp
    {

        public ServerAndComputer Ping(ServerAndComputer server)
        {
            try
            {
                var ping = new Ping();
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

        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        public static extern int SendARP(int DestIP, int SrcIP, [Out] byte[] pMacAddr, ref int PhyAddrLen);
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
            Regex ip = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
            foreach (SearchResult find in allhost)
            {
                var namecomputers = find.GetDirectoryEntry().Name.Replace("CN=", "");
                try
                {
                    IPAddress[] adress = Dns.GetHostAddresses(namecomputers);
                    byte[] ab = new byte[6];
                    int len = ab.Length;
                    int r = SendARP(BitConverter.ToInt32(adress[0].GetAddressBytes(), 0), 0, ab, ref len);
                    string mac = BitConverter.ToString(ab, 0, 6);
                    synhronization.IpAdress = adress[0].ToString();
                    synhronization.NameHost = namecomputers;
                    synhronization.MacAdress = mac;
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

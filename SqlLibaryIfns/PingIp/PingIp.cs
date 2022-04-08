using System;
using System.Collections.Generic;
using System.DirectoryServices;
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
                foreach (var servers in server.ServerIfns)
                {
                    var pingReply = ping.Send(servers.ServerIp);
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
        public static extern int SendARP(int destIp, int srcIp, [Out] byte[] pMacAddress, ref int phyAddressLen);
        /// <summary>
        /// Поиcк и отпускания в БД наименования рабочих станций
        /// </summary>
        /// <param name="directoryEntryDomain">Директория</param>
        /// <param name="pathDomain">путь к домену конечной точки</param>
        /// <param name="workstation">Рабочие станции</param>
        public void FindIpHost(string directoryEntryDomain, string pathDomain,string workstation)
        {
            var directoryEntry = new DirectoryEntry(directoryEntryDomain) {Path = pathDomain };
            DirectorySearcher searcher = new DirectorySearcher(directoryEntry) {Filter = workstation};
            var allHost = searcher.FindAll();
            AddObjectDb add = new AddObjectDb();
            ComputerIpAdressSynhronization synchronization = new ComputerIpAdressSynhronization();
            add.ClearsHostSynhronization();
            add.IsProcessComplete(1,false);
            Regex ip = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
            foreach (SearchResult find in allHost)
            {
                var nameComputers = find.GetDirectoryEntry().Name.Replace("CN=", "");
                try
                {
                    IPAddress[] address = Dns.GetHostAddresses(nameComputers);
                    byte[] ab = new byte[6];
                    int len = ab.Length;
                    SendARP(BitConverter.ToInt32(address[0].GetAddressBytes(), 0), 0, ab, ref len);
                    string[] macAddressString = new string[(int) len];
                    for (int i = 0; i < len; i++)
                    {
                        macAddressString[i] = ab[i].ToString("x2");
                    }
                    synchronization.IpAdress = address[0].ToString();
                    synchronization.NameHost = nameComputers;
                    synchronization.MacAdress = string.Join(":", macAddressString);
                    synchronization.StatusIp = null;
                    synchronization.UserName = null;
                    add.AddHostSynhronization(synchronization);
                }
                catch (Exception exception)
                {
                    synchronization.IpAdress = null;
                    synchronization.NameHost = nameComputers;
                    synchronization.MacAdress = null;
                    synchronization.StatusIp = exception.Message;
                    synchronization.UserName = null;
                    add.AddHostSynhronization(synchronization);
                }
            }
            add.IsProcessComplete(1, true);
        }
        /// <summary>
        /// Ping серверов на доступность в сети
        /// </summary>
        /// <param name="listServetIpDataBase">Список серверов и Ip</param>
        public void PingServerDataBase(ref List<AllIpServerSelect> listServetIpDataBase)
        {
            var ping = new Ping();
            foreach (var allIpServerSelect in listServetIpDataBase)
            {
                var pingReply = ping.Send(allIpServerSelect.IpAdress);
                if (pingReply != null)
                {
                    if (pingReply.Status == IPStatus.Success)
                    {
                        allIpServerSelect.InfoStatusReport = pingReply.Status.ToString();
                        allIpServerSelect.ColorStatus = "FF92D050";
                    }
                    else
                    {
                        allIpServerSelect.InfoStatusReport = pingReply.Status.ToString();
                        allIpServerSelect.ColorStatus = "FFFF0000";
                    }
                }
                else
                {
                    allIpServerSelect.InfoStatusReport = "Статус не определен!!!";
                    allIpServerSelect.ColorStatus = "FFFF0000";
                }
            }
        }
    }
}

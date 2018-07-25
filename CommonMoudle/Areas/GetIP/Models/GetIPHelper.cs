using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Sockets;

namespace CommonMoudle.Areas.GetIP.Models
{
    public class GetIPHelper
    {
        /// <summary>
        /// 取得目前IP
        /// </summary>
        /// <returns></returns>
        public static String GetLocalIP()
        {
            IPHostEntry host;
            string localIP = "IP";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SCNEXTCoreApp.Models.ViewModel
{
    public class UserDetails
    {

        //public static string Id { get; set; }

        public static class GetIPAddress
        {
            public static string getExternalIp()
            {
                try
                {
                    string externalIP;
                    externalIP = (new WebClient()).DownloadString("http://checkip.dyndns.org/");
                    externalIP = (new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}"))
                                 .Matches(externalIP)[0].ToString();
                    return externalIP;
                }
                catch { return null; }
            }



            //[Obsolete]
            //public static string GetMyIp()
            //{
            //    string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
            //                                         // Get the IP  
            //    string myIP = Dns.GetHostByName(hostName).AddressList[1].ToString();
            //    return myIP;

            //}

        }

    }
}


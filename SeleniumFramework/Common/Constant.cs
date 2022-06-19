using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework.Common
{
    public static class Constant
    {
        public static readonly string _webConfigPath = ConfigurationManager.AppSettings["webConfigPath"];
        public static readonly int _downloadReportWaitTime = int.Parse(ConfigurationManager.AppSettings["DownloadReportWaitTime"]);
        public static readonly string username = ConfigurationManager.AppSettings["username"];
        public static readonly string useremail = ConfigurationManager.AppSettings["useremail"];
        public static readonly string userpass = ConfigurationManager.AppSettings["userpass"];
    }
}

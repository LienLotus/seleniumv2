using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumFramework.Tools;

namespace SeleniumFramework.Common
{
    public static class FileSearch
    {
        /// <summary>
        /// Searches the folder structure for data storage folders
        /// </summary>
        public static string GetFullPath(String folder)
        {
            string path = "undefined";
 
            try
            {
                path = AppDomain.CurrentDomain.BaseDirectory;
  
                Boolean search = true;

                while (search)
                {
                    if (!Directory.Exists($"{path}\\{folder}"))
                    {
                        path = path.Substring(0, path.LastIndexOf("\\"));
                        Logging.Info($"the folder structure for data storage folders is {path}");
                    }
                    else
                    {
                        search = false;
                    }
                }

            }
            catch (Exception e)
            {
                Logging.Error(e.ToString());
                throw new Exception($"{e.Message}, path is {path}...checking if {path}\\{folder} exists");
            }

            return $"{path}\\{folder}";
        
        }
    }
}

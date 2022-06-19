using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework.Tools
{
    public class Logging
    {
        private static readonly log4net.ILog _logger =
            log4net.LogManager.GetLogger("AutomationTesting");

        public static void Info(string message)
        {
            _logger.Info(message);
        }

        public static void Debug(string message)
        {
            _logger.Debug(message);
        }

        public static void Error(string message)
        {
            _logger.Error(message);
        }

        public static void Error(Exception ex)
        {
            _logger.Error(ex);
        }


        public static void StartTestClass(string strClassName, string strClassDescriptions)
        {
            _logger.Info("****************************************************************************************");

            _logger.Info("*********************         Starting Test Class       ********************************");

            _logger.Info("$$$$$$$$$$$$$$$$$$$$$        " + strClassName + "       $$$$$$$$$$$$$$$$$$$$$$$$$");
            _logger.Info("$$$$$$$$$$$$$$$$$$$$$        " + strClassDescriptions + "       $$$$$$$$$$$$$$$$$$$$$$$$$");

            _logger.Info("****************************************************************************************");

            _logger.Info("****************************************************************************************");
        }

        public static void StartTestMethod(string strTestMethod, string strTestMethodDesc)
        {
            _logger.Info("$$$$        " + strTestMethod + "       $$$$");
            _logger.Info("$$$$        " + strTestMethodDesc + "       $$$$");
        }
    }
}

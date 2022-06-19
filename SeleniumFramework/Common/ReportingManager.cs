using RelevantCodes.ExtentReports;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using System.Configuration;

namespace SeleniumFramework.Common
{
    public class ReportingManager
    {
        private static ExtentReports _instance;

        private static readonly string testProj =
            TestContext.CurrentContext.Test.FullName.Substring(0, TestContext.CurrentContext.Test.FullName.IndexOf("."));
        private static readonly string dir = FileSearch.GetFullPath("Data").Replace("\\Data", "");
        static ReportingManager()
        {

            if (!Directory.Exists($"{dir}\\Test_Execution_Reports\\{testProj}_{DateTime.Now.ToShortDateString().Replace("/", "-")}"))
            {
                Directory.CreateDirectory($"{dir}\\Test_Execution_Reports\\{testProj}_{DateTime.Now.ToShortDateString().Replace("/", "-")}");
            }

            _instance = new ExtentReports($"{dir}\\Test_Execution_Reports\\{testProj}_{DateTime.Now.ToShortDateString().Replace("/", "-")}\\htmlReport.html", false);
        }

        public static ExtentReports Instance
        {
            get
            {
                return _instance;
            }
        }

        public static string Capture(IWebDriver driver, string screenShotName)
        {

            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenShot = ts.GetScreenshot();
            DirectoryInfo di = Directory.CreateDirectory($"{dir}\\Test_Execution_Reports\\{testProj}_{DateTime.Now.ToShortDateString().Replace("/", "-")}\\Tests_ScreenShots");
            string finalPath = $"{dir}\\Test_Execution_Reports\\{testProj}_{DateTime.Now.ToShortDateString().Replace("/", "-")}\\Tests_ScreenShots\\{ screenShotName}.png";
            string localPath = new Uri(finalPath).LocalPath;
            screenShot.SaveAsFile(localPath);

            return $".\\Tests_ScreenShots\\{screenShotName}.png";
        }
    }
}

using RelevantCodes.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumFramework.Common;
using System;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace SeleniumFramework.Tools
{
    public class Browser
    {
        public ExtentTest ExtensiveTestReport
        {
            get; set;
        }

        private readonly ScreenSetting _screen;
        private static readonly string _debug = ConfigurationManager.AppSettings["debug"];
        private static string _headless = ConfigurationManager.AppSettings["headless"];
        private static readonly string _browser = ConfigurationManager.AppSettings["browser"];
        private static readonly string _baseUrl = ConfigurationManager.AppSettings["url"];
        private static readonly string _downloadedFolderPath = ConfigurationManager.AppSettings["DownloadedFolderPath"];

        public string Title
        {
            get
            {
                return Driver.Title;
            }
        }

        public IWebDriver Driver
        {
            get;
        }

        public void Refresh()
        {
            Driver.Navigate().Refresh();
        }

        public Browser()
        {
            switch (_browser)
            {
                case "Chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddUserProfilePreference("download.default_directory", _downloadedFolderPath);
                    options.AddUserProfilePreference("intl.accept_languages", "nl");
                    options.AddUserProfilePreference("disable-popup-blocking", "true");
                    if (_headless.ToLower().Equals("true"))
                    {
                        options.AddArguments("headless");
                        options.AddArguments("disable-gpu");
                        Driver = new ChromeDriver(options);
                    }
                    else
                    {
                        Driver = new ChromeDriver(options);
                        _screen = new ScreenSetting().Next();
                        Driver.Manage().Window.Size = _screen.Size;
                        Driver.Manage().Window.Position = _screen.Point;
                    }
                    Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    break;
                case "IE":
                    // For IE
                    break;
                default:
                    // For another browsre
                    break;
            }
        }

        public void Goto()
        {
            Driver.Navigate().GoToUrl(_baseUrl);
        }
        public void Close()
        {
            Driver.Quit();
        }

        public void WriteLog(LogStatus status, string message, [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string caller = null)
        {
            if (status.Equals(LogStatus.Unknown) && _debug.ToLower().Equals("true"))
            {
                ExtensiveTestReport.Log(status, message + " at line " + lineNumber + " (" + caller + ")");
                Logging.Info(message + " at line " + lineNumber + " (" + caller + ")");
            }
            else if (!status.Equals(LogStatus.Unknown))
            {
                ExtensiveTestReport.Log(status, message + " at line " + lineNumber + " (" + caller + ")");
                Logging.Info(message + " at line " + lineNumber + " (" + caller + ")");
            }
        }

        public void SetScreen()
        {
            if (!_headless.ToLower().Equals("true"))
            {
                Driver.Manage().Window.Size = _screen.Size;
                Driver.Manage().Window.Position = _screen.Point;
            }
        }

        public void AssertIsTrue(bool value)
        {
            try
            {
                Assert.IsTrue(value);
                this.WriteLog(LogStatus.Pass, "Assert succeded.");
                Logging.Info("Assert succeded");
            }
            catch (AssertionException ae)
            {
                this.WriteLog(LogStatus.Error, "Assert failed. Expected is true but was false");
                Logging.Error("Assert failed. Expected is true but was false");
                throw ae;
            }
        }

        public void AssertIsFalse(bool value)
        {
            try
            {
                Assert.IsFalse(value);
                this.WriteLog(LogStatus.Pass, "Assert succeded.");
                Logging.Info("Assert succeded");
            }
            catch (AssertionException ae)
            {
                this.WriteLog(LogStatus.Error, "Assert failed. Expected is false but was true");
                Logging.Error("Assert failed. Expected is false but was true");
                throw ae;
            }
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumFramework.Tools;
using System;
using System.Collections.Generic;
using RelevantCodes.ExtentReports;
using System.Linq;
using SeleniumFramework.Extensions;
using SeleniumFramework.Common;
using System.Threading;

namespace SeleniumFramework.PageItems.ArticlePages
{
    public class SettingsPage : Page
    {
        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-outline-danger']")]
        private IWebElement logOutButton;

        public void Logout()
        {
            Browser.WriteLog(LogStatus.Info, "+++++++++++++ Logout ++++++++++++++");
            logOutButton.ClickCheck(Browser);
        }
    }
}

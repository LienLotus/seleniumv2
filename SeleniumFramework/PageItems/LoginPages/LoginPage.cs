using RelevantCodes.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumFramework.EntitiesRegulators;
using SeleniumFramework.Extensions;
using SeleniumFramework.Models;
using System;
using SeleniumFramework.Exceptions;
using System.Threading;
using System.Configuration;

namespace SeleniumFramework.PageItems
{
    public class LoginPage : Page
    {
        public void Goto()
        {
            Browser.WriteLog(LogStatus.Info, "+++++++++++++ Goto ++++++++++++++");
            Browser.Goto();
        }
    }
}
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

namespace SeleniumFramework.PageItems
{
    public class HomePage : Page
    {
        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname=username]")]
        private IWebElement usernameBox;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname=email]")]
        private IWebElement emailBox;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname=password]")]
        private IWebElement passwordBox;

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        private IWebElement signInButton;

        public void LogIn()
        {
            Browser.WriteLog(LogStatus.Info, "+++++++++++++ LogIn ++++++++++++++");
            emailBox.ReplaceText(Constant.useremail, Browser, "emailBox");
            passwordBox.ReplaceText(Constant.userpass, Browser, "passwordBox");
            signInButton.ClickCheck(Browser, "signInButton");
            Browser.WaitForElementVisibility(By.XPath("//a[contains(@href,'/editor')]"), "NewArticle");
        }
    }
}

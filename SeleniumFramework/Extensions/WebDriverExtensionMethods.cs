using RelevantCodes.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumFramework.Tools;
using System;
using System.IO;
using System.Threading;
using SeleniumFramework.Common;
using System.Configuration;
using System.Collections.Generic;
namespace SeleniumFramework.Extensions
{
    public static class ExtensionMethods
    {
        private static int _webdriverWait = int.Parse(ConfigurationManager.AppSettings["WEBDRIVERTIMEOUT"]);
        public static string _link = "Link";
        public static string _xpath = "Xpath";

        public static void HoverAndClick(this Browser browser, IWebElement menu, IWebElement link)
        {
            int count = 0;
            bool retry = true;
            while (retry)
                try
                {
                    Actions action = new Actions(browser.Driver);
                    action.MoveToElement(menu).Click(link).Build().Perform();
                    retry = false;
                    browser.WriteLog(LogStatus.Info, $"Click on navigation menu {menu} successful");
                }
                catch (WebDriverException wde)
                {
                    count++;
                    Thread.Sleep(100);
                    if (count > 10)
                    {
                        browser.WriteLog(LogStatus.Unknown, $"Click on navigation menu {menu} failed");
                        Logging.Error($"Click on navigation menu {menu} failed");
                        retry = false;
                    }
                }
        }

        public static bool ClickCheck(this IWebElement element, Browser browser, string name = "")
        {
            bool retry = true;
            var count = 0;
            while (retry)
            {
                try
                {
                    if (ExistInCurrentContext(element, browser, name))
                    {
                        Actions actions = new Actions(browser.Driver);
                        actions.MoveToElement(element).Click().Build().Perform();
                        Logging.Info($"Click into element {name} successfully");
                        browser.WriteLog(LogStatus.Info, $"Click into element {name} successfully");
                        return true;
                    }
                    else
                    {
                        Thread.Sleep(500);
                    }
                }
                catch (Exception ex)
                {
                    Logging.Error($"Unable to click on IWebElement {name} failed: {ex.InnerException}");
                }
                finally
                {
                    count++;
                    if (count > 10)
                    {
                        browser.WriteLog(LogStatus.Info, $"Unable to click on IWebElement {name}");
                        retry = false;
                    }
                }
            }
            return false;
        }

        public static Boolean ReplaceText(this IWebElement element, string message, Browser browser, string name = "")
        {
            Exception exception = null;
            if (ExistInCurrentContext(element, browser, name))
            {
                int count = 0;
                bool retry = true;
                while (retry)
                {
                    try
                    {
                        Actions actions = new Actions(browser.Driver);
                        actions.MoveToElement(element).Click().Build().Perform();
                        element.Clear();
                        Actions select = new Actions(browser.Driver);
                        select.DoubleClick(element).Build().Perform();
                        element.SendKeys(message);
                        Logging.Info($"ReplaceText({name}): value: {message}");
                        browser.WriteLog(LogStatus.Info, $"ReplaceText({name}): value: {message}");
                        return true;
                    }
                    catch (Exception e)
                    {
                        exception = e;
                        Logging.Error($"Element can't be replaced at time {count}, exception message is: {exception?.Message}");
                        Thread.Sleep(500);
                        count++;
                        if (count > 10)
                        {
                            browser.WriteLog(LogStatus.Info, $"Element {name} can't be replaced at time {count}, exception message is: {exception?.Message}");
                            retry = false;
                        }
                    }
                }
            }
            return false;
        }

        public static Boolean ExistInCurrentContext(IWebElement element, Browser browser, string name = "")
        {
            int waitTime = 500;
            var oldTimeout = browser.Driver.Manage().Timeouts().ImplicitWait;

            browser.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(waitTime);
            bool retry = true;
            var count = 0;
            string message = "";
            while (retry)
            {
                try
                {
                    var available = element.Enabled && element.Displayed;
                    if (available)
                    {
                        if (message.Length > 0)
                        {
                            browser.WriteLog(LogStatus.Unknown, message);
                            Logging.Info(message);
                        }
                        return true;
                    }
                    else
                    {
                        Thread.Sleep(500);
                    }
                    message = $"The element is either not displayed or not enabled - {name}, try n:{count}";
                    Logging.Error(message);
                }
                catch
                {
                    message = $"The element was not found in the current context - {name} - Waited ''{count * waitTime} milliseconds''";
                    Logging.Debug(message);
                }
                finally
                {
                    count++;
                    if (count > 10)
                    {
                        retry = false;
                    }

                }
            }
            browser.Driver.Manage().Timeouts().ImplicitWait = oldTimeout;
            return false;
        }

        public static void WaitForElementVisibility(this Browser browser, By byObject, string elementName = "")
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(browser.Driver, TimeSpan.FromSeconds(_webdriverWait));
                wait.Until(ExpectedConditions.ElementIsVisible(byObject));

                string info = string.Format("Wait for  element [{0}] visible", elementName);
                browser.WriteLog(LogStatus.Info, info);
            }
            catch (WebDriverTimeoutException ex)
            {
                var message = string.Format("The element [{0}] wasn't visible", elementName);
                browser.WriteLog(LogStatus.Unknown, message);
                throw ex;
            }
        }
    }
}


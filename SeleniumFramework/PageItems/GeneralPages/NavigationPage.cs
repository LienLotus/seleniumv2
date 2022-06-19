using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Configuration;

namespace SeleniumFramework.PageItems
{
    public class NavigationPage : Page
    {
        private static readonly string _baseUrl = ConfigurationManager.AppSettings["url"];

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'/editor')]")]
        private IWebElement newArticleLink;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'/login')]")]
        private IWebElement signInLink;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'/settings')]")]
        private IWebElement settingsInLink;



        public void GotoNewArticle()
        {
            newArticleLink.Click();
        }

        public void GotoSignIn()
        {
            signInLink.Click();
        }

        public void GotoSettings()
        {
            settingsInLink.Click();
        }
    }
}
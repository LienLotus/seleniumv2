using OpenQA.Selenium.Support.PageObjects;
using SeleniumFramework.PageItems.ArticlePages;
using SeleniumFramework.Tools;
using System;

namespace SeleniumFramework.PageItems
{
    public class Pages
    {
        private Browser Browser;

        public Browser GetBrowser()
        {
            return this.Browser;
        }

        public Pages(Browser browser)
        {
            this.Browser = browser;
        }
        private T GetPage<T>() where T : new()
        {
            try
            {
                var page = new T();
                PageFactory.InitElements(Browser.Driver, page);
                return page;
            }
            catch (InvalidOperationException e)
            {
                return default(T);
            }
        }

        public LoginPage LoginPage
        {
            get
            {
                var page = GetPage<LoginPage>();
                page.Browser = Browser;
                return page;
            }
        }

        public HomePage HomePage
        {
            get
            {
                var page = GetPage<HomePage>();
                page.Browser = Browser;
                return page;
            }
        }

        public SettingsPage SettingsPage
        {
            get
            {
                var page = GetPage<SettingsPage>();
                page.Browser = Browser;
                return page;
            }
        }

        public NavigationPage NavigationPage
        {
            get
            {
                var page = GetPage<NavigationPage>();
                page.Browser = Browser;
                return page;
            }
        }

        public NewArticlePage NewArticlePage
        {
            get
            {
                var page = GetPage<NewArticlePage>();

                page.Browser = Browser;
                return page;
            }
        }

        public UpdateArticlePage UpdateArticlePage
        {
            get
            {
                var page = GetPage<UpdateArticlePage>();
                page.Browser = Browser;
                return page;
            }
        }
    }
}
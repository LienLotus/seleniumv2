using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumFramework.Tools;
using System;
using System.Collections.Generic;
using RelevantCodes.ExtentReports;
using System.Linq;
using SeleniumFramework.Extensions;
using SeleniumFramework.Common;
using SeleniumFramework.Models;

namespace SeleniumFramework.PageItems
{
    public class NewArticlePage : Page
    {
        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname=title]")]
        private IWebElement articleTitleBox;

        [FindsBy(How = How.CssSelector, Using = "input[formcontrolname=description]")]
        private IWebElement articleDesBox;

        [FindsBy(How = How.CssSelector, Using = "textarea[placeholder='Write your article (in markdown)']")]
        private IWebElement articleContentBox;

        [FindsBy(How = How.CssSelector, Using = "input[placeholder='Enter tags']")]
        private IWebElement articleTag;

        [FindsBy(How = How.XPath, Using = "//button[@type='button']")]
        private IWebElement publishArticleButton;

        [FindsBy(How = How.CssSelector, Using = "textarea[placeholder='Write a comment...']")]
        private IWebElement commentBox;

        public void FillNewArticle(Article art)
        {
            Browser.WriteLog(LogStatus.Info, "+++++++++++++ FillArticle ++++++++++++++");
            articleTitleBox.ReplaceText(art.Title, Browser, "articleTitleBox");
            articleDesBox.ReplaceText(art.Description, Browser, "articleDesBox");
            articleContentBox.ReplaceText(art.Content, Browser, "articleContentBox");
            articleTag.ReplaceText(art.Tag, Browser, "articleTag");
            publishArticleButton.ClickCheck(Browser, "publishArticleButton");
        }
        public bool IsCommentBoxDisplayed()
        {
            Browser.WriteLog(LogStatus.Info, "+++++++++++++ IsCommentBoxDisplayed ++++++++++++++");
            return ExtensionMethods.ExistInCurrentContext(commentBox, Browser, "commentBox");
        }
    }
}

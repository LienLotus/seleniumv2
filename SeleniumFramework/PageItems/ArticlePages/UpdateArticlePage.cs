using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumFramework.Tools;
using RelevantCodes.ExtentReports;
using SeleniumFramework.Extensions;
using SeleniumFramework.Models;

namespace SeleniumFramework.PageItems
{
    public class UpdateArticlePage : Page
    {
        [FindsBy(How = How.CssSelector, Using = "a[href *= '/editor/']")]
        private IWebElement editArticleButton;

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

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-sm btn-outline-danger']")]
        private IWebElement deleteArticleButton;

        public void UpdateArticle(Article art)
        {
            Browser.WriteLog(LogStatus.Info, "+++++++++++++ UpdateArticle ++++++++++++++");
            editArticleButton.ClickCheck(Browser, "editArticleButton");
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

        public void DeleteArticle()
        {
            Browser.WriteLog(LogStatus.Info, "+++++++++++++ DeleteArticle ++++++++++++++");
            deleteArticleButton.ClickCheck(Browser);
            ExtensionMethods.WaitForElementVisibility(Browser, By.XPath("//*[contains(text(),'Global Feed' )]"));
        }
    }
}

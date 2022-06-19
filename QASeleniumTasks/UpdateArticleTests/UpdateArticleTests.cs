using NUnit.Framework;
using SeleniumFramework.EntitiesRegulators;
using SeleniumFramework.FeaturesEnumerators;
using System.Threading;

namespace QASeleniumTasks.UpdateArticleTests
{
    [TestFixture]
    class UpdateArticleTests : TestBase
    {
        // Browser should raise a message when updating article successfully or error

        [Test, Retry(3)]
        [Author("Lien.NguyenThi")]
        [Category("Create")]
        public void UpdateArticleAfterCreating()
        {
            // Firstly, create an article to update later
            Pages.NavigationPage.GotoNewArticle();
            Pages.NewArticlePage.FillNewArticle(NewArticleRegulator.TakeByFeature(ArticleFeature.Create));
            Browser.AssertIsTrue(Pages.NewArticlePage.IsCommentBoxDisplayed());

            // Update new values for the created article
            Pages.UpdateArticlePage.UpdateArticle(NewArticleRegulator.TakeByFeature(ArticleFeature.CreateSpecialCharacters));
            Browser.AssertIsTrue(Pages.NewArticlePage.IsCommentBoxDisplayed());
        }
    }
}

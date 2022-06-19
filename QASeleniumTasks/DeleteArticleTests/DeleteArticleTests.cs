using NUnit.Framework;
using SeleniumFramework.EntitiesRegulators;
using SeleniumFramework.Extensions;
using SeleniumFramework.FeaturesEnumerators;
using System.Threading;

namespace QASeleniumTasks.DeleteArticleTests
{
    class DeleteArticleTests : TestBase
    {
        [Test, Retry(1)]
        [Author("Lien.NguyenThi")]
        [Category("Create")]
        public void DeleteArticleAfterCreating()
        {
            // Firstly, create an article before delete
            Pages.NavigationPage.GotoNewArticle();
            Pages.NewArticlePage.FillNewArticle(NewArticleRegulator.TakeByFeature(ArticleFeature.Create));
            Browser.AssertIsTrue(Pages.NewArticlePage.IsCommentBoxDisplayed());

            // Delete the created article
            Pages.UpdateArticlePage.DeleteArticle();
            Browser.AssertIsFalse(Pages.UpdateArticlePage.IsCommentBoxDisplayed());
        }
    }
}

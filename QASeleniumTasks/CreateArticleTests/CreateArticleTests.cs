using NUnit.Framework;
using SeleniumFramework.EntitiesRegulators;
using SeleniumFramework.FeaturesEnumerators;

namespace QASeleniumTasks.CreateArticleTests
{
    [TestFixture]
    class CreateArticleTests : TestBase
    {
        // Browser should raise a message when adding article successfully or error

        [Test, Retry(1)]
        [Author("Lien.NguyenThi")]
        [Category("Create")]
        public void CreateArticleAllValidFields()
        {
            Pages.NavigationPage.GotoNewArticle();
            Pages.NewArticlePage.FillNewArticle(NewArticleRegulator.TakeByFeature(ArticleFeature.Create));
            Browser.AssertIsTrue(Pages.NewArticlePage.IsCommentBoxDisplayed());
        }

        [Test, Retry(1)]
        [Author("Lien.NguyenThi")]
        [Category("Create")]
        public void CreateArticleMissingAllFields()
        {
            Pages.NavigationPage.GotoNewArticle();
            Pages.NewArticlePage.FillNewArticle(NewArticleRegulator.TakeByFeature(ArticleFeature.CreateMissingAll));
            Browser.AssertIsFalse(Pages.NewArticlePage.IsCommentBoxDisplayed());
        }

        [Test, Retry(1)]
        [Author("Lien.NguyenThi")]
        [Category("Create")]
        public void CreateArticleMissingArticleTitle()
        {
            Pages.NavigationPage.GotoNewArticle();
            Pages.NewArticlePage.FillNewArticle(NewArticleRegulator.TakeByFeature(ArticleFeature.CreateMissingTitle));
            Browser.AssertIsFalse(Pages.NewArticlePage.IsCommentBoxDisplayed());
        }

        [Test, Retry(1)]
        [Author("Lien.NguyenThi")]
        [Category("Create")]
        public void CreateArticleMissingArticleDes()
        {
            Pages.NavigationPage.GotoNewArticle();
            Pages.NewArticlePage.FillNewArticle(NewArticleRegulator.TakeByFeature(ArticleFeature.CreateMissingDes));
            Browser.AssertIsFalse(Pages.NewArticlePage.IsCommentBoxDisplayed());
        }

        [Test, Retry(1)]
        [Author("Lien.NguyenThi")]
        [Category("Create")]
        public void CreateArticleMissingArticleContent()
        {
            Pages.NavigationPage.GotoNewArticle();
            Pages.NewArticlePage.FillNewArticle(NewArticleRegulator.TakeByFeature(ArticleFeature.CreateMissingContent));
            Browser.AssertIsTrue(Pages.NewArticlePage.IsCommentBoxDisplayed());
        }

        [Test, Retry(1)]
        [Author("Lien.NguyenThi")]
        [Category("Create")]
        public void CreateArticleContainsSpecialCharacters()
        {
            Pages.NavigationPage.GotoNewArticle();
            Pages.NewArticlePage.FillNewArticle(NewArticleRegulator.TakeByFeature(ArticleFeature.CreateSpecialCharacters));
            Browser.AssertIsTrue(Pages.NewArticlePage.IsCommentBoxDisplayed());
        }
    }
}

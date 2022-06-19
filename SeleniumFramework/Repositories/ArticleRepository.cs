
using SeleniumFramework.EntitiesRegulators;
using SeleniumFramework.Models;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumFramework.Repositories
{
    public class ArticleRepository
    {
        private static IEnumerable<Article> _article = EntitiesReader<Article>.getEntities();

        public Article GetOne()
        {
            return _article.FirstOrDefault();
        }

        public IEnumerable<Article> GetAll()
        {
            return _article;
        }
    }
}

using SeleniumFramework.Exceptions;
using SeleniumFramework.FeaturesEnumerators;
using SeleniumFramework.Models;
using SeleniumFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using SeleniumFramework.Tools;

namespace SeleniumFramework.EntitiesRegulators
{
    public class NewArticleRegulator
    {
        private static ArticleRepository _article = new ArticleRepository();

        public static Article TakeByFeature(ArticleFeature articleFeature)
        {
            Article ac = _article.GetAll().FirstOrDefault(t => t.Feature.Equals(Enum.GetName(typeof(ArticleFeature), articleFeature)));
            if (ac != null)
            {
                Console.WriteLine("==> Print article:" + ac);
                return ac;
            }
            Logging.Debug($"Article not found for feature: {Enum.GetName(typeof(ArticleFeature), articleFeature)}");
            throw new EntityNotFoundException($"Article not found for feature: {Enum.GetName(typeof(ArticleFeature), articleFeature)}");
        }

        public static List<Article> TakeByFeatures(ArticleFeature articleFeature)
        {
            IEnumerable<Article> acs = _article.GetAll().Where(t => t.Feature.Equals(Enum.GetName(typeof(ArticleFeature), articleFeature)));
            if (acs.Any())
            {
                return acs.ToList();
            }
            Logging.Debug($"Article not found for feature: {Enum.GetName(typeof(ArticleFeature), articleFeature)}");
            throw new EntityNotFoundException($"Article not found for feature: {Enum.GetName(typeof(ArticleFeature), articleFeature)}");
        }
    }
}

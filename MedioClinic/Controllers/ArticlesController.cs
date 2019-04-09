using System;
using System.Web.Mvc;
using System.Web.UI;
using Business.DependencyInjection;
using Business.Dto.Articles;
using Business.Repository.Article;
using Business.Services.Cache;
using CMS.DocumentEngine.Types.MedioClinic;
using MedioClinic.Models.Articles;

namespace MedioClinic.Controllers
{
    public class ArticlesController : BaseController
    {
        private IArticleRepository ArticleRepository { get; }
        private IArticleSectionRepository ArticleSectionRepository { get; }

        public ArticlesController(
            IBusinessDependencies dependencies,
            IArticleRepository articleRepository,
            IArticleSectionRepository articleSectionRepository
            ) : base(dependencies)
        {
            ArticleRepository = articleRepository;
            ArticleSectionRepository = articleSectionRepository;
        }

        public ActionResult Index()
        {
            var articleSection = Dependencies.CacheService.Cache(
                () => ArticleSectionRepository.GetArticleSection(), // Gets data for the ArticleSection if there isn't any cached data (data was invalidated or cache expired)
                60, // Sets caching of data to 60 minutes
                $"{nameof(ArticlesController)}|{nameof(Index)}|{nameof(ArticleSectionDto)}", // cached data identifier
                Dependencies.CacheService.GetNodesCacheDependencyKey(Article.CLASS_NAME, CacheDependencyType.All) // cache dependencies
                );

            if (articleSection == null)
            {
                return HttpNotFound();
            }

            var model = GetPageViewModel(new ArticlesViewModel()
            {
                Articles = ArticleRepository.GetArticles(),
                ArticleSection = articleSection
            }, articleSection.Header);

            return View(model);
        }

        [OutputCache(Duration = 3600, VaryByParam = "nodeGuid", Location = OutputCacheLocation.Server)]
        public ActionResult Detail(Guid nodeGuid, string nodeAlias)
        {
            var article = ArticleRepository.GetArticle(nodeGuid);

            if (article == null)
            {
                return HttpNotFound();
            }

            // Sets cache dependency on single page based on NodeGUID
            // System clears the cache when given article is deleted or edited in Kentico
            Dependencies.CacheService.SetOutputCacheDependency(nodeGuid);

            var model = GetPageViewModel(new ArticleDetailViewModel()
            {
                Article = article
            }, article.Title);

            return View(model);
        }
    }
}
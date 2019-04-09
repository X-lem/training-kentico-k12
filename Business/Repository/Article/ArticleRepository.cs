using Business.Dto.Articles;
using Business.Services.Context;
using Business.Services.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Repository.Article
{
    public class ArticleRepository : BaseRepository, IArticleRepository
    {
        private readonly string[] _articleColumns =
        {
            // Defines database columns for retrieving data
            // NodeGuid is retrieved automatically
            "NodeID", "NodeAlias", "Title", "Summary", "Content", "Thumbnail", "Authors", "DatePublished"
        };

        private Func<CMS.DocumentEngine.Types.MedioClinic.Article, ArticleDto> ArticleDtoSelect => article => new ArticleDto()
        {
            NodeAlias = article.NodeAlias,
            NodeGuid = article.NodeGUID,
            NodeId = article.NodeID,
            Title = article.Title,
            Summary = article.Summary,
            Content = article.Content,
            Authors = article.Authors,
            Thumbnail = article.Fields.Thumbnail,
            DatePublished = article.DatePublished
        };

        ISiteContextService SiteContextService { get; }

        public ArticleRepository(IDocumentQueryService documentQueryService, ISiteContextService siteContextService) : base(documentQueryService)
        {
            SiteContextService = siteContextService;
        }

        public IEnumerable<ArticleDto> GetArticles()
        {
            return DocumentQueryService.GetDocuments<CMS.DocumentEngine.Types.MedioClinic.Article>()
                .AddColumns(_articleColumns)
                .ToList()
                .Select(ArticleDtoSelect)
                .OrderByDescending(obj => obj.DatePublished);
        }

        public ArticleDto GetArticle(Guid nodeGuid)
        {
            return DocumentQueryService.GetDocument<CMS.DocumentEngine.Types.MedioClinic.Article>(nodeGuid)
                .AddColumns(_articleColumns)
                .Select(ArticleDtoSelect)
                .FirstOrDefault();
        }
    }
}

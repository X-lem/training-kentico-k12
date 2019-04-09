using System;
using System.Linq;
using CMS.DocumentEngine.Types.MedioClinic;
using Business.Dto.Articles;
using Business.Services.Query;

namespace Business.Repository.Article
{
    public class ArticleSectionRepository : BaseRepository, IArticleSectionRepository
    {

        public ArticleSectionRepository(IDocumentQueryService documentQueryService) : base(documentQueryService)
        {
        }

        public ArticleSectionDto GetArticleSection()
        {
            return DocumentQueryService.GetDocuments<ArticleSection>()
                .AddColumns("Title")
                .TopN(1)
                .ToList()
                .Select(m => new ArticleSectionDto()
                {
                    Header = m.Title
                })
                .FirstOrDefault();
        }
    }
}
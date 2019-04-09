using Business.Dto.Articles;
using System;
using System.Collections.Generic;

namespace Business.Repository.Article
{
    public interface IArticleRepository : IRepository
    {
        IEnumerable<ArticleDto> GetArticles();
        ArticleDto GetArticle(Guid nodeGuid);
    }
}
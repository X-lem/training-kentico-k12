using Business.Dto.Articles;

namespace Business.Repository.Article
{
    public interface IArticleSectionRepository : IRepository
    {
        ArticleSectionDto GetArticleSection();
    }
}
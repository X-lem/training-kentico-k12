using Business.Dto.Articles;

namespace MedioClinic.Models.Articles
{
    public class ArticleDetailViewModel : IViewModel
    {
        public ArticleDto Article { get; set; }
    }
}